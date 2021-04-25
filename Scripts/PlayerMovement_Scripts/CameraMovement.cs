using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private Transform playerTransform, cameraTranform;

    [SerializeField]
    [Range(25f, 150f)]
    private float mouseSensX = 75f, mouseSensY = 75f;

    [SerializeField]
    private float minClampVertical = -60, maxClampHorizontal = 90;

    private float verticalRotation = 0;

    private void Start()
    {
        MouseLocker.LockMouse();
    }

    private void Update()
    {
        if (!GameState.IsPlayingFPS())
            return;

        CameraHorizontalMovement();
        CameraVerticalMovement();

        //TEMPORARY
        if (Input.GetKeyDown(KeyCode.Escape))
            MouseLocker.FreeMouse();

        if (Input.GetKeyDown(KeyCode.Mouse0))
            MouseLocker.LockMouse();  
    }

    public void OverrideLookAt(Transform targetToLook)
    {
        cameraTranform.LookAt(targetToLook);
    }

    float X_ValueWithSens() 
    {
        return PlayerInputs.Camera_X_Movement() * Time.deltaTime * mouseSensX;
    }

    float Y_ValueWithSens()
    {
        return PlayerInputs.Camera_Y_Movement() * Time.deltaTime * mouseSensY;
    }

    void CameraHorizontalMovement() 
    {
        if (playerTransform == null)
            return;

        playerTransform.Rotate(Vector3.up * X_ValueWithSens());
    }

    void CameraVerticalMovement()
    {
        if (cameraTranform == null)
            return;

        verticalRotation -= Y_ValueWithSens();
        verticalRotation = Mathf.Clamp(verticalRotation, minClampVertical, maxClampHorizontal);

        cameraTranform.localRotation =Quaternion.Euler(verticalRotation, 0f, 0f);
    }
}
