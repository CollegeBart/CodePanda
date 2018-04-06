using UnityEngine;

namespace ca.codepanda
{
    public class CharController : MonoBehaviour
    {
        public int _playerIndex;
        public float _speed = 30f;
        public Rigidbody2D _rigidbody;
        public Animator _animator;
        private Transform _holdedObject;
        private bool _buttonAWasReleased;
        private bool _facingRight;

        void Start()
        {
            if (_rigidbody == null)
                _rigidbody = GetComponent<Rigidbody2D>();
            if (_animator == null)
                _animator = GetComponent<Animator>();
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

            SetSpriteDirection(XVelocity, YVelocity);

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

        private void SetSpriteDirection(float XVelocity, float YVelocity)
        {
            if (XVelocity < 0.0f && _facingRight == false)
                FlipPlayer();
            else if (XVelocity > 0.0f && _facingRight)
                FlipPlayer();

            bool goingUp = false;
            bool goingDown = false;

            if (YVelocity > 0)
                goingUp = true;
            else if (YVelocity < 0)
                goingDown = true;
            

            _animator.SetBool("WalkingUp", goingUp);
            _animator.SetBool("WalkingDown", goingDown);
        }

        private void FlipPlayer()
        {
            _facingRight = !_facingRight;
            Vector2 localScale = gameObject.transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }
    }
}
