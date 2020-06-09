using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScript : MonoBehaviour
{

    // Initialize paddle speed variable
    public float speed;

    // Initialize edges
    public float rightScreenEdge;
    public float leftScreenEdge;

    public GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gm.gameOver){
            return;
        }
        //0 input if "a/d" or "left/right arrows" haven't be posted
        float horizontal = Input.GetAxis("Horizontal");
        
        transform.Translate (Vector2.right * horizontal * Time.deltaTime * speed);

        // Current position in the x axis
        // If x goes past the edge, change position to not move
        if(transform.position.x < leftScreenEdge){
            transform.position = new Vector2(leftScreenEdge, transform.position.y);
        }
        if(transform.position.x > rightScreenEdge){
            transform.position = new Vector2 (rightScreenEdge, transform.position.y);
        }
    }
}
