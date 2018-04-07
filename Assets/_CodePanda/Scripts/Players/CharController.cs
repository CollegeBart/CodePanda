using UnityEngine;
using System.Collections;

namespace ca.codepanda
{
    public class CharController : MonoBehaviour
    {
        private enum ANIMSTATE
        {
            Up,
            Down,
            Left,
            Right,
            Hurt
        }
        private ANIMSTATE _previousAnimState;

        private static CharactersManager _manager;

        private const float _disabledDuration = 2.1f;
        private bool _isDisabled = false;
        private Transform _cauldron;

        public int _playerIndex;
        public float _speed = 100f;
        public Rigidbody2D _rigidbody;
        public Animator _animator;
        private Transform _heldObject;

        private float _xVelocity = 0;
        private float _yVelocity = 0;
        private Vector2 _velocity = Vector3.zero;

        private bool _buttonADown;
        private bool _buttonXDown;
        private bool _rightTriggerDown;
        private Coroutine _disabledRoutine;

        private bool _dashOnCooldown = false;

        void Start()
        {
            if (_manager == null)
            {
                _manager = References.Instance._characterManager;
            }
            if (_rigidbody == null)
                _rigidbody = GetComponent<Rigidbody2D>();
            if (_animator == null)
                _animator = GetComponent<Animator>();
            _isDisabled = false;
            _cauldron = null;
            _previousAnimState = ANIMSTATE.Down;
        }

        public void CustomUpdate()
        {
            _buttonADown = InputManager.Button_A(_playerIndex);
            _buttonXDown = InputManager.Button_X(_playerIndex);
            _rightTriggerDown = InputManager.Trigger_Right(_playerIndex);

            if (!InputManager.Trigger_Right(_playerIndex))
                ReleaseItem(false);            
            if (_buttonADown)            
                Dash();
            
            SetSpriteDirection(_xVelocity, _yVelocity, _velocity.magnitude);
        }

        private void FixedUpdate()
        {
            _xVelocity = InputManager.L_XAxis(_playerIndex) * _speed;
            _yVelocity = InputManager.L_YAxis(_playerIndex) * -1 * _speed;
            _velocity = new Vector2(_xVelocity, _yVelocity);

            _rigidbody.AddForce(_velocity);
        }

        private void ReleaseItem(bool dashing)
        {
            if (_heldObject != null)
            {
                Vector2 offSetIngredient;
                var ingredientSize = _heldObject.GetComponent<CircleCollider2D>().radius * 4;
                switch (_previousAnimState)
                {
                    case ANIMSTATE.Up:
                        offSetIngredient = new Vector2(0, ingredientSize);
                        break;
                    case ANIMSTATE.Down:
                        offSetIngredient = new Vector2(0, -ingredientSize - 1);
                        break;
                    case ANIMSTATE.Left:
                        offSetIngredient = new Vector2(-ingredientSize, 0);
                        break;
                    case ANIMSTATE.Right:
                        offSetIngredient = new Vector2(ingredientSize, 0);
                        break;
                    default:
                        offSetIngredient = new Vector2(0, ingredientSize);
                        break;
                }
                _heldObject.transform.localPosition += (Vector3)offSetIngredient;
                _heldObject.transform.parent = null;
                _heldObject.GetChild(0).GetComponent<Collider2D>().enabled = true;
                _heldObject.GetComponent<Collider2D>().enabled = true;
                _heldObject.GetComponent<Rigidbody2D>().isKinematic = false;

                if (dashing)
                    _heldObject.GetComponent<Item>().StartPassThroughCoroutine();


                if (dashing)
                    _heldObject.GetComponent<Item>().StartPassThroughCoroutine();
                

                if (_cauldron != null)
                {
                    References.Instance._itemManager.FillCauldron(_cauldron.parent, _heldObject.gameObject.GetComponent<Item>(), _playerIndex);
                    Destroy(_heldObject.gameObject);
                }
                else
                {
                    _heldObject.GetComponentInChildren<SpriteRenderer>().sortingLayerName = "CollectablesBehindPlayer";
                    _heldObject = null;
                }
            }
        }

        private void Dash()
        {
            if (!_dashOnCooldown)
            {
                _dashOnCooldown = true;
                var vectorPush = (_velocity).normalized;
                _rigidbody.AddForce(vectorPush * CharactersManager._dashSpeed);
                ReleaseItem(true);
                StartCoroutine(DashCooldown());
            }
        }

