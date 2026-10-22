using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Rigidbody))]
public class EngineSounds : MonoBehaviour
{
    [Header("RPM Settings")]
    [SerializeField] private float minRPM = 800f;
    [SerializeField] private float maxRPM = 7000f;

    [Header("Pitch Settings")]
    [SerializeField] private float minPitch = 0.8f;
    [SerializeField] private float maxPitch = 2.2f;

    [Header("Response")]
    [SerializeField] private float rpmSmoothSpeed = 5f;

    private AudioSource audioSource;
    private Rigidbody rb;

    private float currentRPM;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        audioSource.loop = true;
        audioSource.Play();
    }

    private void Update()
    {
        UpdateRPM();
        UpdateSound();
    }

    private void UpdateRPM()
    {
        float speed = rb.velocity.magnitude;

        float targetRPM = Mathf.Lerp(minRPM, maxRPM, speed / 50f);

        currentRPM = Mathf.Lerp(
            currentRPM,
            targetRPM,
            Time.deltaTime * rpmSmoothSpeed
        );
    }

    private void UpdateSound()
    {
        float normalizedRPM = Mathf.InverseLerp(minRPM, maxRPM, currentRPM);

        float targetPitch = Mathf.Lerp(minPitch, maxPitch, normalizedRPM);

        audioSource.pitch = targetPitch;
    }
}
