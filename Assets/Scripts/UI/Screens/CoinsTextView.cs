using TMPro;
using UnityEngine;

public class CoinsTextView : MonoBehaviour
{
    [SerializeField] private TMP_Text coinsText;

    private EconomyService _economy;

    private void Awake()
    {
        _economy = ServiceLocator.Get<EconomyService>();
        Refresh();
    }

    public void Refresh()
    {
        coinsText.text = _economy.Coins.ToString();
    }
}