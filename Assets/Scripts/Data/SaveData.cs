using System;
using System.Collections.Generic;

[Serializable]
public class SaveData
{
    public int coins = 0;

    public int selectedCarIndex = 0;
    public int selectedRaceIndex = 0;
    public List<int> unlockedRaces = new List<int>() { 0 };
    public List<int> unlockedCars = new List<int>() { 0 }; 

    public float bestLapTime = 9999f;

    public float musicVolume = 1f;
    public float sfxVolume = 1f;
}
