
namespace Services
{
    public class RaceService 
    {
        public int CurrentLap { get; private set; }

        public void AddLap()
        {
            CurrentLap++;
        }
    }
}
