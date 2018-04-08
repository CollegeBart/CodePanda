using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

namespace ca.codepanda
{
	public class Transition : MonoBehaviour 
	{
        private int _state = 0;
        private string _sceneName = "CodePanda2018 - Alex";

        public Animator _anim;

        public AnimatorAutoSetState[] _animators;
        private bool[] _activated;

        public SpriteRenderer[] _rends;
        public Sprite _startToStart;
        public Sprite _aToPlay;
        public Sprite _bToQuit;
        public AudioSource StartButtonSound;
        public AudioSource PayerJoinSound;

        private void Start()
        {
            _activated = new bool[] { false, false, false, false };
            if (References.Instance.state == 1)
            {
                MenuIn();
            }
        }

        void Update ()
		{
            for (int i = 0; i < 4; i++)
            {
			    if (InputManager.Button_A(i))
                {
                    if (_state == 1)
                    {
                        Activate(i);
                    }
                }

                if (InputManager.Button_B(i))
                {
                    if (_state == 1 && !_activated[i])
                    {
                        MenuOut();
                    }
                    else if (_state == 1)
                    {
                        Quit(i);
                    }
                }

                if (InputManager.Button_Start(i))
                {
                    if (_state == 1)
                    {
                        bool hasPlayer = false;
                        for (int j = 0; j < 4; j++)
                        {
                            if (_activated[j] == true)
                            {
                                hasPlayer = true;
                                break;
                            }
                        }
                        if (hasPlayer)
                        {
                            MenuPlay();
                        }
                    }
                    else if (_state == 0)
                    {
                        MenuIn();
                    }
                    else if (_state == 2)
                    {
                        ChangeScene();
                    }
                }
            }
		}

        private void MenuIn()
        {
            for (int i = 0; i < 4; i++)
            {
                Quit(i);
            }
            _state = 1;
            _anim.SetInteger("state", 1);
            StartButtonSound.Play();
        }

        private void MenuOut()
        {
            _state = 0;
            References.Instance.state = 0;
            _anim.SetInteger("state", 0);
        }

        private void MenuPlay()
        {
            _state = 2;
            _anim.SetInteger("state", 2);
        }

        private void ChangeScene()
        {
            References.Instance.state = 1;
            SceneManager.LoadScene(_sceneName);
        }

        private void Activate(int index)
        {
            PayerJoinSound.Play();
            _rends[index].sprite = _bToQuit;
            _activated[index] = true;
            _animators[index].Activate();
        }

        private void Quit(int index)
        {
            _rends[index].sprite = _aToPlay;
            _activated[index] = false;
            _animators[index].Deactivate();
        }
    }
}
