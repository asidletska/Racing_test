
public class ShopService 
{
    private SaveService Save => ServiceLocator.Get<SaveService>();
    private EconomyService Economy => ServiceLocator.Get<EconomyService>();

    public bool IsUnlocked(int carIndex) => Save.Data.unlockedCars.Contains(carIndex);

    public bool BuyCar(int carIndex, int price)
    {
        if (IsUnlocked(carIndex))
            return true;

        if (!Economy.SpendCoins(price))
            return false;

        Save.Data.unlockedCars.Add(carIndex);
        Save.Save();
        return true;
    }

    public bool SelectCar(int carIndex)
    {
        if (!IsUnlocked(carIndex))
            return false;

        Save.Data.selectedCarIndex = carIndex;
        Save.Save();
        return true;
    }
}
