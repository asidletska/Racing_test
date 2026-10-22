using Configs.Car;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CarShopItemView : MonoBehaviour
{
 [Header("Config")]
    [SerializeField] private CarConfig config;

    [Header("3D Preview")]
    [SerializeField] private CarShowPreview showroom;

    [Header("UI")]
    [SerializeField] private CoinsTextView coinsView;

    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text priceText;

    [SerializeField] private Button nextButton;
    [SerializeField] private Button prevButton;

    [SerializeField] private Button buyButton;
    [SerializeField] private Button selectButton;

    [Header("Badges / Labels")]
    [SerializeField] private GameObject lockedBadge;
    [SerializeField] private GameObject selectedBadge;
    [SerializeField] private GameObject purchasedBadge;

    private int _index;

    private ShopService _shop;
    private SaveService _save;

    private void Awake()
    {
        _shop = ServiceLocator.Get<ShopService>();
        _save = ServiceLocator.Get<SaveService>();

        nextButton.onClick.AddListener(Next);
        prevButton.onClick.AddListener(Prev);

        buyButton.onClick.AddListener(BuyCurrent);
        selectButton.onClick.AddListener(SelectCurrent);
    }

    private void Start()
    {
        _index = FindIndexByCarIndex(_save.Data.selectedCarIndex);
        if (_index < 0) _index = 0;

        ShowCurrent();
    }

    private void Next()
    {
        if (config == null || config.cars == null || config.cars.Length == 0) return;

        _index++;
        if (_index >= config.cars.Length) _index = 0;
        ShowCurrent();
    }

    private void Prev()
    {
        if (config == null || config.cars == null || config.cars.Length == 0) return;

        _index--;
        if (_index < 0) _index = config.cars.Length - 1;
        ShowCurrent();
    }

    private void ShowCurrent()
    {
        if (config == null || config.cars == null || config.cars.Length == 0) return;

        var item = config.cars[_index];

        nameText.text = item.displayName;

        bool unlocked = _shop.IsUnlocked(item.carIndex);
        bool selected = _save.Data.selectedCarIndex == item.carIndex;

        showroom?.Show(item.previewPrefab);

        priceText.gameObject.SetActive(!unlocked);
        priceText.text = item.price.ToString();

        if (lockedBadge) lockedBadge.SetActive(!unlocked);
        if (selectedBadge) selectedBadge.SetActive(selected);
        if (purchasedBadge) purchasedBadge.SetActive(unlocked && !selected);

        buyButton.gameObject.SetActive(!unlocked);
        selectButton.gameObject.SetActive(unlocked && !selected);

        coinsView?.Refresh();
    }

    private void BuyCurrent()
    {
        var item = config.cars[_index];

        bool ok = _shop.BuyCar(item.carIndex, item.price);
        if (ok)
        {
            _shop.SelectCar(item.carIndex);
            _index = FindIndexByCarIndex(item.carIndex);
        }

        ShowCurrent();
    }

    private void SelectCurrent()
    {
        var item = config.cars[_index];

        _shop.SelectCar(item.carIndex);
        ShowCurrent();
    }

    private int FindIndexByCarIndex(int carIndex)
    {
        if (config == null || config.cars == null) return -1;

        for (int i = 0; i < config.cars.Length; i++)
            if (config.cars[i].carIndex == carIndex)
                return i;

        return -1;
    }
}