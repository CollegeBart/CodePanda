using UnityEngine;

namespace ca.codepanda
{
	public class ThunderSelfDestroy : MonoBehaviour 
	{
        public void DestroySelf()
        { 
            Destroy(gameObject);
        }
    }
}
