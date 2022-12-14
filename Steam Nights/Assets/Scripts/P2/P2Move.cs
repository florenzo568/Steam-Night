using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2Move : MonoBehaviour
{
public float horizontal;
    public float speed;
    public float JumpForce;

    public bool canDash = true;
    private bool isDashing;
    public bool canMove = true;
    public bool crouch;
    public float dashingPower;
    public float dashingTime;
    public float dashingCooldown;
    
    [SerializeField] P2Blocking P2B;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private P1Turning Turn;
    public Animator animator;

    void Start()
    {
        animator = GameObject.FindGameObjectWithTag("Player2").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (isDashing)
        {
            return;
        }
        horizontal = Input.GetAxisRaw("Horizontal2");

        if(Input.GetKeyDown("up") && IsGrounded() && canMove)
        {
            animator.SetBool("LeonJumping", true);
            rb.velocity = new Vector2(rb.velocity.x, JumpForce);
        }
        if(Input.GetKeyDown("down") && IsGrounded())
        {
            Debug.Log("Crouching");
            animator.SetBool("LeonCrouching", true);
            crouch = true;
        }
        else if(Input.GetKeyUp("down") && IsGrounded())
        {
            animator.SetBool("LeonCrouching", false);
            crouch = false;
        }

        if (Input.GetButtonDown("Dash2") && canDash && horizontal != 0)
        {
            StartCoroutine(Dash());
        }

        if(Turn.Flip)
        {
            Vector3 lTemp = transform.localScale;
            lTemp.x = -2.1f;
            transform.localScale = lTemp;
        }
        else if(!Turn.Flip)
        {
            Vector3 lTemp = transform.localScale;
            lTemp.x = 2.1f;
            transform.localScale = lTemp;
        }
        if (transform.localScale.x > 0 && horizontal < 0)
        {
            animator.SetBool("LeonWalking", true);
        }
        if (transform.localScale.x < 0 && horizontal > 0)
        {
            Debug.Log("Backwards");
            animator.SetBool("LeonWalkingBack", true);
        }
        if (horizontal == 0)
        {
            animator.SetBool("LeonWalking", false);
            animator.SetBool("LeonWalkingBack", false);
        }
    }
    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }
        if(canMove && P2B.Blocking == false)
        {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        }
        else if (!canMove || P2B.Blocking == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y);
        }
        if(crouch)
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
        animator.SetBool("LeonDash", true);
        float OgGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(horizontal * dashingPower, 0f);
        yield return new WaitForSeconds(dashingTime);
        rb.gravityScale = OgGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
}
