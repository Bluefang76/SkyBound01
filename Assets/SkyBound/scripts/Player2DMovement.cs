using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2DMovement : MonoBehaviour
{
    public float distance = 1f;
    public LayerMask groundlayer;
    public LayerMask tramplayer;
    public Transform feet;

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

    private void FixedUpdate()
    {
        velocity = rb2d.velocity.magnitude;

        isGrounded = Physics2D.Raycast(feet.position, -Vector2.up, distance, groundlayer);

        Debug.DrawRay(transform.position, -Vector2.up * distance, Color.red);

       isTramped = Physics2D.Raycast(feet.position, -Vector2.up, distance, tramplayer);
        Debug.DrawRay(transform.position, -Vector2.up * distance, Color.blue);

        if (isTramped) 
        {
            rb2d.AddForce(Vector2.up * velocity * multiplier);
            if (isTramped)
        {
            multiplier += 0.5f;
        }
        }
    }
}