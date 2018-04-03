using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputManager
{
    public static float MainHorizontal()
    {
        float result = 0.0f;
        result += Input.GetAxis("JoystickMainHorizontal");
        result += Input.GetAxis("KeyboardMainHorizontal");
        return Mathf.Clamp(result, -1.0f, 1.0f);
    }

    public static float MainVertical()
    {
        float result = 0.0f;
        result += Input.GetAxis("JoystickMainVertical");
        result += Input.GetAxis("KeyboardMainVertical");
        return Mathf.Clamp(result, -1.0f, 1.0f);
    }

    public static Vector3 MainMovement()
    {
        return new Vector3(MainHorizontal(), 0, MainVertical());
    }

    public static bool ActionButton()
    {
        return Input.GetButtonDown("Action_Button");
    }

    public static bool CancelButton()
    {
        return Input.GetButtonDown("Cancel_Button");
    }

    public static bool XButton()
    {
        return Input.GetButtonDown("X_Button");
    }

    public static bool YButton()
    {
        return Input.GetButtonDown("Y_Button");
    }

}
