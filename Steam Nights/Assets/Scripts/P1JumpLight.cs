using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1JumpLight : MonoBehaviour
{
    public float StartUp;
    public float Active;
    public float Recovery;
    public float Knockback;
    public float Damage;
    public float MeterGain;
    public float HitStun;
    public float KnockBackPlus;
    [SerializeField] P1Gauge P2G;
    private SpriteRenderer Sprite;
    private BoxCollider2D HB;
    [SerializeField] FramesToSec Frames;
    [SerializeField] P2Health P2H;
    [SerializeField] GameObject Punch;
    [SerializeField] GameObject P2;
    [SerializeField] GameObject P1GO;
    [SerializeField] P2Blocking P2B;
    [SerializeField] P1Move P1;
    [SerializeField] HitStun HS;
    public Animator animator;
    void Start()
    {
        Sprite = Punch.GetComponent<SpriteRenderer>();
        Sprite.enabled = false;
        HB = Punch.GetComponent<BoxCollider2D>();
        HB.enabled = false;
        animator = GameObject.FindGameObjectWithTag("Player1").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if(Input.GetButtonDown("Fire1") && P1.IsGrounded())
        {
            StartCoroutine(Light());
        }*/
    }

    public IEnumerator Light()
    {
        P1.canDash = false;
        P1.canMove = false;
        Debug.Log("StartUp");
        animator.SetBool("MarisaJumping", false);
        animator.SetBool("MarisaJL", true);
        yield return new WaitForSeconds(Frames.Seconds(StartUp));
        Sprite.enabled = true;
        HB.enabled = false;
        Debug.Log("Active");
        yield return new WaitForSeconds(Frames.Seconds(Active));
        Sprite.enabled = false;
        HB.enabled = false;
        Debug.Log("recovery");
        yield return new WaitForSeconds(Frames.Seconds(Recovery));
        animator.SetBool("MarisaJL", false);
        P1.canDash = true;
        P1.canMove = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player2") && !P2B.High)
        {
            Rigidbody2D enemRB = P2.GetComponent<Rigidbody2D>();
            enemRB.velocity = new Vector2(0 , Knockback + KnockBackPlus);
            StartCoroutine(HS.Stun(HitStun));
            P2H.Health -= Damage;
            P2G.Steam += MeterGain;
            Debug.Log("Hit");
        }
    }
}
