using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SplinePositionCars : MonoBehaviour
{
    public List<OrderInRacing> racers = new List<OrderInRacing>();

    void Update()
    {
        racers.Sort(CompareProgress);

        for (int i = 0; i < racers.Count; i++)
        {
            racers[i].racePosition = i + 1;
        }
    }

    int CompareProgress(OrderInRacing a,OrderInRacing b)
    {
        return b.GetRaceProgress().CompareTo(a.GetRaceProgress());
    }
}
