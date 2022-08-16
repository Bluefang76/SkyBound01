using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerNumber
{
    Player1,
    Player2,
}
public class MPlayer2DMovement : MonoBehaviour
{
    public ScreenShake screenShake;
    public PlayerNumber playerNumber;
    private Rigidbody2D rb;
    [SerializeField] private float _intialJumpForce;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _fallForce;

    [SerializeField] private float runSpeed;
    public SpriteRenderer playerSprite;

    //Jahmal
    public bool onTrampoline;
    

    public float distance = 1f;
    public LayerMask groundlayer;
    public LayerMask trampolinelayer;
    public Transform leftFoot, rightFoot;
    Buffed buffed;
    public bool Jumped = false;
    //public float velocity;

    Trampoline _trampolineLast;
    Trampoline _trampoline;

    private Animator animator;
    float horInput;
    public string horInputString;
    public KeyCode jumpButton;

    bool holdingJump;
    float airTime;
    public float maxAirTime;
    private bool grounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(leftFoot.position, -Vector2.up * distance, Color.red);
        Debug.DrawRay(rightFoot.position, -Vector2.up * distance, Color.blue);

        if (IsGrounded(out _trampoline))
        {
            if (_trampoline != null)
            {
                if (_trampolineLast != _trampoline)
                {
                    _trampoline.Hit();
                    _trampolineLast = _trampoline;
                }
            }
            else
            {
                _trampolineLast = null;
            }
        }
        else
        {
            _trampolineLast = null;
        }

        //Jumping
        if (Input.GetKeyDown(jumpButton) && IsGrounded(out _trampoline))
        {
            airTime = 0;

            float multi = 1f;
            if (_trampoline != null)
            {
                
                multi = 2f;
                _trampoline.DoEffect();
                _trampoline = null;
                screenShake.StartShake();
            }

            IntialJump(multi);
        }

        holdingJump = Input.GetKey(jumpButton) && !IsGrounded(out _trampoline);

        //Movement
        horInput = Input.GetAxis(horInputString);

        if (horInput < -0.25f && !playerSprite.flipX)
        {
            playerSprite.flipX = true;
        }
        else if (horInput > 0.25f && playerSprite.flipX) 
        {
            playerSprite.flipX = false;
        }

        animator.SetBool("run", horInput != 0);

        //Jump animation check
        animator.SetBool("grounded", grounded);
    }
   
    private void FixedUpdate()
    {
        Run();
        AirJump();
    }

    private void AirJump()
    {
        if (!holdingJump)
            return;

        airTime += Time.deltaTime;


        if (airTime < maxAirTime)
        {
            Vector3 jumpDir = Vector3.up;
            rb.AddForce(jumpDir * _jumpForce);
        }
        else
        {
            Debug.Log("falling");
            Vector3 jumpDir = -Vector3.up;
            rb.AddForce(jumpDir * _fallForce);
        }
      

    }
    private void IntialJump(float multi)
    {
        Vector3 jumpDir = Vector3.up;
        rb.AddForce(jumpDir * _intialJumpForce * multi);
        grounded = false;
    }

    private void Run()
    {
        rb.AddForce(Vector2.right * horInput * runSpeed);
    }

    private bool IsGrounded(out Trampoline trampoline)
    {
        trampoline = null;
        Debug.DrawRay(leftFoot.position, -Vector2.up * distance, Color.red);

        RaycastHit2D lefttHit = Physics2D.Raycast(leftFoot.position, -Vector2.up, distance, groundlayer);
        RaycastHit2D rightHit = Physics2D.Raycast(rightFoot.position, -Vector2.up, distance, groundlayer);


        bool leftGrounded = lefttHit.collider != null;
        bool rightGrounded = rightHit.collider != null;

        bool onGround = leftGrounded || rightGrounded;
        grounded = onGround;

        if (onGround) {
            if (leftGrounded)
            {
                lefttHit.collider.TryGetComponent(out Trampoline t);
                trampoline = t;
            }else if (rightGrounded)
            {
                rightHit.collider.TryGetComponent(out Trampoline t);
                trampoline = t;
            }
        }

        return onGround;
    }
}