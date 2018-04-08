using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace ca.codepanda
{
    public class GameManager : MonoBehaviour
    {
        private const string _sceneName = "Menu";

        public float GameTime = 180f;
        public float PandaSpawnDelay = 30f;
        private float NextGoldenPandaTime;

        [SerializeField] private Text teamScore1;
        [SerializeField] private Text teamScore2;

        [System.NonSerialized] public int[] _scores = { 0, 0 };

        private const int _seed = 100;

        private bool _gameDone = false;

        public void EndGame()
        {
            if (!_gameDone)
            {
                References.Instance._mapManager.EndGameStorm();
                _gameDone = true;
            }
        }

        private void Awake()
        {
            GameTime = 180f;
            NextGoldenPandaTime = GameTime - PandaSpawnDelay;
        }

        private void Start()
        {
            _scores = new int[2] { 0, 0 };
            UpdateScoreText();
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
            
            if (_gameDone)
            {
                for(int i = 0; i < 3; i++)
                {
                    if (InputManager.Button_Start(i))
                    {
                        SceneManager.LoadScene(_sceneName);
                    }
                }
            }
        }

        public void AddScore(int scoreAmount, int teamIndex)
        {
            _scores[teamIndex] += scoreAmount;
            UpdateScoreText();
        }

        public void UpdateScoreText()
        {
            teamScore1.text = _scores[0].ToString();
            teamScore2.text = _scores[1].ToString();
        }

        public float Minutes()
        {
            float i = Mathf.Floor(GameTime / 60);
            if (GameTime < 0)
            {
                i = 0;
            }
            return i;
        }

        public float Seconds()
        {
            float i = Mathf.Floor(GameTime % 60);
            if (GameTime < 0)
            {
                i = 0;
            }
            return i;
        }
    }
}
