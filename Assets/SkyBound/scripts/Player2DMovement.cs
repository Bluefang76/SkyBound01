using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2DMovement : MonoBehaviour
{
    public float distance = 1f;
    public LayerMask groundlayer;
    public LayerMask tramplayer;
    public Transform feet;

    [Header ("Jump")]
    public float jumpForce = 7;
    public float jumpspeed = 200;
    public float runspeed = 20;

    [Space]

    [Header ("Move")]
    public float launchforce = 100;
    public float coyoteTime = 0.2f;
    public float coyoteTimeCounter;
    public bool isTramped;
    public float maxjumptime = 0.15f;
    public float velocity;
    public float multiplier;

    [Space]

    public float minMulti;
    public float maxMulti;
    public float jumpCount;
    public float maxJumpCount;
    public AnimationCurve multiCurve;

    private bool isGrounded;
    Rigidbody2D rb2d;

    bool hasJumped = false;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isGrounded &&(Input.GetKeyDown(KeyCode.Space)))
        {
            rb2d.AddForce(transform.up * jumpspeed);
            
        }

        if (Input.GetKey(KeyCode.Space) && !isGrounded && coyoteTimeCounter < maxjumptime) 
        {
            rb2d.AddForce(transform.up * jumpForce);
        }

        if (!isGrounded || !isTramped)
        {
            coyoteTimeCounter += Time.deltaTime;
        }
       

        if (isGrounded || isTramped)
        {
            coyoteTimeCounter = 0;
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

    public float GetJumpMultiplier()
    {
        float jumpMultiplier = 0;

        float jumpPercent = Mathf.Clamp01(jumpCount/maxJumpCount);

        float multiValue = multiCurve.Evaluate(jumpPercent);

        jumpMultiplier = Mathf.Lerp(minMulti, maxMulti, multiValue);

        return jumpMultiplier;
    }

    private void FixedUpdate()
    {
        // Trampoline
        isTramped = Physics2D.Raycast(feet.position, -Vector2.up, distance, tramplayer);

        if (!isTramped && hasJumped)
            hasJumped = false;


        Debug.DrawRay(feet.position, -Vector2.up * distance, Color.blue);
        velocity = rb2d.velocity.magnitude;
        if (isTramped && !hasJumped)
        {
            jumpCount++;
            hasJumped = true;
           

            Debug.Log("GetJumpMultiplier: " + GetJumpMultiplier());
            rb2d.AddForce(Vector2.up * velocity * GetJumpMultiplier(), ForceMode2D.Impulse);
        }


        // Grounding
        isGrounded = Physics2D.Raycast(feet.position, -Vector2.up, distance, groundlayer);

        Debug.DrawRay(transform.position, -Vector2.up * distance, Color.red);    
    }
}