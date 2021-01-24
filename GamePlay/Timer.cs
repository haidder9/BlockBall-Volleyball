using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;


public class Timer : MonoBehaviour
{
    [SerializeField] Text p1Goals;
    [SerializeField] Text p2Goals;
    [SerializeField] Text p1Winner;
    [SerializeField] Text p2Winner;
    [SerializeField] Text WinnerScore;
    [SerializeField] Text suddenDeath;
    GameObject Replay;
    public static bool GameOver = false;
    

    // Start is called before the first frame update
    void Start()
    {
        
        Replay = GameObject.FindGameObjectWithTag("PlayAgain");
        Replay.SetActive(false);
    }
    IEnumerator StartDelay()
    {
        
        yield return new WaitForSeconds(5f);

        
        p1Winner.text = "";
        p2Winner.text = "";
        WinnerScore.text = "";

        
        Replay.SetActive(true);
        


    }
   



    // Update is called once per frame
    void Update()
    {   
        
        
            int convertedGoalsP1 = 0;
            int convertedGoalsP2 = 0;

            Int32.TryParse(p1Goals.text, out convertedGoalsP1 );
            Int32.TryParse(p2Goals.text, out convertedGoalsP2);
            int Player1Goals = convertedGoalsP1;
            int Player2Goals = convertedGoalsP2;
        if (Player1Goals == 7 && GameOver == false)
            {
                p1Winner.text = "Player 1 Wins!";
                WinnerScore.text = Player1Goals.ToString() + " - " + Player2Goals.ToString();
                StartCoroutine(StartDelay());
            }
            if (Player2Goals == 7 && GameOver == false)
            {
                p2Winner.text = "Player 2 Wins!";
                WinnerScore.text = Player2Goals.ToString() + " - " + Player1Goals.ToString();
                StartCoroutine(StartDelay());
            }
            if (Player1Goals == 7 || Player2Goals == 7)
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
