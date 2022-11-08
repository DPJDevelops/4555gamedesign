
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    // Member Variables 
    public Rigidbody rb;
    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;
    public float jumpForce = 200f;
    public bool moveRight;
    public bool moveLeft;
    public bool jump;
     public Vector3 startPos;
     Animator anim;

    // Checking for user input and store inside varables 
    public void Update()
    {
        
        if (Input.GetKey("a"))
        {
            moveLeft = true;
            moveRight = false;
        }
        else if (Input.GetKey("space"))
        {
            anim.SetTrigger("Slash");
        }
        else if (Input.GetKey("d"))
        {
            moveRight = true;
            moveLeft = false;
        }
        else
        {
            moveRight = false;
            moveLeft = false;
            jump = false;
        }
    }
    // Update is called once per frame, FixedUpdate when adding Phyics.
    void FixedUpdate()
    {
        // Adding forward force
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);
        // checking statements true 
        if (moveRight == true)
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (moveLeft == true)
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (jump == true)
        {
            rb.AddForce(0, jumpForce * Time.deltaTime, 0, ForceMode.VelocityChange);
        }
        if (rb.position.y < -1 )
        {
            FindObjectOfType<GameManager>().Endgame();
        }
    }

    void Start(){
        anim = GetComponentInChildren<Animator>(); 

    }
    
}
