﻿using UnityEngine;
using System.Collections;

namespace ca.codepanda
{
	public class Item : MonoBehaviour 
	{
        public ItemManager.Items _type;

        internal void StartPassThroughCoroutine()
        {
            StartCoroutine(PassThrough());
        }

        private IEnumerator PassThrough()
        {
            GetComponent<CircleCollider2D>().enabled = false;
            this.transform.GetChild(0).GetComponent<Collider2D>().enabled = false;
            yield return new WaitForSeconds(0.25f);
            GetComponent<CircleCollider2D>().enabled = true;
            this.transform.GetChild(0).GetComponent<Collider2D>().enabled = true;
        }
    }
}
