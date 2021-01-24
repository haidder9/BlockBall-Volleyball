using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class BallPos : MonoBehaviour
{
    Vector2 originalPos;
    Quaternion originalRotation;


    void Start()
    {
        originalPos = transform.position;
        originalRotation = transform.rotation;
    }
    IEnumerator StartDelay()
    {

        yield return new WaitForSeconds(1.5f);
        gameObject.transform.position = new Vector2(6, 3);
        gameObject.transform.rotation = originalRotation;


    }
    IEnumerator StartDelay1()
    {

        yield return new WaitForSeconds(1.5f);
        gameObject.transform.position = originalPos;
        gameObject.transform.rotation = originalRotation;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "goal")
        {
            gameObject.transform.position = new Vector2(6, 6);
            StartCoroutine(StartDelay());
            

        }
        if (collision.gameObject.tag == "goal2")
        {
            gameObject.transform.position = new Vector2(-6, 6);
            StartCoroutine(StartDelay1());
            

        }

    }
   
    // Update is called once per frame
    void Update()
    {
        
    }
}
