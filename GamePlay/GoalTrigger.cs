using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalTrigger : MonoBehaviour
{
    public int P2Goals = 0;
    public Text scoreText2;

    void Start()
    {
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball" && Timer.GameOver == false)
        {
            P2Goals++;
            scoreText2.text = P2Goals.ToString();
        }
    }


    void Update()
    {

    }
}
