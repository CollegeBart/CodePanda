﻿using UnityEngine;

namespace ca.codepanda
{
    public class CharacterController : MonoBehaviour
    {
        public int _playerIndex;
        public float _speed;
        private Rigidbody2D _rigidbody;

        void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            float XVelocity = InputManager.L_XAxis(_playerIndex) * _speed;
            float YVelocity = InputManager.L_YAxis(_playerIndex) * -1 * _speed;

            _rigidbody.velocity = new Vector2(XVelocity, YVelocity);
        }
    }
}
