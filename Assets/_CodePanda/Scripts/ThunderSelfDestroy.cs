using UnityEngine;
using System.Collections;

namespace ca.codepanda
{
	public class ThunderSelfDestroy : MonoBehaviour 
	{
        public float _destroyDelay = 3f;

		void Start()
        {
            StartCoroutine(DestroySelf());
        }

        private IEnumerator DestroySelf()
        {
            yield return new WaitForSeconds(_destroyDelay);
            Destroy(gameObject);
        }
    }
}
