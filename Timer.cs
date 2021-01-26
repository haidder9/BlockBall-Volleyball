using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Scenes.GamePlay
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] Text p1Goals;
        [SerializeField] Text p2Goals;
        [SerializeField] Text p1Winner;
        [SerializeField] Text p2Winner;
        [FormerlySerializedAs("WinnerScore")] [SerializeField] Text winnerScore;
        [SerializeField] Text suddenDeath;
        GameObject _replay;
        public static bool GameOver = false;
    

        // Start is called before the first frame update
        void Start()
        {
        
            _replay = GameObject.FindGameObjectWithTag("PlayAgain");
            _replay.SetActive(false);
        }
        IEnumerator StartDelay()
        {
        
            yield return new WaitForSeconds(5f);

        
            p1Winner.text = "";
            p2Winner.text = "";
            winnerScore.text = "";

        
            _replay.SetActive(true);
        


        }
   



        // Update is called once per frame
        void Update()
        {
            Int32.TryParse(p1Goals.text, out var convertedGoalsP1 );
            Int32.TryParse(p2Goals.text, out var convertedGoalsP2);
            int player1Goals = convertedGoalsP1;
            int Player2Goals = convertedGoalsP2;
            if (player1Goals == 7 && GameOver == false)
            {
                p1Winner.text = "Player 1 Wins!";
                winnerScore.text = player1Goals.ToString() + " - " + Player2Goals.ToString();
                StartCoroutine(StartDelay());
            }
            if (Player2Goals == 7 && GameOver == false)
            {
                p2Winner.text = "Player 2 Wins!";
                winnerScore.text = Player2Goals.ToString() + " - " + player1Goals.ToString();
                StartCoroutine(StartDelay());
            }
            if (player1Goals == 7 || Player2Goals == 7)
            {
                GameOver = true;
                Vector2 ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(ray, Vector2.zero);
                if (Input.GetMouseButtonDown(0) && hit.collider.tag == "PlayAgain")
                {
                    GameOver = false;
                    SceneManager.LoadScene(1);
                }
            }


        }
        
    }
}
