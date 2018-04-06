﻿using UnityEngine;

namespace ca.codepanda
{
    public class CharController : MonoBehaviour
    {
        public int _playerIndex;
        public float _speed = 30f;
        public Rigidbody2D _rigidbody;
        private Collider2D _holdedObject;

        void Start()
        {
            if (_rigidbody == null)
            {
                _rigidbody = GetComponent<Rigidbody2D>();
            }
        }

        private void FixedUpdate()
        {

            if (InputManager.Button_A_Release(_playerIndex))
            {
                if (_holdedObject != null)
                {
                    _holdedObject.transform.parent = null;
                    _holdedObject.GetComponent<Rigidbody2D>().isKinematic = false;
                }
            }

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
                    collision.transform.parent = transform;
                    collision.transform.position = transform.position;
                    _holdedObject = collision;
                    collision.GetComponent<Rigidbody2D>().isKinematic = true;
                }
            }
        }
    }
}
