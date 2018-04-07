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

        public int _mapWidth = 20;
        public int _mapHeight = 11;

        float _mapMidWidth;
        float _mapMidHeight;

        private float _StormDelay = 15f;
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
            _mapMidWidth = (_mapWidth / 2);
            _mapMidHeight = (_mapHeight / 2);
            StartCoroutine(FirstStorm());
        }

        private IEnumerator FirstStorm()
        {
            yield return new WaitForSeconds(_StormDelay);
            StartAStorm();
        }

        public void StartAStorm()
        {
            StartCoroutine(Storm());
            References.Instance._screenShake.BasicShake();
        }

        public IEnumerator Storm()
        {
            if (OnStormStart != null)
            {
                OnStormStart();
            }

            _stormDuration = _maxStormDuration;
            float _thunderDelay = 0;

            int numberOfItemsToSpawn = References.Instance._itemManager._itemsToSpawn;
            Stack<float> timeToSpawnItems = new Stack<float>();
            float lastTimeItemSpawn = 0.1f;
            for (int i = 0; i < numberOfItemsToSpawn; i++)
            {
                timeToSpawnItems.Push(Random.Range(lastTimeItemSpawn, _stormDuration));
                lastTimeItemSpawn = timeToSpawnItems.Peek();
            }

            while (_stormDuration > 0)
            {
                if (_thunderDelay <= 0)
                {
                    float x = Random.Range(-_mapMidWidth, _mapMidWidth);
                    float y = Random.Range(-_mapMidHeight, _mapMidHeight);
                    Vector2 ThunderHit = new Vector2(x, y);

                    GameObject go = Instantiate(_thunderPrefab, References.Instance._dynamic);
                    go.transform.position = ThunderHit;

                    _thunderDelay = Random.Range(.01f, .5f);
                }

                if (timeToSpawnItems.Count > 0 && _stormDuration <= timeToSpawnItems.Peek())
                {
                    References.Instance._itemManager.SpawnNewItem();
                    timeToSpawnItems.Pop();
                }

                _stormDuration -= Time.deltaTime;
                _thunderDelay -= Time.deltaTime;
                yield return null;
            }

            if (OnStormEnd != null)
            {
                OnStormEnd();
            }

            yield return new WaitForSeconds(_StormDelay);
            StartAStorm();
        }

        public void EndGameStorm()
        {
            StopAllCoroutines();
            StartCoroutine(EndGameStormRoutine());
        }

        private IEnumerator EndGameStormRoutine()
        {
            if (OnStormStart != null)
            {
                OnStormStart();
            }

            _stormDuration = _maxStormDuration * 2;
            float _thunderDelay = 0;

            while (_stormDuration > 0)
            {
                if (_thunderDelay <= 0)
                {
                    float x = Random.Range(-_mapMidWidth, _mapMidWidth);
                    float y = Random.Range(-_mapMidHeight, _mapMidHeight);
                    Vector2 ThunderHit = new Vector2(x, y);

                    GameObject go = Instantiate(_thunderPrefab, References.Instance._dynamic);
                    go.transform.position = ThunderHit;

                    _thunderDelay = Random.Range(.01f, .25f);
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
