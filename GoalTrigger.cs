using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Scenes.GamePlay
{
    public class GoalTrigger : MonoBehaviour
    {
        [FormerlySerializedAs("P2Goals")] public int p2Goals = 0;
        public Text scoreText2;

        void Start()
        {
        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Ball") && Timer.GameOver == false)
            {
                p2Goals++;
                scoreText2.text = p2Goals.ToString();
            }
        }


        void Update()
        {

        }
    }
}
