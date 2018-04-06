using UnityEngine;

namespace ca.codepanda
{
    public class StormTest : MonoBehaviour
    {

        private void Start()
        {
            MapManager.OnStormStart += StormStart;
            MapManager.OnStormEnd += StormEnd;

            GameManager.Instance.Init();
        }

        void Update()
        {
            for (int i = 0; i < 3; i++)
            {
                if (InputManager.Button_A(i))
                {
                    References.Instance._mapManager.StartAStorm();
                }
            }
        }

        private void StormStart()
        {
            Debug.Log("Storm start");
        }

        private void StormEnd()
        {
            Debug.Log("Storm end");
        }
	}
}
