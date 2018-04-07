using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using ca.codepanda;

public class SceneChanges : MonoBehaviour
{
    public string _sceneName = "CodePanda2018 - Alex";

    private void Update()
    { 
        for (int i = 0; i < 3; i++)
        {
            if (InputManager.Button_A(i))
            {
                SceneManager.LoadScene(_sceneName);
            }
        }

    }
}
   

