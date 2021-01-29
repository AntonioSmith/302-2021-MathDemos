using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitCameraControl : MonoBehaviour
{
    #region Variables
    float pitch = 0; // Tile of cam in degrees
    float targetPitch = 0;
    float yaw = 0; // Yaw angle of camera in degrees
    float targetYaw = 0;
    float dollyDis = 10; // Distance between camera and target in meters
    float targetDollyDis = 0;
    public float mouseSensitivityX = 1; // scales veritcal mouse input
    public float mouseSensitivityY = 1; // scales horizontal mouse input
    public float mouseScrollMultiplier = 5;    

    private Camera cam;
    #endregion

    void Start()
    {
        cam = GetComponentInChildren<Camera>();
    }

    void Update()
    {
        if (Input.GetButton("Fire1")) // On Left Click
        {
            // Change Pitch on Mouse1
            float mouseY = Input.GetAxis("Mouse Y");
            float mouseX = Input.GetAxis("Mouse X");

            targetYaw += mouseX * mouseSensitivityX;
            targetPitch += mouseY * mouseSensitivityY;
        }

        float scroll = Input.GetAxisRaw("Mouse ScrollWheel"); // Scoll mousewheel to change DollyDis
        targetDollyDis += scroll * mouseScrollMultiplier;
        targetDollyDis = Mathf.Clamp(targetDollyDis, 2.5f, 15f);

        dollyDis = AnimMath.Slide(dollyDis, targetDollyDis, .95f); // EASE

        cam.transform.localPosition = new Vector3(0, 0, -dollyDis);

        targetPitch = Mathf.Clamp(targetPitch, -89, 89);

        pitch = AnimMath.Slide(pitch, targetPitch, .95f); // EASE
        yaw = AnimMath.Slide(yaw, targetYaw, .95f); // EASE

        //Quaternion targetRotation = Quaternion.Euler(pitch, yaw, 0);
        //transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 0.01f); // Slerp can be used for a spherical rotation

        transform.rotation = Quaternion.Euler(pitch, yaw, 0);
    }
}
