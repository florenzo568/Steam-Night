using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1Move : MonoBehaviour
{
public float horizontal;
    public float speed;
    public float JumpForce;

    public bool canDash = true;
    private bool isDashing;
    public bool canMove = true;
    public bool Invul;
    public bool crouch;
    public bool DragP;
    public float DPTime;
    public float dashingPower;
    public float dashingTime;
    public float dashingCooldown;
    
    //[SerializeField] P2Blocking P2B;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private P1Turning Turn;
    [SerializeField] P1Blocking P1B;
    public Animator animator;

    void Start()
    {
        animator = GameObject.FindGameObjectWithTag("Player1").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDashing)
        {
            return;
        }
        if (canMove)
        {
            horizontal = Input.GetAxisRaw("Horizontal");
        }
        else
        {
            horizontal = 0;
        }

            if (Input.GetButtonDown("Jump") && IsGrounded() && canMove)
        {
            animator.SetBool("MarisaJumping", true);
            rb.velocity = new Vector2(rb.velocity.x, JumpForce);
        }
        if(Input.GetKeyDown("s") && IsGrounded())
        {
            animator.SetBool("MarisaCrouching", true);
            crouch = true;
        }
        else if(Input.GetKeyUp("s") && IsGrounded())
        {
            animator.SetBool("MarisaCrouching", false);
            crouch = false;
        }

        if (Input.GetButtonDown("Dash") && canDash && horizontal != 0)
        {
            StartCoroutine(Dash());
        }

        if(Turn.Flip)
        {
            Vector3 lTemp = transform.localScale;
            lTemp.x = -2.6f ;
            transform.localScale = lTemp;
        }
        else if(!Turn.Flip)
        {
            Vector3 lTemp = transform.localScale;
            lTemp.x = 2.6f;
            transform.localScale = lTemp;
        }
        if(DragP == true)
        {
            if(IsGrounded())
            {
                DPTime -= Time.deltaTime;
                if(DPTime <= 0)
                {
                    DragP = false;
                    crouch = false;
                    DPTime = .72f;
                }
            }
        }
        if (transform.localScale.x > 0 && horizontal < 0)
        {
            animator.SetBool("MarisaWalking", true);
        }
        if (transform.localScale.x < 0 && horizontal > 0)
        {
            Debug.Log("Backwards");
            animator.SetBool("MarisaWalkingBack", true);
        }
        if (horizontal == 0)
        {
            animator.SetBool("MarisaWalking", false);
            animator.SetBool("MarisaWalkingBack", false);
        }
    }
    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }
        if(canMove && P1B.Blocking == false)
        {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        }
        else if (!canMove || P1B.Blocking == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y);
        }
        if(crouch || P1B.Blocking)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

    }

    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        animator.SetBool("MarisaDash", true);
        float OgGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(horizontal * dashingPower, 0f);
        yield return new WaitForSeconds(dashingTime);
        animator.SetBool("MarisaDash", false);
        rb.gravityScale = OgGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
}
