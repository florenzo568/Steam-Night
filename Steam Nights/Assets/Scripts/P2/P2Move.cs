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
    public float dashingPower;
    public float dashingTime;
    public float dashingCooldown;
    
    [SerializeField] P2Blocking P2B;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private P1Turning Turn;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isDashing)
        {
            return;
        }
        horizontal = Input.GetAxisRaw("Horizontal2");

        if(Input.GetKeyDown("up") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpForce);
        }

        if (Input.GetButtonDown("Dash2") && canDash && horizontal != 0)
        {
            StartCoroutine(Dash());
        }

        if(Turn.Flip)
        {
            Vector3 lTemp = transform.localScale;
            lTemp.x = -1;
            transform.localScale = lTemp;
        }
        else if(!Turn.Flip)
        {
            Vector3 lTemp = transform.localScale;
            lTemp.x = 1;
            transform.localScale = lTemp;
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

    }

    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
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
