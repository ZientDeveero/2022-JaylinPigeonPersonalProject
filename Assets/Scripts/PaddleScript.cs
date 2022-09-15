using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScript : MonoBehaviour
{
    public float speed;
    public float rightBoundary;
    public float leftBoundary;
    public GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.gameOver)
        {
            return;
        }
        float horizontal = Input.GetAxis("Horizontal");
        //Needs to be multiplied by time just in case framerate changes
        transform.Translate(Vector2.right * horizontal * Time.deltaTime * speed);
        if(transform.position.x < leftBoundary)
        {
            transform.position = new Vector2(leftBoundary, transform.position.y);
        }
        if(transform.position.x > rightBoundary)
        {
            transform.position = new Vector2(rightBoundary, transform.position.y);
        }
    }
}
