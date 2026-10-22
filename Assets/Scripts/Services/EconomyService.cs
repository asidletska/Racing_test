
    public class EconomyService
    {
        private SaveService Save => ServiceLocator.Get<SaveService>();

        public int Coins => Save.Data.coins;

        public void AddCoins(int amount)
        {
            if (amount <= 0) return;

            Save.Data.coins += amount;
            Save.Save();
        }

        public bool SpendCoins(int amount)
        {
            if (amount <= 0) return true;
            if (Save.Data.coins < amount) return false;

            Save.Data.coins -= amount;
            Save.Save();
            return true;
        }
    }
