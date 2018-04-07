using UnityEngine;
using UnityEngine.UI;

namespace ca.codepanda
{
    public class GameManager : MonoBehaviour
    {
        public delegate void PauseEvent();
        public static event PauseEvent OnPauseEvent;
        public float GameTime = 180f;
        public float minutes;
        public float seconds;
        public float PandaSpawnDelay = 60f;
        public float NextGoldenPandaTime;

        [SerializeField] private Text teamScore1;
        [SerializeField] private Text teamScore2;

        private int[] _scores = { 0, 0 };

        private const int _seed = 100;

        private bool _isPaused = false;

        public void SetPause(bool b)
        {
            _isPaused = b;
            if (OnPauseEvent != null)
                OnPauseEvent();            
        }

        public bool GetPause()
        {
            return _isPaused;
        }

        private void TogglePause()
        {
            SetPause(!_isPaused);
        }

        public void EndGame()
        {
            Debug.Log("ENDGAME");
        }

        private void Start()
        {
            _scores = new int[2] { 0, 0 };
            UpdateScoreText();
            _isPaused = false;
            
            NextGoldenPandaTime = GameTime - PandaSpawnDelay;
        }

        private void Update()
        {
            GameTime -= Time.deltaTime;
            if (GameTime <= NextGoldenPandaTime)
            {
                References.Instance._itemManager.SpawnGoldenPanda();
                NextGoldenPandaTime = GameTime - PandaSpawnDelay;
            }
            if (GameTime <= 0)            
                EndGame();    
            
            for(int i = 0; i < 3; i++)
            {
                if(InputManager.Button_Start(i))
                {
                    _isPaused = !_isPaused;
                    if (_isPaused)
                    {
                        Time.timeScale = 0;
                    }
                    else
                    {
                        Time.timeScale = 1;
                    }
                }                      
            }
            minutes = Mathf.Floor(GameTime / 60);
            seconds = Mathf.RoundToInt(GameTime % 60);
        }

        public void AddScore(int scoreAmount, int teamIndex)
        {
            _scores[teamIndex] += scoreAmount;
            UpdateScoreText();
        }

        public void UpdateScoreText()
        {
            teamScore1.text = "RED : " + _scores[0].ToString();
            teamScore2.text = "BLUE : " + _scores[1].ToString();
        }
    }
}
