// BASED UPON THIS INPUT SCHEMA http://wiki.unity3d.com/index.php?title=Xbox360Controller
// Will probably need to be remaped with the controllers available

using UnityEngine;

namespace ca.codepanda
{
    public static class InputManager
    {
        private readonly static string[] l_x = { "L_XAxis_1", "L_XAxis_2", "L_XAxis_3", "L_XAxis_4" };
        private readonly static string[] l_y = { "L_YAxis_1", "L_YAxis_2", "L_YAxis_3", "L_YAxis_4" };
        private readonly static string[] r_x = { "R_XAxis_1", "R_XAxis_2", "R_XAxis_3", "R_XAxis_4" };
        private readonly static string[] r_y = { "R_YAxis_1", "R_YAxis_2", "R_YAxis_3", "R_YAxis_4" };

        private readonly static string[] a = { "A_1", "A_2", "A_3", "A_4" };
        private readonly static string[] b = { "B_1", "B_2", "B_3", "B_4" };
        private readonly static string[] x = { "X_1", "X_2", "X_3", "X_4" };
        private readonly static string[] y = { "Y_1", "Y_2", "Y_3", "Y_4" };

        private readonly static string[] t_l = { "TriggersL_1", "TriggersL_2", "TriggersL_3", "TriggersL_4" };
        private readonly static string[] t_r = { "TriggersR_1", "TriggersR_2", "TriggersR_3", "TriggersR_4" };

        private readonly static string[] start = { "Start_1", "Start_2", "Start_3", "Start_4" };

        public static float L_XAxis(int index) { return Input.GetAxis(l_x[index]); }
        public static float L_YAxis(int index) { return Input.GetAxis(l_y[index]); }
        public static Vector3 L_Axis(int index) { return new Vector3(L_XAxis(index), L_YAxis(index), 0); }

        public static float R_XAxis(int index) { return Input.GetAxis(r_x[index]); }
        public static float R_YAxis(int index) { return Input.GetAxis(r_y[index]); }
        public static Vector3 R_Axis(int index) { return new Vector3(R_XAxis(index), R_YAxis(index), 0); }

        public static bool Button_A(int index) { return Input.GetButtonDown(a[index]); }
        public static bool Button_B(int index) { return Input.GetButtonDown(b[index]); }
        public static bool Button_X(int index) { return Input.GetButtonDown(x[index]); }
        public static bool Button_Y(int index) { return Input.GetButtonDown(y[index]); }


        public static bool Button_A_Release(int index) { return Input.GetButtonUp(a[index]); }
        public static bool Button_B_Release(int index) { return Input.GetButtonUp(b[index]); }
        public static bool Button_X_Release(int index) { return Input.GetButtonUp(x[index]); }
        public static bool Button_Y_Release(int index) { return Input.GetButtonUp(y[index]); }

        public static bool Trigger_Left(int index) { return Input.GetButtonDown(t_l[index]); }
        public static bool Trigger_Right(int index) { return Input.GetButtonDown(t_r[index]); }

        public static bool Button_Start(int index) { return Input.GetButtonDown(start[index]); }

        //public static float MainHorizontal()
        //{
        //    float result = 0.0f;
        //    result += Input.GetAxis("JoystickMainHorizontal");
        //    result += Input.GetAxis("KeyboardMainHorizontal");
        //    return Mathf.Clamp(result, -1.0f, 1.0f);
        //}
        //
        //public static float MainVertical()
        //{
        //    float result = 0.0f;
        //    result += Input.GetAxis("JoystickMainVertical");
        //    result += Input.GetAxis("KeyboardMainVertical");
        //    return Mathf.Clamp(result, -1.0f, 1.0f);
        //}
        //
        //public static Vector3 MainMovement()
        //{
        //    return new Vector3(MainHorizontal(), 0, MainVertical());
        //}

        //public static bool ActionButton()
        //{
        //    return Input.GetButtonDown("Action_Button");
        //}
        //
        //public static bool CancelButton()
        //{
        //    return Input.GetButtonDown("Cancel_Button");
        //}
        //
        //public static bool XButton()
        //{
        //    return Input.GetButtonDown("X_Button");
        //}
        //
        //public static bool YButton()
        //{
        //    return Input.GetButtonDown("Y_Button");
        //}
    }
}
