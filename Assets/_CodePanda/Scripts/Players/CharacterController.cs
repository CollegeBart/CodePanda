using UnityEngine;

namespace ca.codepanda
{
    public class CharacterController : MonoBehaviour
    {
        public int playerNumber;
        public float speed;
        private Rigidbody2D rigidbody2D;

        void Start()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();

        }

        void Update()
        {

        }

        private void FixedUpdate()
        {
            if (playerNumber==1)
            {
                Debug.Log(InputManager.L_XAxis(playerNumber));
                Debug.Log(InputManager.L_YAxis(playerNumber));

            }

            float XVelocity = InputManager.L_XAxis(playerNumber) * speed;
            float YVelocity = InputManager.L_YAxis(playerNumber) * -1 * speed;

            rigidbody2D.velocity = new Vector2(XVelocity, YVelocity);
        }
    }
}
