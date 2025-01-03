using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera camera1;
    public Camera camera2;
    public Camera camera3;

    void Start()
    {
        // Ensure only camera1 is active at the start
        ActivateCamera(camera1);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) // Press '1'
        {
            ActivateCamera(camera1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) // Press '2'
        {
            ActivateCamera(camera2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3)) // Press '3'
        {
            ActivateCamera(camera3);
        }
    }

    void ActivateCamera(Camera activeCamera)
    {
        // Disable all cameras
        camera1.gameObject.SetActive(false);
        camera2.gameObject.SetActive(false);
        camera3.gameObject.SetActive(false);

        // Enable the selected camera
        activeCamera.gameObject.SetActive(true);
    }
}