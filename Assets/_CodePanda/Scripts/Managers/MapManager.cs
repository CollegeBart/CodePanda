﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ca.codepanda
{
	public class MapManager : MonoBehaviour
    {
        public delegate void StormEnd();
        public static event StormEnd OnStormEnd;

        public delegate void StormStart();
        public static event StormStart OnStormStart;

        public const int _mapWidth = 1980;
        public const int _mapHeight = 1080;

        private float _scale = .1f;
        public float _mapMidWidth;
        public float _mapMidHeight;

        public const float _maxStormDuration = 5f;
        private float _StormDuration = 0;
        public float _stormDuration
        {
            get
            {
                return _StormDuration;
            }
            private set
            {
                _StormDuration = value;
            }
        }

        public GameObject _thunderPrefab;

        private void Start()
        {
            _mapMidWidth = (_mapWidth / 2) * _scale;
            _mapMidHeight = (_mapHeight / 2) * _scale;
        }

        public void Init()
        {

        }

        public void StartAStorm()
        {
            StartCoroutine(Storm());
        }

        public IEnumerator Storm()
        {
            if (OnStormStart != null)
            {
                OnStormStart();
            }

            _stormDuration = _maxStormDuration;
            float _thunderDelay = 0;

            while (_stormDuration > 0)
            {
                if (_thunderDelay <= 0)
                {
                    float x = Random.Range(-_mapMidWidth, _mapMidWidth);
                    float y = Random.Range(-_mapMidHeight, _mapMidHeight);
                    Vector2 ThunderHit = new Vector2(x, y);

                    GameObject go = Instantiate(_thunderPrefab);
                    go.transform.position = ThunderHit;


                    _thunderDelay = Random.Range(.01f, 1f);
                }
                _stormDuration -= Time.deltaTime;
                _thunderDelay -= Time.deltaTime;
                yield return null;
            }

            if (OnStormEnd != null)
            {
                OnStormEnd();
            }
        }
    }
}
