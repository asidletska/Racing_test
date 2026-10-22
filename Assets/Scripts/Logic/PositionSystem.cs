using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PositionSystem : MonoBehaviour
{
    private readonly List<Transform> racers = new();

    public void RegisterRacer(Transform racer)
    {
        if (racer == null) return;
        if (racers.Contains(racer)) return;

        racers.Add(racer);
    }

    public int GetPosition(Transform racer)
    {
        if (racer == null) return racers.Count;

        var sorted = racers
            .OrderByDescending(r =>
            {
                var o = r.GetComponent<OrderInRacing>();
                if (o != null) return o.GetRaceProgress();

                return r.position.z;
            })
            .ToList();

        return sorted.IndexOf(racer) + 1;
    }
}
