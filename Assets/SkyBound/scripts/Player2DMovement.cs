using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2DMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private int jumpSpeed;
    [SerializeField] private float runSpeed;
    public SpriteRenderer playerSprite;
    [SerializeField] private int TForce;
   /* public Animator animator;
    private bool onground;*/

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        //Jumping
        if (Input.GetKeyDown(KeyCode.Space) /*&& onground*/)
        {
            Jump();
        }

       

        //Movement

        float horInput = Input.GetAxis("Horizontal");

        playerSprite.flipX = horInput < 0 ? true : false;

        rb.velocity = new Vector2(horInput * runSpeed, rb.velocity.y);

        
        /*animator.SetBool("run", horInput != 0);
        animator.SetBool("onground", onground);*/

    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        //onground = false;
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Trampoline")
        {
            rb.AddForce(collision.gameObject.transform.right * TForce);
            Debug.Log("Trampoline Collision");
        }
    }
}





/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2DMovement : MonoBehaviour
{
    public float jumpspeed = 200;
    public float runspeed = 20;
    Rigidbody2D rb2d;
    public float launchforce = 10;
    public float coyoteTime = 0.2f;
    public float coyoteTimeCounter;
    private bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Trampoline")) 
        {
            rb2d.AddForce(Vector2.up * launchforce);

        }
        if (other.gameObject.CompareTag("Land"))
        {
            isGrounded = true;
        }
    }
    // Update is called once per frame
    void Update()
    {

        
       
            
          
        if (isGrounded = true &&(Input.GetKeyDown(KeyCode.Space)))
        {
            rb2d.AddForce(transform.up * jumpspeed);
            isGrounded = false;
        }

        if ((Input.GetKey(KeyCode.D)) || (Input.GetKeyDown(KeyCode.RightArrow)))
        {
            rb2d.AddForce(transform.right * runspeed);
        }
        if ((Input.GetKey(KeyCode.A)) || (Input.GetKeyDown(KeyCode.LeftArrow)))
        {
            rb2d.AddForce(-transform.right * runspeed);
        }

        if ((Input.GetKey(KeyCode.W)) || (Input.GetKeyDown(KeyCode.UpArrow)))
        {
            rb2d.AddForce(transform.forward * runspeed);
        }
        if (Input.GetKey(KeyCode.R))
        {
            transform.position = new Vector2(-1, -1);
            rb2d.velocity = (Vector2.zero);
            
        }
    }
}*/
