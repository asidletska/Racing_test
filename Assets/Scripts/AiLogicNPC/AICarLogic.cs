using UnityEngine;
using UnityEngine.Splines;

public class AICarLogic : MonoBehaviour
{
    public SplineContainer spline;
    public Rigidbody rb;

    public float speed = 20f;
    public float steerSpeed = 5f;
    public float lookAheadDistance = 3f;

    private float t; // позиція на сплайні (0–1)

    void FixedUpdate()
    {
        if (spline == null) return;

        // Рух по сплайну
        t += (speed / spline.CalculateLength()) * Time.fixedDeltaTime;
        t %= 1f;

        Vector3 currentPos = spline.EvaluatePosition(t);
        Vector3 forwardPos = spline.EvaluatePosition((t + lookAheadDistance / spline.CalculateLength()) % 1f);

        Vector3 dir = (forwardPos - rb.position).normalized;

        // Поворот
        Quaternion targetRot = Quaternion.LookRotation(dir, Vector3.up);
        rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetRot, steerSpeed * Time.fixedDeltaTime));

        // Рух вперед
        rb.MovePosition(rb.position + rb.transform.forward * speed * Time.fixedDeltaTime);
    }
}
