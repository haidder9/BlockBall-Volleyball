using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalTrigger2 : MonoBehaviour
{
    public int P1Goals = 0;
    public Text scoreText;

    void Start()
    {
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball" && Timer.GameOver == false )
        {
            P1Goals++;
            scoreText.text = P1Goals.ToString();         
        }
      
    }


    void Update()
    {
       
    }
}
