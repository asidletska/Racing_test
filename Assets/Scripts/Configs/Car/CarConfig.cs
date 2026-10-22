using UnityEngine;

namespace Configs.Car
{
    [CreateAssetMenu(menuName = "", fileName = "")]
    public class CarConfig : ScriptableObject
    {
        public CarShopItem[] cars;
    }
    [System.Serializable]
    public struct CarShopItem
    {
        public string displayName;
        public int price;

        public int carIndex;               
        public GameObject previewPrefab;   
    }
}
