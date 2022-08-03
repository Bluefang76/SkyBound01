using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPlayer2DMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private int jumpSpeed;
    [SerializeField] private float runSpeed;
    public SpriteRenderer playerSprite;
    [SerializeField] private int TForce;


    //Jahmal
    public bool onTrampoline;
    public bool grounded;
    public float distance = 1f;
    public LayerMask groundlayer;
    public LayerMask trampolinelayer;
    public Transform feet;
    Buffed buffed;
    public bool Jumped = false;
    public float velocity;



    /* public Animator animator;*/

    float horInput;
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

        horInput = Input.GetAxis("Horizontal");
        playerSprite.flipX = horInput < 0 ? true : false;




        /*animator.SetBool("run", horInput != 0);
        animator.SetBool("onground", onground);*/

        //OnBecameInvisible();

    }

    private void FixedUpdate()
    {
        rb.AddForce(Vector2.right * horInput * runSpeed);


        // Trampoline
       onTrampoline = Physics2D.Raycast(feet.position, -Vector2.up, distance, trampolinelayer);

       // if(onTrampoline)


        if (!onTrampoline && Jumped)
            Jumped = false;

        Debug.DrawRay(feet.position, -Vector2.up * distance, Color.blue);
        velocity = rb.velocity.magnitude;

        // Ground
        grounded = Physics2D.Raycast(feet.position, -Vector2.up, distance, groundlayer);

        Debug.DrawRay(transform.position, -Vector2.up * distance, Color.red);
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        //onground = false;
    }

    
    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Trampoline")
        {

            rb.AddForce(collision.gameObject.transform.up * TForce);
            Debug.Log("Trampoline Collision");

            if (collision.gameObject.TryGetComponent(out Trampoline trampoline))
            {
                trampoline.DoEffect();
            }
            
        }*/


    }


    //multiplier and streak aspects will be added here.
