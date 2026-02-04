using UnityEngine;
using UnityEngine.Splines;
using Unity.Mathematics;

public class OrderInRacing : MonoBehaviour
{
    public SplineContainer spline;
    public int currentLap = 0;

    [Range(0f, 1f)]
    public float splinePosition;

    private float lastSplinePos;

    void Update()
    {
        if (spline == null) return;

        SplineUtility.GetNearestPoint(
            spline.Spline,
            transform.position,
            out float3 nearest,
            out float t
        );

        splinePosition = t;

        if (splinePosition < 0.1f && lastSplinePos > 0.9f)
            currentLap++;

        lastSplinePos = splinePosition;
    }

    public float GetRaceProgress()
    {
        return currentLap + splinePosition;
    }
}
