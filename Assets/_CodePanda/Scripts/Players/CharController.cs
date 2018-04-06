using UnityEngine;

namespace ca.codepanda
{
    public class CharController : MonoBehaviour
    {
        public int _playerIndex;
        public float _speed = 30f;
        public Rigidbody2D _rigidbody;
        private Transform _holdedObject;
        private bool _buttonAWasReleased;

        void Start()
        {
            if (_rigidbody == null)
            {
                _rigidbody = GetComponent<Rigidbody2D>();
            }
        }

        private void Update()
        {
            if (InputManager.Button_A_Release(_playerIndex))
            {
                if (_holdedObject != null)
                {
                    _holdedObject.transform.parent = null;
                    _holdedObject.GetComponent<Collider2D>().enabled = true;
                    _holdedObject.GetComponent<Rigidbody2D>().isKinematic = false;
                }
            }
        }

        private void FixedUpdate()
        {         

            float XVelocity = InputManager.L_XAxis(_playerIndex) * _speed;
            float YVelocity = InputManager.L_YAxis(_playerIndex) * -1 * _speed;

            _rigidbody.velocity = new Vector2(XVelocity, YVelocity);
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.tag.Contains("Ingredient"))
            {
                if (InputManager.Button_A(_playerIndex))
                {
                    var parent = collision.transform.parent;
                    parent.GetComponent<Collider2D>().enabled = false;
                    parent.parent = transform;
                    parent.position = transform.position;
                    _holdedObject = parent;
                    collision.GetComponentInParent<Rigidbody2D>().isKinematic = true;
                }
            }
        }
    }
}
