using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    [SerializeField] private PositionSystem positionSystem;

    private void OnTriggerEnter(Collider other)
    {
        var racer = other.GetComponentInParent<OrderInRacing>();
        if (racer == null) return;

        var raceService = ServiceLocator.Get<RaceService>();
        raceService.OnFinishPassed(racer, positionSystem);
    }
}
