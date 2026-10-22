using UnityEngine;
public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] private Camera[] cameras;

    private int currentIndex = 0;

    private void Start()
    {
        ActivateCamera(0);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            SwitchCamera();
        }
    }

    private void SwitchCamera()
    {
        currentIndex++;
        if (currentIndex >= cameras.Length)
            currentIndex = 0;

        ActivateCamera(currentIndex);
    }

    private void ActivateCamera(int index)
    {
        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].gameObject.SetActive(i == index);
        }
    }
}
