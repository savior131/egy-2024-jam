using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D),typeof(BoxCollider2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    [SerializeField] float acceleration;
    [SerializeField] LayerMask ground;

    public Rigidbody2D rb;
    BoxCollider2D col;
    Animator anim;

    public bool canMove = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (!canMove) { 
            rb.velocity = new Vector2(0, rb.velocity.y);
            anim.SetBool("inAir", true);

            anim.SetBool("run", false);

            return;
        }
        MovementHandler();
        JumpHandler();
        AnimationHAndler();
        Flip();
    }
    private void MovementHandler()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float targetspeed = horizontal * speed;
        float currentspeed = rb.velocity.x;
        if (currentspeed < targetspeed)
        {
            currentspeed += acceleration * Time.deltaTime;
            if (currentspeed > targetspeed)
            {
                currentspeed = targetspeed;
            }
        }
        else if (currentspeed > targetspeed)
        {
            currentspeed -= acceleration * Time.deltaTime;
            if (currentspeed < targetspeed)
            {
                currentspeed = targetspeed;
            }
        }
        rb.velocity = new Vector2(currentspeed, rb.velocity.y);
    }
    private void JumpHandler()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
    private void AnimationHAndler()
    {
        if (rb.velocity.x != 0)
        {
            anim.SetBool("run", true);
        }
        else
        {
            anim.SetBool("run", false);
        }

        if (!isGrounded())
        {
            anim.SetBool("inAir", true);
        }
        else
        {
            anim.SetBool("inAir", false);
        }
        anim.SetFloat("yVelocity",rb.velocity.y);

    }
    private void Flip()
    {
        if (rb.velocity.x<0)
        {
            transform.localScale = new Vector2(-Mathf.Abs(transform.localScale.x), transform.localScale.y);
        }
        else if(rb.velocity.x>0)
        {
            transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y);
        }
    }
    bool isGrounded()
    {
        return Physics2D.BoxCast(col.bounds.center, col.bounds.size, 0f, Vector2.down, 0.2f, ground);
    }
}