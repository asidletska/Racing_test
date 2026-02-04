using UnityEngine;

public class MiniMapIcon : MonoBehaviour
{
    public Transform target; 
    public float height = 200f;

    void LateUpdate()
    {
        if (!target) return;

        transform.position = new Vector3(
            target.position.x,
            height,
            target.position.z
        );

        transform.rotation = Quaternion.Euler(90f, target.eulerAngles.y, 0f);
    }
}
