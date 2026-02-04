using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CarMovement : MonoBehaviour
{
    [Header("Wheel Colliders")]
    public WheelCollider frontLeftWheel;
    public WheelCollider frontRightWheel;
    public WheelCollider rearLeftWheel;
    public WheelCollider rearRightWheel;

    [Header("Wheel Meshes")]
    public Transform frontLeftMesh;
    public Transform frontRightMesh;
    public Transform rearLeftMesh;
    public Transform rearRightMesh;

    [Header("Car Settings")]
    public float motorPower = 1500f;
    public float brakePower = 3000f;
    public float maxSteerAngle = 30f;
    public float maxSpeed = 200f; 
    public float downforce = 80f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.mass = 1300f;
        rb.centerOfMass = new Vector3(0, -0.5f, 0);
    }

    void FixedUpdate()
    {
        HandleMotor();
        HandleSteering();
        ApplyDownforce();
        UpdateWheelMeshes();
    }

    void HandleMotor()
    {
        float vertical = Input.GetAxis("Vertical");
        float speed = rb.velocity.magnitude * 3.6f; // в км/год

        if (speed < maxSpeed)
        {
            rearLeftWheel.motorTorque = vertical * motorPower;
            rearRightWheel.motorTorque = vertical * motorPower;
        }
        else
        {
            rearLeftWheel.motorTorque = 0;
            rearRightWheel.motorTorque = 0;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            rearLeftWheel.brakeTorque = brakePower;
            rearRightWheel.brakeTorque = brakePower;
        }
        else
        {
            rearLeftWheel.brakeTorque = 0;
            rearRightWheel.brakeTorque = 0;
        }
    }

    void HandleSteering()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float speedFactor = rb.velocity.magnitude / 25f;

        float steerAngle = maxSteerAngle * horizontal / (1 + speedFactor);

        frontLeftWheel.steerAngle = steerAngle;
        frontRightWheel.steerAngle = steerAngle;
    }

    void ApplyDownforce()
    {
        rb.AddForce(-transform.up * downforce * rb.velocity.magnitude);
    }

    void UpdateWheelMeshes()
    {
        UpdateWheel(frontLeftWheel, frontLeftMesh);
        UpdateWheel(frontRightWheel, frontRightMesh);
        UpdateWheel(rearLeftWheel, rearLeftMesh);
        UpdateWheel(rearRightWheel, rearRightMesh);
    }

    void UpdateWheel(WheelCollider col, Transform mesh)
    {
        Vector3 pos;
        Quaternion rot;
        col.GetWorldPose(out pos, out rot);
        mesh.position = pos;
        mesh.rotation = rot;
    }
}
