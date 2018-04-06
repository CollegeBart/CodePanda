using UnityEngine;

namespace ca.codepanda
{
	public class TestInput : MonoBehaviour 
	{
		void Update () 
		{
            for (int i = 0; i < 3; i++)
            {
                if (InputManager.L_XAxis(i) != 0)
                {
                    Debug.Log(InputManager.L_XAxis(i).ToString() + " " + i);
                }
                if (InputManager.L_YAxis(i) != 0)
                {
                    Debug.Log(InputManager.L_YAxis(i).ToString() + " " + i);
                }
                if (InputManager.L_Axis(i) != Vector3.zero)
                {
                    Debug.Log(InputManager.L_Axis(i).ToString() + " " + i);
                }

                if (InputManager.R_XAxis(i) != 0)
                {
                    Debug.Log(InputManager.R_Axis(i).ToString() + " " + i);
                }
                if (InputManager.R_YAxis(i) != 0)
                {
                    Debug.Log(InputManager.R_Axis(i).ToString() + " " + i);
                }
                if (InputManager.R_Axis(i) != Vector3.zero)
                {
                    Debug.Log(InputManager.R_Axis(i).ToString() + " " + i);
                }

                if (InputManager.Button_A(i))
                {
                    Debug.Log("A" + i);
                }
                if (InputManager.Button_B(i))
                {
                    Debug.Log("B" + i);
                }
                if (InputManager.Button_X(i))
                {
                    Debug.Log("X" + i);
                }
                if (InputManager.Button_Y(i))
                {
                    Debug.Log("Y" + i);
                }

                if (InputManager.Trigger_Left(i))
                {
                    Debug.Log("left" + i);
                }
                if (InputManager.Trigger_Right(i))
                {
                    Debug.Log("right" + i);
                }

                if (InputManager.Button_Start(i))
                {
                    Debug.Log("Start" + i);
                }
            }
		}
	}
}
