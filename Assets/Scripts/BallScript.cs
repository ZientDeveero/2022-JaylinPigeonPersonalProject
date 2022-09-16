using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool inPlay;
    public Transform paddle;
    public float speed;
    public Transform redExplode;
    public Transform whiteExplode;
    AudioSource audio;
    AudioSource breakAudio;
    public GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        speed = 350;
        rb = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.gameOver)
        {
            rb.velocity = Vector2.zero;
            return;
        }
        //if game has started or player lost life, put the ball on the paddle
        if (!inPlay)
        {
            transform.position = paddle.position;
        }
        //if spacebar is pressed, make the ball move
        if (Input.GetButtonDown("Jump") && !inPlay)
        {
            inPlay = true;
            rb.AddForce(Vector2.up * speed);
        }
    }
    //if the ball has hit the bottom, stop the ball and help set the ball on the paddle
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bottom"))
        {
            rb.velocity = Vector2.zero;
            inPlay = false;
        }
        //Lose a life as well
        gm.ChangeLife();
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.transform.CompareTag("Brick"))
        {
            audio.Play();
        }
        //if the paddle hits a brick, break it
        if (other.transform.CompareTag("Brick"))
        {
            //breakAudio.Play();
            //trigger and destroy explosion
            Transform newRedExplosion = Instantiate(redExplode, other.transform.position, other.transform.rotation);
            Transform newWhiteExplosion = Instantiate(whiteExplode, other.transform.position, other.transform.rotation);
            Destroy(newRedExplosion.gameObject, 2.5f);
            Destroy(newWhiteExplosion.gameObject, 2.5f);
            Destroy(other.gameObject);
            //update the score and number of bricks
            gm.ChangeScore();
            gm.UpdateBrickNumber();
        }
    }
}
