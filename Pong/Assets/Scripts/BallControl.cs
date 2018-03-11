using UnityEngine;
using System.Collections;

public class BallControl : MonoBehaviour
{
    float ballSpeed = 550;
    private Rigidbody2D rb;

    // holds the ball in position when reset
    IEnumerator WaitForBall() {
        yield return new WaitForSeconds(3f);
        MoveBall();
    }

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(WaitForBall());
        StartCoroutine(ResetBall());
    }


    // Update is called once per frame; keeps velocity at consistent speed 
    private void Update()
    {
        float xVel = GetComponent<Rigidbody2D>().velocity.x;
     
        if (xVel < 10 && xVel > 0)
        {
            xVel = 10;
        } else if (xVel > -10 && xVel < 0) {
            xVel = -10;
        }
    }
    
    // collision set
    void OnCollisionEnter2D(Collision2D colInfo)
    {
        if (colInfo.collider.tag == "Player")
        {
            float velY = rb.velocity.y;
            rb.velocity = new Vector2(rb.velocity.x, velY/2 + colInfo.collider.GetComponent<Rigidbody2D>().velocity.y/3);

            FindObjectOfType<AudioManager>().Play("hit");
        }
    }

    // resets the ball
    IEnumerator ResetBall()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, rb.velocity.x);
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, rb.velocity.y);

        transform.position = new Vector3(transform.position.x, 0);
        transform.position = new Vector3(transform.position.y, 0);

        MoveBall();
        yield return new WaitForSeconds(3f);
    }

    // movement for the ball
    void MoveBall()
    {
        rb = GetComponent<Rigidbody2D>();
        float randomNumber = Random.Range(0, 2);
        if (randomNumber <= 0.5)
        {
            rb.AddForce(new Vector2(ballSpeed, 50));
        }
        else
        {
            rb.AddForce(new Vector2(-ballSpeed, -50));
        }
    }
}
