using UnityEngine;
using System.Collections.Generic;

namespace ca.codepanda
{
    public class CharactersManager : MonoBehaviour
    {
        public const float _dashCooldown = 3f;
        public const int _dashSpeed = 1500;
        public const int _pushSpeed = 2500;

        public const float _baseSpeed = 100f;

        public GameObject[] _objects;
        public Transform[] _transforms;
        public CharController[] _controllers;
        public SpriteRenderer[] _renders;

        Dictionary<Transform, SpriteRenderer> dict = new Dictionary<Transform, SpriteRenderer>();

	    void Start ()
        {
            _objects = GameObject.FindGameObjectsWithTag("Player");

            _transforms = new Transform[_objects.Length];
            _controllers = new CharController[_objects.Length];
            _renders = new SpriteRenderer[_objects.Length];

            for (int i = 0; i < _objects.Length; i++)
            {
                _transforms[i] = _objects[i].transform;
                _controllers[i] = _objects[i].GetComponent<CharController>();
                _renders[i] = _objects[i].GetComponent<SpriteRenderer>();
            }
	    }
	
	    void Update ()
        {
            for (int i = 0; i < _controllers.Length; i++)
            {
                _controllers[i].CustomUpdate();
            }
            SortLayerOrder();
	    }

        private void SortLayerOrder()
        {
            List<int> indexOrder = new List<int>();
            // Lowest y is highest order in layer
            while (indexOrder.Count != _objects.Length)
            {
                int j = 0;
                float lowestY = 100;
                for (int i = 0; i < _objects.Length; i++)
                {
                    if (!indexOrder.Contains(i))
                    {
                        if (_transforms[i].position.y < lowestY)
                        {
                            lowestY = _transforms[i].position.y;
                            j = i;
                        }
                    }
                }
                indexOrder.Add(j);
            }

            for (int i = 0; i < indexOrder.Count; i++)
            {
                _renders[indexOrder[i]].sortingOrder = _objects.Length - i;
            }
        }
    }
}
