using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D rb;
    private CircleCollider2D circleCollider2D;

    private void Awake()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        circleCollider2D = transform.GetComponent<CircleCollider2D>();
    }



    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Player2")
        {
            audioSource.Play();
        }
        if (collision.collider.gameObject.tag == "ExtraHit2")
        {
            moveSpeed = -23f;
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y - 5);

      }
        if (collision.collider.gameObject.tag == "ExtraHit1")
        {
            moveSpeed = +23f;
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y - 5);

        }
        if (collision.collider.gameObject.tag == "Face1")
        {
            rb.velocity = new Vector2(rb.velocity.x + 5, rb.velocity.y + 10);

        }
        if (collision.collider.gameObject.tag == "Face2")
        {
            rb.velocity = new Vector2(rb.velocity.x - 5, rb.velocity.y + 10);

        }
        if (collision.collider.gameObject.tag == "Wall1")
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + 2);
        }
        if (collision.collider.gameObject.tag == "Wall2")
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + 2);
        }
        if (collision.collider.gameObject.tag == "Ceiling")
        {
            rb.velocity = new Vector2(rb.velocity.x+1 ,rb.velocity.y + 5);
        }
        if (collision.collider.gameObject.tag == "Ceiling2")
        {
            rb.velocity = new Vector2(rb.velocity.x-1,rb.velocity.y +5);
        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "goal" || collision.gameObject.tag == "goal2")
        {
            rb.velocity = new Vector2(0, 0);
            rb.angularVelocity = 0;
        }
    }



}