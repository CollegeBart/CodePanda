using UnityEngine;

namespace ca.codepanda
{
	public class MenuAnimAccessory : MonoBehaviour 
	{
        private Animator _anim;

        private void Start()
        {
            _anim = GetComponent<Animator>();
        }

        public void FinishBounce()
        {
            _anim.SetInteger("state", 0);
        }
	}
}
