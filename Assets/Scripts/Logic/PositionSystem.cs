using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PositionSystem : MonoBehaviour
{
    private List<Transform> racers = new();

    public void Register(Transform racer)
    {
        racers.Add(racer);
    }

    public int GetPosition(Transform racer)
    {
        var sorted = racers.OrderByDescending(r => r.position.z).ToList();
        return sorted.IndexOf(racer) + 1;
    }

    public void RegisterRacer(Transform playerCarTransform)
    {
        throw new System.NotImplementedException();
    }
}
