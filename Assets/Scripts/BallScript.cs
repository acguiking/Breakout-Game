using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool inPlay;
    public Transform paddle;
    public float speed;

    // initialize count of bricks
    public int scarletCount = 19;
    public int grayCount = 38;


    // variables for explotion effect per brick color
    public Transform scarletExplosion;
    public Transform grayExplosion;

    // audio variable
    AudioSource audio;

    // needed to keep track of score and lives
    public GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D> ();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gm.gameOver){
            // set velocity/force to ball 0
            rb.velocity = Vector2.zero;
            return;
        }
        // Reset position if lose/win/start conditions have been meter
        if(!inPlay) {
            transform.position = paddle.position;
        }

        // Makes sure space can only get pressed once to start
        if(Input.GetButtonDown("Jump") && !inPlay){
            inPlay = true;
            rb.AddForce (Vector2.up * speed);
        }

        if(Input.GetButtonDown("Cancel")){
            Application.Quit();
        }
    }

    //-----------------------------------------------
    //
    //LOSE CONDITION
    //
    // Built in function when it enters the bottom
    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("bottom")){

            // set velocity/force to ball 0
            rb.velocity = Vector2.zero;

            // Restart game if lose condition has been met
            inPlay = false;

            gm.UpdateLives(-1);
        }

    }

    //function to determine if ball has collided with a brick
    void OnCollisionEnter2D(Collision2D other){

        // separate if statements for each type of brick
        if(other.transform.CompareTag("Scarlet Brick")){
            Transform newExplosion = Instantiate(scarletExplosion, other.transform.position, other.transform.rotation);
            Destroy(newExplosion.gameObject, 2.5f);
            Destroy(other.gameObject);
            gm.UpdateScarlet(-1);
            scarletCount--;
            if (scarletCount*2 <= grayCount)
                gm.UpdateScore(2);
            else
                gm.UpdateScore(1);
            gm.UpdateNumberOfBricks();
            audio.Play();
        }
        if(other.transform.CompareTag("Gray Brick")){
            Transform newExplosion = Instantiate(grayExplosion, other.transform.position, other.transform.rotation);
            Destroy(newExplosion.gameObject, 2.5f);
            Destroy(other.gameObject);
            gm.UpdateGray(-1);
            grayCount--;
            gm.UpdateScore(1);
            gm.UpdateNumberOfBricks();
            audio.Play();
        }
        
    }
}
