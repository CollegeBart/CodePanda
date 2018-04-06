using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using ca.codepanda;

public class SceneChanges : MonoBehaviour
{
    private void Update()
    { 
        for (int i = 0; i < 3; i++)
        {
            if (InputManager.Button_A(i))
            {
                SceneManager.LoadScene("SceneJess");
            }
        }

    }
}
   

