using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimBook : MonoBehaviour {

    private Animator anim;

    private float timer = 30.0f;

    private void Awake()
    {
        anim.SetBool("Openning", true);
        Debug.Log("OPENING BOOK");

        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            Debug.Log("CLOSING THE BOOK");
        }
    }


}
