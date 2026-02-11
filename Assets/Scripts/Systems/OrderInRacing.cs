using UnityEngine;
using UnityEngine.Splines;
using Unity.Mathematics;

public class OrderInRacing : MonoBehaviour
{
    public SplineContainer spline;

    public int currentLap = 0;
    [Range(0,1)] public float splinePosition;

    private bool canCountLap = true;
    [HideInInspector] public int racePosition;

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
    }

    public void LapTriggerPassed()
    {
        if (!canCountLap) return;

        currentLap++;
       // canCountLap = false;
            //Invoke(nameof(ResetLapTrigger), 2f); 
    }

    void ResetLapTrigger()
    {
        canCountLap = true;
    }

    public float GetRaceProgress()
    {
        return currentLap + splinePosition;
    }
}
