using UnityEngine;

public class Speedometer : MonoBehaviour
{
    [Header("References")]
    public Rigidbody carRigidbody;

    [Header("Speed Settings")]
    public float maxSpeed = 220f; 

    [Header("Needle Angles")]
    public float minAngle = -130f; 
    public float maxAngle = 130f;  

    [Header("Smoothing")]
    public float needleSmoothSpeed = 5f; 

    private float currentAngle;

    void Update()
    {
        float speed = carRigidbody.velocity.magnitude * 3.6f; 
        float speedPercent = Mathf.Clamp01(speed / maxSpeed);

        float targetAngle = Mathf.Lerp(minAngle, maxAngle, speedPercent);

        currentAngle = Mathf.Lerp(currentAngle, targetAngle, Time.deltaTime * needleSmoothSpeed);

        transform.localRotation = Quaternion.Euler(0f, 0f, -currentAngle);
    }
}
