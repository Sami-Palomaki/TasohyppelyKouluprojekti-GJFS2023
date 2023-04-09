using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float movePower;
    public float jumpPower;
    public Camera cam;
    public Animator animator;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public Rigidbody rb;
    public float groundCheckRadius = 0.1f;
    public float gravity = 9.8f;
    public bool wKeypressed = false;
    float xInput;
    bool grounded = false;
    bool isTouchingWall = false;
    bool jump = false;
    bool isFacingRight = true;
    


    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        
        // Pelaaja ei leiju niin kauaa ilmassa
        Physics.gravity = new Vector3(0, -50, 0);
    }

    // Update is called once per frame
    void Update()
    {
        GetInputs();
        animator.SetFloat("Speed", Mathf.Abs(xInput));
        JumpInput();
    }

    private void FixedUpdate() 
    {
        Movement();
        JumpForce();

        // Käännä pelaajaa liikkumisen suuntaan
        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            isFacingRight = false;
        }
        else if(Input.GetAxis("Horizontal") > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            isFacingRight = true;
        }

        // Ground-check
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    private void LateUpdate() 
    {
        CameraFollow();    
    }

    void GetInputs()
    {
        xInput = Input.GetAxis("Horizontal");
    }

    void Movement()
    {
        // Vector3 movementVector = new Vector3(xInput * movePower, 0, 0);
        // rb.AddForce(movementVector, ForceMode.Impulse);
        Vector3 velocity = rb.velocity;
        velocity.x = xInput * movePower;
        rb.velocity = velocity;
    }

    void JumpInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            jump = true;
            animator.SetBool("IsJumping", true); 
        }
    }

    void JumpForce()
    {
        if(grounded == true && jump == true)
        {
            rb.AddForce(Vector3.up * jumpPower * gravity);
            jump = false;
            onLanding();
        }
    }

    void CameraFollow()
    {
        Vector3 followPosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -10);
        cam.transform.position = followPosition;
    }

    public void onLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }

        if (collision.gameObject.tag == "Wall")
        {
            isTouchingWall = true;
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = false;
        }

        if (collision.gameObject.tag == "Wall")
        {
            isTouchingWall = false;
        }
    }

    private void OnCollisionStay(Collision other) 
    {
        grounded = true;    

    }
}
