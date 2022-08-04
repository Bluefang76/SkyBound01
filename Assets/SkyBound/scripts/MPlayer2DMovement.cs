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
    //public bool grounded;

    public float distance = 1f;
    public LayerMask groundlayer;
    public LayerMask trampolinelayer;
    public Transform feet;
    Buffed buffed;
    public bool Jumped = false;
    public float velocity;

    Trampoline _trampoline;

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
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded(out _trampoline))
        {

            float mulit = 1f;
            if (_trampoline != null)
            {
                mulit = 3f;
                _trampoline.DoEffect();
                _trampoline = null;

            }

            Jump(mulit);
        }



        //Movement
        horInput = Input.GetAxis("Horizontal");
        playerSprite.flipX = horInput < 0 ? true : false;

    }
   
    private void FixedUpdate()
    {
        Run();
    }

    private void Jump(float multi)
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpSpeed * multi);
        
    }

     private void Run()
    {
        rb.AddForce(Vector2.right * horInput * runSpeed);
    }

    private bool IsGrounded(out Trampoline trampoline)
    {
        trampoline = null;
        Debug.DrawRay(feet.position, -Vector2.up * distance, Color.red);

        RaycastHit2D hit = Physics2D.Raycast(feet.position, -Vector2.up, distance, groundlayer);

        bool onGround = (hit.collider != null);

        if (onGround) {
            hit.collider.TryGetComponent(out Trampoline t);
            trampoline = t;
        }

        return onGround;
    }
}

/*private void OnCollisionEnter2D(Collision2D collision)
   {
       if (collision.gameObject.tag == "Trampoline")
       {

           rb.AddForce(collision.gameObject.transform.up * TForce);
           Debug.Log("Trampoline Collision");

           if (collision.gameObject.TryGetComponent(out Trampoline trampoline))
           {
               trampoline.DoEffect();
           }

       }

   }*/

//multiplier and streak aspects will be added here.
