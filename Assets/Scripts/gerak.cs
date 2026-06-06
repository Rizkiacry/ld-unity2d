using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public int velocity;
    public int jumpPow;

    Rigidbody2D rb;

    public bool turn; //Check if object turn around
    public int dir; //Store the direction which way the object turning

    public bool ground;
    public LayerMask targetLayer; 
    public Transform groundDetector;
    public float range;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void turnAround(){
        turn = !turn;
        Vector3 character = transform.localScale;
        character.x*= -1;
        transform.localScale = character;
    }

    // Update is called once per frame
    void Update()
    {
        ground = Physics2D.OverlapCircle(groundDetector.position, range, targetLayer);
        
        if (Input.GetKey(KeyCode.A)){
            rb.velocity = new Vector2(-velocity, rb.velocity.y);
            dir = -1;
        }
        else if (Input.GetKey(KeyCode.D)){
            rb.velocity = new Vector2(velocity, rb.velocity.y);
            dir = 1;
        }
        else {
            rb.velocity = new Vector2(0, rb.velocity.y);
            dir = 0;
        }

        if (ground == true && Input.GetKeyDown(KeyCode.Space)||Input.GetKeyDown(KeyCode.W)){
            rb.velocity = new Vector2(rb.velocity.x, jumpPow);
        }

        if(dir > 0 && turn){
            turnAround();
        }else if(dir < 0 && !turn){
            turnAround();
        }
    }
}
