using UnityEngine;

public static class PlayerInputs
{
    public static Vector2 MoveInputs()
    {
        float xValue = Input.GetAxis("Horizontal");
        float yValue = Input.GetAxis("Vertical");

        return new Vector2(xValue, yValue);
    }

    public static Vector2 CameraLookMovement() 
    {
        return Vector2.one;
    }

    public static float Camera_X_Movement()
    {
        return Input.GetAxis("Mouse X");
    }

    public static float Camera_Y_Movement()
    {
        return Input.GetAxis("Mouse Y");
    }

    public static bool PressedInteracted() 
    {
        return Input.GetMouseButtonDown(0);
    }
}
