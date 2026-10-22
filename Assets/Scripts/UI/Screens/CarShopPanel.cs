using Configs.Car;
using UnityEngine;
using System.Linq;

public class CarShopPanel : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private CarConfig config;

    [Header("UI")]
    [SerializeField] private Transform contentRoot;
    [SerializeField] private CarShopItemView itemPrefab;
    [SerializeField] private CoinsTextView coinsView;

    [Header("3D Preview")]
    [SerializeField] private CarShowPreview showroom;

    private CarShopItemView[] _items;

    private void Start()
    {
        Build();
        RefreshAll();

        ShowSelectedPreview();
    }

    private void Build()
    {
        for (int i = contentRoot.childCount - 1; i >= 0; i--)
            Destroy(contentRoot.GetChild(i).gameObject);

        _items = new CarShopItemView[config.cars.Length];

        for (int i = 0; i < config.cars.Length; i++)
        {
            var data = config.cars[i];

            var view = Instantiate(itemPrefab, contentRoot);
            _items[i] = view;

          /*  view.Bind(
                data.displayName,
                data.carIndex,
                data.price,
                data.previewPrefab,
                onChanged: () =>
                {
                    RefreshAll();
                    ShowSelectedPreview();
                },
                onPreviewRequested: prefab =>
                {
                    if (showroom != null) showroom.Show(prefab);
                }
            );*/
        }
    }

    private void RefreshAll()
    {
        if (coinsView != null) coinsView.Refresh();
        if (_items == null) return;

     //   foreach (var it in _items) it.Refresh();
    }

    private void ShowSelectedPreview()
    {
        var save = ServiceLocator.Get<SaveService>();
        int selectedIndex = save.Data.selectedCarIndex;

        for (int i = 0; i < config.cars.Length; i++)
        {
            if (config.cars[i].carIndex == selectedIndex)
            {
                showroom?.Show(config.cars[i].previewPrefab);
                return;
            }
        }
    }
}
