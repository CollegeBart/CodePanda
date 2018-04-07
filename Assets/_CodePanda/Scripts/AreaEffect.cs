using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ca.codepanda
{

public class AreaEffect : MonoBehaviour {

    private Animator anim;

	    void Start ()
        {
		    if(anim == null)
            {
                anim = GetComponent<Animator>();
            }
        }

        void OnEnable()
        {
            MapManager.OnStormStart += OnStormStartHandler;
            MapManager.OnStormEnd += OnStormEndHandler;
        }

        void OnDisable()
        {
            MapManager.OnStormStart -= OnStormStartHandler;
            MapManager.OnStormEnd -= OnStormEndHandler;
        }

        void OnStormStartHandler()
        {
            anim.SetBool("isStriking", true);
        }

        void OnStormEndHandler()
        {
            anim.SetBool("isStriking", false);
        }
}
}
