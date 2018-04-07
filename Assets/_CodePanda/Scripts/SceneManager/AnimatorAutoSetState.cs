using UnityEngine;

namespace ca.codepanda
{
	public class AnimatorAutoSetState : MonoBehaviour 
	{
        public Animator _animator;

        public void Activate()
        {
            _animator.SetInteger("state", 1);
        }

		public void FinishBounce()
        {
            _animator.SetInteger("state", 0);
        }

        public void Deactivate()
        {
            _animator.SetInteger("state", 2);
        }
	}
}
