using UnityEngine;

namespace ca.codepanda
{
	public class GameManager : Singleton<GameManager>
    {
        // Prevents the creator from being used
        protected GameManager() { }

        private const int _seed = 100;

        private bool _IsPaused;
        public bool _isPaused
        {
            get
            {
                return _IsPaused;
            }
            set
            {
                _IsPaused = value;
            }
        }

        public void Init()
        {
            Debug.Log("New game started");
            _isPaused = false;
            Random.InitState(_seed);

            References.Instance._mapManager.Init();
        }
	}
}
