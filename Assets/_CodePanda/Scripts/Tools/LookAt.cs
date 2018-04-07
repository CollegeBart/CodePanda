using UnityEngine;

namespace ca.codepanda
{
    public class LookAt : MonoBehaviour
    {
        [Tooltip("Use when the forward is in the wrong direction. Useful for UI elements.")]
        public bool reverse;

        private void OnEnable()
        {
            Vector3 target = References.Instance._camera.transform.position;
            if (reverse)
            {
                Vector3 direction = target - transform.position;
                Quaternion inverseRot = Quaternion.LookRotation(-direction);
                transform.rotation = inverseRot;
            }
            else
            {
                transform.LookAt(target);
            }
        }
    }
}
