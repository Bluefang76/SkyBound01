using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerNumber{
    Player1,
    Player2,
}
public class Player2DMovement : MonoBehaviour
{
    public PlayerNumber playerNumber;
    public float distance = 1f;
    public LayerMask groundlayer;
    public LayerMask tramplayer;
    public Transform feet;
    Buffed buffed;

    [Header ("Jump")]
    public float jumpForce = 7;
    public float intialJumpForce = 200;
    public float runspeed = 20;

    [Space]

    [Header ("Move")]
    //public float launchforce = 100;
    private float coyoteTime = 0.2f;
    public float jumpTime;
    public bool isTramped;
    private float maxjumptime = 0.15f;
    public float velocity;
    public float JumpMultiplier;
    //public float upSpeed = velocity * 2;
    [Space]

    public float minMulti;
    public float maxMulti;
    public float jumpCount;
    public float maxJumpCount;
    public AnimationCurve multiCurve;

    public bool isGrounded;
    Rigidbody2D rb2d;

    public bool hasJumped = false;

    public float horInput;

    bool isJumping;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        buffed = FindObjectOfType<Buffed>();
    }

    void Update()
    {
        horInput = Input.GetAxis("Horizontal");

        // Intial Jump
        if (isGrounded &&(Input.GetKeyDown(KeyCode.Space)))
        {
            rb2d.AddForce(transform.up * intialJumpForce);           
        }

        isJumping = (Input.GetKey(KeyCode.Space) && !isGrounded && jumpTime < maxjumptime);

        if (!isGrounded && !isTramped)
        {
            jumpTime += Time.deltaTime;
        }   

        if (isGrounded || isTramped)
        {
            jumpTime = 0;
        }

        // Restart
        if (Input.GetKey(KeyCode.R))
        {
            transform.position = new Vector2(-1, -1);
            rb2d.velocity = (Vector2.zero);
            jumpCount = 0;
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
        RunJump();
        TrampJump();
    }

    void RunJump()
    {
        rb2d.AddForce(transform.right * horInput * runspeed);

        if (isJumping)
            rb2d.AddForce(transform.up * jumpForce);

        // Grounding
        isGrounded = Physics2D.Raycast(feet.position, -Vector2.up, distance, groundlayer);

        Debug.DrawRay(transform.position, -Vector2.up * distance, Color.red);
    }

    void TrampJump()
    {
        // Trampoline
        RaycastHit2D hit = Physics2D.Raycast(feet.position, -Vector2.up, distance, tramplayer);
        isTramped = (hit.collider != null);
        Trampoline trampoline = !isTramped ? null : hit.collider.GetComponent<Trampoline>();

        if (!isTramped && hasJumped)
            hasJumped = false;

        Debug.DrawRay(feet.position, -Vector2.up * distance, Color.blue);
        velocity = rb2d.velocity.magnitude;

        if (isTramped && buffed.GetInput(KeyCode.Space))
        {
            if (!hasJumped)
            {
                jumpCount++;
                hasJumped = true;
                // Debug.Log("GetJumpMultiplier: " + GetJumpMultiplier());
                Vector3 dir = trampoline.transform.up;
                rb2d.AddForce(dir * velocity * 2f * GetJumpMultiplier(), ForceMode2D.Impulse);
            }
        }
        else if (isTramped)
        {
            Vector3 dir = trampoline.transform.up;
            rb2d.AddForce(dir * velocity * 2f, ForceMode2D.Impulse);
            trampoline.DoEffect();
        }
    }
}