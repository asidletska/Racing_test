using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SplinePositionCars : MonoBehaviour
{
    public List<OrderInRacing> racers;

    void Update()
    {
        racers = racers
            .OrderByDescending(r => r.GetRaceProgress())
            .ToList();

        for (int i = 0; i < racers.Count; i++)
        {
            Debug.Log(racers[i].name + " Position: " + (i + 1));
        }
    }
}
