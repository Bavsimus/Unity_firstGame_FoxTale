using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scripts : MonoBehaviour
{
    private float speed_X;
    [SerializeField] private float jump = 8f;
    [SerializeField] private float speed = 5f, jumpSpeed = 1f;
    private Rigidbody2D rb;
    private SpriteRenderer rbSprite;
    private Animator animator;
    private BoxCollider2D bcol;
    public bool frogAttState = false;
    private enum anim {Idle,Jump,Run,Fall,Crouch};
    [SerializeField] private LayerMask jumpRange;
    

    // Start is called before the first frame update
    void Start()
    {  
        rb = GetComponent<Rigidbody2D>();
        rbSprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        bcol = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
       attack();
       crouch();
       run();
       animations();
    }

    private void attack()
    {
        if (Input.GetKeyDown("q"))
        {

        }
    }
    private void crouch()
    {
        if (Input.GetKeyDown("c") && gcheck())
        {
            bcol.offset = new Vector2(-0.07081842f, -0.56f);
            bcol.size = new Vector2(1.013126f, 0.8168049f);
        }
        else if (Input.GetKeyUp("c") && gcheck())
        {
            bcol.offset = new Vector2(-0.07081842f, -0.28f);
            bcol.size = new Vector2(1.013126f, 1.34f);
        }
    }
    private void run()
    {
        if (gcheck())
        {
            speed_X = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(speed_X * speed, rb.velocity.y);
        }
        else
        {
            speed_X = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(speed_X * speed / jumpSpeed, rb.velocity.y);
        }
        if (Input.GetButtonDown("Jump") && gcheck())
        {
            if (frogAttState & Input.GetKey("c"))
            {
                rb.velocity = new Vector2(rb.velocity.x, jump*2);
            }
            else
            {
                rb.velocity = new Vector2(rb.velocity.x, jump);
            }
        }
    }

    private void animations() {
        anim state;
        if (Input.GetKeyDown("q"))
        {
            animator.SetBool("attack",true);
        }
        else
        {
            animator.SetBool("attack", false);
        }

        //run
        if (speed_X > 0f)
        {
            state = anim.Run;
            rbSprite.flipX = false;
        }
        else if (speed_X < 0f)
        {
            state = anim.Run;
            rbSprite.flipX = true;
        }
        else 
        {
            state = anim.Idle;
        }
        //jump
        if (rb.velocity.y > 0.1f)
        {
            state = anim.Jump;
        }
        //fall
        else if (rb.velocity.y < -0.1f)
        {
            state = anim.Fall;
        }
        //crouch
        if (Input.GetKey("c") && gcheck())
        {
            state = anim.Crouch;
        }
        animator.SetInteger("state",(int)state);
    }

    private bool gcheck()
    {
        return Physics2D.BoxCast(bcol.bounds.center, bcol.bounds.size, 0f, Vector2.down, .1f, jumpRange);
    }
}
