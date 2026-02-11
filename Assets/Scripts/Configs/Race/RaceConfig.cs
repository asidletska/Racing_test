using UnityEngine;

namespace Configs.Race
{
    [CreateAssetMenu(menuName = "", fileName = "")]
    public class RaceConfig : ScriptableObject
    {
        public int totalLaps = 3;
        public int firstPlaceReward = 1000;
        public int secondPlaceReward = 500;
        public int thirdPlaceReward = 200;
    }
}
