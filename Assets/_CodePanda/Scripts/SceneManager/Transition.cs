using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ca.codepanda
{
	public class Transition : MonoBehaviour 
	{
        public GameObject[] _players;
        public AnimatorAutoSetState[] _animators;
        List<int> _activatedIndexes = new List<int>();

		void Update () 
		{
            for (int i = 0; i < 3; i++)
            {
			    if (InputManager.Button_A(i))
                {
                    if (!_activatedIndexes.Contains(i))
                    {
                        _activatedIndexes.Add(i);
                        Activate(i);
                    }
                    else
                    {
                        Bounce(i);
                    }
                }
                if (InputManager.Button_B(i))
                {
                    if (_activatedIndexes.Contains(i))
                    {
                        _activatedIndexes.Remove(i);
                        Quit(i);
                    }
                }
            }
		}

        private void Activate(int index)
        {
            _animators[index].Activate();
            Debug.Log("Talk to game manager to add this player to players");
        }

        private void Bounce(int index)
        {
            _animators[index].Activate();
        }

        private void Quit(int index)
        {
            _animators[index].Deactivate();
        }
    }
}