        private IEnumerator DashCooldown()
        {
            yield return new WaitForSeconds(CharactersManager._dashCooldown);
            _dashOnCooldown = false;
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (!_isDisabled)
            {
                if (collision.tag.Contains("Player") && collision != GetComponent<Collider2D>())
                {
                    if (_buttonXDown && _heldObject == null)
                    {
                        var vectorPush = (collision.transform.position - transform.position).normalized;
                        collision.GetComponent<Rigidbody2D>().AddForce(vectorPush * CharactersManager._pushSpeed);
                        collision.GetComponent<CharController>().ReleaseItem(true);
                    }
                }

                if (collision.tag.Contains("Ingredient") && _heldObject == null)
                {
                    if (_rightTriggerDown)
                    {
                        collision.GetComponent<Collider2D>().enabled = false;
                        var parent = collision.transform.parent;
                        parent.GetComponent<Collider2D>().enabled = false;
                        parent.parent = transform;
                        parent.position = transform.position;
                        _heldObject = parent;
                        collision.GetComponentInParent<Rigidbody2D>().isKinematic = true;
                    }
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!_isDisabled)
            {
                if (collision.tag.Contains("Thunder"))
                {
                    if (_disabledRoutine != null)
                    {
                        StopCoroutine(_disabledRoutine);

                    }
                    _disabledRoutine = StartCoroutine(DisableCoroutine(_disabledDuration));
                }

                if (collision.tag.Contains("Cauldron"))
                {
                    _cauldron = collision.transform;
                }
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (!_isDisabled)
            {
                if (collision.tag.Contains("Cauldron"))
                {
                    _cauldron = null;
                }
            }
        }

        private void SetSpriteDirection(float XVelocity, float YVelocity, float velocity)
        {
            _animator.SetFloat("Velocity", velocity);
            ANIMSTATE newState = _previousAnimState;
            if (Mathf.Abs(XVelocity) > Mathf.Abs(YVelocity))
            {
                if (XVelocity < 0)
                {
                    newState = ANIMSTATE.Left;
                }
                else if(XVelocity > 0)
                {
                    newState = ANIMSTATE.Right;
                }
            }
            else
            {
                if (YVelocity < 0)
                {
                    newState = ANIMSTATE.Down;
                }
                else if (YVelocity > 0)
                {
                    newState = ANIMSTATE.Up;
                }
            }

            _previousAnimState = newState;
            SetAnimInt((int)newState);
            if (_heldObject != null)
            {
                SortHeldObject(newState);
            }
        }

        private void SortHeldObject(ANIMSTATE direction)
        {
            if (direction == ANIMSTATE.Down)
            {
                _heldObject.GetComponentInChildren<SpriteRenderer>().sortingLayerName = "CollectablesFrontOfPlayer";
                _heldObject.transform.localPosition = new Vector3(0, -1.5f, 0);
            }
            if (direction == ANIMSTATE.Up)
            {
                _heldObject.GetComponentInChildren<SpriteRenderer>().sortingLayerName = "CollectablesBehindPlayer";
                _heldObject.transform.localPosition = new Vector3(0, 0, 0);
            }
            if (direction == ANIMSTATE.Left)
            {
                _heldObject.GetComponentInChildren<SpriteRenderer>().sortingLayerName = "CollectablesFrontOfPlayer";
                _heldObject.transform.localPosition = new Vector3(-1.2f, -1, 0);
            }
            if (direction == ANIMSTATE.Right)
            {
                _heldObject.GetComponentInChildren<SpriteRenderer>().sortingLayerName = "CollectablesFrontOfPlayer";
                _heldObject.transform.localPosition = new Vector3(1.2f, -1, 0);
            }

        }

        private void SetAnimInt(int i)
        {
            _animator.SetInteger("State", i);
        }

        private IEnumerator DisableCoroutine(float duration)
        {
            float speed = _speed;
            _isDisabled = true;
            _speed = 0;
            _animator.SetInteger("State", (int)ANIMSTATE.Hurt);
            yield return new WaitForSeconds(duration);
            _isDisabled = false;
            _speed = speed;
            _previousAnimState = ANIMSTATE.Down;
            SetAnimInt((int)ANIMSTATE.Down);
        }
    }
}
