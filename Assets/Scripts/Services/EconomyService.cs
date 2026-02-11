
    public class EconomyService
    {
        private SaveService Save => ServiceLocator.Get<SaveService>();

        public void AddCoins(int amount)
        {
            Save.Data.coins += amount;
            Save.Save();
        }

        public bool SpendCoins(int amount)
        {
            if (Save.Data.coins < amount)
                return false;

            Save.Data.coins -= amount;
            Save.Save();
            return true;
        }
    }
