using UnityEngine;

namespace ca.codepanda
{
	public class AnimatorAutoSetState : MonoBehaviour 
	{
        public Animator _animator;

        public void Activate()
        {
            _animator.SetInteger("state", 1);
            Debug.Log(_animator.GetInteger("state"));
        }

		public void FinishBounce()
        {
            GetComponent<Animator>().SetInteger("state", 0);
        }

        public void Deactivate()
        {
            _animator.SetInteger("state", 2);
        }
	}
}
