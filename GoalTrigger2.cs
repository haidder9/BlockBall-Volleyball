using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Scenes.GamePlay
{
    public class GoalTrigger2 : MonoBehaviour
    {
        [FormerlySerializedAs("P1Goals")] public int p1Goals = 0;
        public Text scoreText;

        void Start()
        {
        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Ball") && Timer.GameOver == false )
            {
                p1Goals++;
                scoreText.text = p1Goals.ToString();         
            }
      
        }


        void Update()
        {
       
        }
    }
}
