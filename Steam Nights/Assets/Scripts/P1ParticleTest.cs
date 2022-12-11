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
    public float dashingDirection;

    //[SerializeField] P2Blocking P2B;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private P1Turning Turn;
    [SerializeField] P1Blocking P1B;

    void Start()
    {
        particlesystem = GetComponent<ParticleSystem>();
        particles.SetActive(false);

    }

    void SetStartSpeed() { 
    }
    // Update is called once per frame
    void Update()
    {
        dashingDirection = horizontal;
        var main = particlesystem.main;
        main.startSpeed = dashingDirection;
        
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
            canDash = false;
            isDashing = true;
            float OgGravity = rb.gravityScale;
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(horizontal * dashingPower, 0f);
            particles.SetActive(true);
            yield return new WaitForSeconds(dashingTime);
            rb.gravityScale = OgGravity;
            isDashing = false;
            particles.SetActive(false);
            yield return new WaitForSeconds(dashingCooldown);
            canDash = true;
        }
    
}

