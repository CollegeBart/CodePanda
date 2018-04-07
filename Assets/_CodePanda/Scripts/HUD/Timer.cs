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
            _minute = References.Instance._gameManager.minutes.ToString();
            _seconds = References.Instance._gameManager.seconds.ToString();
        }

        private void Update()
        {
            _currentTimer -= Time.deltaTime;
            _time = References.Instance._gameManager.minutes.ToString() + ":" + References.Instance._gameManager.seconds.ToString();
            if(References.Instance._gameManager.seconds < 10)
            {
                m_seconds = "0" + References.Instance._gameManager.seconds.ToString();
                _time = References.Instance._gameManager.minutes.ToString() + ":" + m_seconds;
            }
            if (_currentTimer <= 0 && _inAStorm == true)
            {
                _currentTimer = _stormDuration;
                m_Timer.color = Color.cyan;
                _inAStorm = false;
            }
            else if (_currentTimer <= 0 && _inAStorm == false)
            {
                _currentTimer = _noStormDuration;
                m_Timer.color = Color.red;
                _inAStorm = true;
            }

            int roundedValue = Mathf.RoundToInt(_currentTimer);
            m_Timer.text = _time;

        }
    }
}

