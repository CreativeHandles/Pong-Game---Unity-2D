using UnityEngine;

public class PlayerControls : MonoBehaviour {

    public KeyCode moveUp;
    public KeyCode moveDown;

    public float speed = 10f;
    private Rigidbody2D rb2D; //the Rigidbody inside our object 


    // Use this for initialization
    void Start () {
        // get access to rigibody
        rb2D = GetComponent<Rigidbody2D>();  // Getting Access to the Rigidbody 
    }

    void Update()
    {
        if (Input.GetKey(moveUp))
        {
            rb2D.velocity = new Vector2(0, speed);
        }
        else if (Input.GetKey(moveDown))
        {
            rb2D.velocity = new Vector2(0, -speed);
        }
        else
        {
            rb2D.velocity = Vector2.zero;
        }
    }
}

