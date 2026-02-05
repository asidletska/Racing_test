using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        OrderInRacing car = other.GetComponent<OrderInRacing>();
        if (car != null)
        {
            car.LapTriggerPassed();
        }
    }
}
