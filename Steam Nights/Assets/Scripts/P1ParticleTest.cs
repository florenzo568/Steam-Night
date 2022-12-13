using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1ParticleTest : MonoBehaviour
{
    public float horizontal;
    public float speed;
    public float JumpForce;
    [SerializeField]
    public ParticleSystem particlesystem;
    public GameObject particles;

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
    //particlesystem doesn't like using math mid script, so new float was made for the math
    public float dashingDirection;

    //[SerializeField] P2Blocking P2B;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private P1Turning Turn;
    [SerializeField] P1Blocking P1B;

    void Start()
    {
        //prevents particles from activating right away
        particles.SetActive(false);

    }


    // Update is called once per frame
    void Update()
    {
        
        
        
        if (isDashing)
        {
            return;
        }
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded() && canMove)
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpForce);
        }
        if (Input.GetKeyDown("s") && IsGrounded())
        {
            crouch = true;
        }
        else if (Input.GetKeyUp("s") && IsGrounded())
        {
            crouch = false;
        }

        if (Input.GetKeyDown(KeyCode.A) && canDash && horizontal != 0)
        {
            StartCoroutine(Dash());
        }

        // if (Turn.Flip)
        // {
        // //    Vector3 lTemp = transform.localScale;
        //   lTemp.x = -1;
        //  //   transform.localScale = lTemp;
        // }
        //  else if (!Turn.Flip)
        //{
        //     Vector3 lTemp = transform.localScale;
        //     lTemp.x = 1;
        //     transform.localScale = lTemp;
        // }
        //  if (DragP == true)
        //  {
        //     if (IsGrounded())
        //    {
        //        DPTime -= Time.deltaTime;
        //       if (DPTime <= 0)
        //       {
        //          DragP = false;
        //          crouch = false;
        //           DPTime = .72f;
        //       }
    }
        void FixedUpdate()
        {
            if (isDashing)
            {
                return;
            }
            if (canMove && P1B.Blocking == false)
            {
                rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
            }
            else if (!canMove || P1B.Blocking == true)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y);
            }
            if (crouch || P1B.Blocking)
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
            }

        }

        bool IsGrounded()
        {
            return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        }

        IEnumerator Dash()
        {
            //establishes particlesystem mainmodule in script. Would do in update but has to be in "layer"
            //that it is used in. particlesystem.main.startSpeed = dashingDirection resulted in errors.
            var main = particlesystem.main;
            canDash = false;
            isDashing = true;
            //math for particles done with new float. main.startSpeed = 50 * horizontal just didn't work for some
            //bizarre reason.
            dashingDirection = 50 * horizontal;
            main.startSpeed = dashingDirection;
            float OgGravity = rb.gravityScale;
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(horizontal * dashingPower, 0f);
            //particles turn on after direction is set
            particles.SetActive(true);
            yield return new WaitForSeconds(dashingTime);
            rb.gravityScale = OgGravity;
            isDashing = false;
            //particles end as soon as dash ends.
            particles.SetActive(false);
            yield return new WaitForSeconds(dashingCooldown);
            canDash = true;
        }
    
}

