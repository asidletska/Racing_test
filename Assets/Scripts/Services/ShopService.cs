
public class ShopService 
{
    private SaveService Save => ServiceLocator.Get<SaveService>();
    private EconomyService Economy => ServiceLocator.Get<EconomyService>();

    public bool BuyCar(int carIndex, int price)
    {
        if (!Economy.SpendCoins(price))
            return false;

        Save.Data.unlockedCars.Add(carIndex);
        Save.Save();
        return true;
    }
}
