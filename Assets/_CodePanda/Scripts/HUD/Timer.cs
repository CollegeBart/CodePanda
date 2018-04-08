using UnityEngine;
using UnityEngine.UI;

namespace ca.codepanda
{
    public class Timer : MonoBehaviour
    {

        [SerializeField]
        private Text m_Timer;
        private float _currentTimer = 0.0f;

        private float _stormDuration = 5f;
        private float _noStormDuration = 15f;

        private string _time;
        private string _minute;
        private string _seconds;
        private string m_seconds;

        private bool _inAStorm = true;

        private void Awake()
        {
            _minute = References.Instance._gameManager.Minutes().ToString();
            _seconds = References.Instance._gameManager.Seconds().ToString();
        }

        private void Update()
        {
            _currentTimer -= Time.deltaTime;
            _time = References.Instance._gameManager.Minutes().ToString() + ":" + References.Instance._gameManager.Seconds().ToString();
            if(References.Instance._gameManager.Seconds() < 10)
            {
                m_seconds = "0" + References.Instance._gameManager.Seconds().ToString();
                _time = References.Instance._gameManager.Minutes().ToString() + ":" + m_seconds;
            }

            int roundedValue = Mathf.RoundToInt(_currentTimer);
            m_Timer.text = _time;
        }

        void OnEnable()
        {
            MapManager.OnStormStart += OnStormStartHandler;
            MapManager.OnStormEnd += OnStormEndHandler;
        }

        void OnDisable()
        {
            MapManager.OnStormStart -= OnStormStartHandler;
            MapManager.OnStormEnd -= OnStormEndHandler;
        }

        void OnStormStartHandler()
        {
            m_Timer.color = Color.red;
        }

        void OnStormEndHandler()
        {
            m_Timer.color = Color.white;
        }
    }
}

