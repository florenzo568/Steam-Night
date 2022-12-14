using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2DownMedium : MonoBehaviour
{
    public float StartUp;
    public float Active;
    public float Recovery;
    public float Knockback;
    public float HitStun;
    public float Damage;
    public float MeterGain;
    public float KnockBackPlus;
    [SerializeField] P2Gauge P1G;
    private SpriteRenderer Sprite;
    private BoxCollider2D HB;
    [SerializeField] FramesToSec Frames;
    [SerializeField] P1Health P1H;
    [SerializeField] GameObject Punch;
    [SerializeField] GameObject P1;
    [SerializeField] GameObject P2GO;
    [SerializeField] P2Move P2;
    [SerializeField] P1Blocking P1B;
    [SerializeField] P1HitStun HS;
    public Animator animator;
    void Start()
    {
        Sprite = Punch.GetComponent<SpriteRenderer>();
        Sprite.enabled = false;
        HB = Punch.GetComponent<BoxCollider2D>();
        HB.enabled = false;
        animator = GameObject.FindGameObjectWithTag("Player2").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator Medium()
    {
        P2.canDash = false;
        P2.canMove = false;
        animator.SetBool("LeonCrouching", false);
        animator.SetBool("Leon2M", true);
        Debug.Log("StartUp");
        yield return new WaitForSeconds(Frames.Seconds(StartUp));
        Sprite.enabled = true;
        HB.enabled = true;
        //P2GO.GetComponent<Rigidbody2D>().AddForce(P2GO.transform.localScale.x * -transform.right * Knockback, ForceMode2D.Impulse);
        Debug.Log("Active");
        yield return new WaitForSeconds(Frames.Seconds(Active));
        Sprite.enabled = false;
        HB.enabled = false;
        Debug.Log("recovery");
        yield return new WaitForSeconds(Frames.Seconds(Recovery));
        animator.SetBool("Leon2M", false);
        if (Input.GetKey("down"))
        {
            animator.SetBool("LeonCrouching", true);
        }
        P2.canDash = true;
        P2.canMove = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player1") && P1B.Blocking == false)
        {
            Rigidbody2D enemRB = P1.GetComponent<Rigidbody2D>();
            enemRB.velocity = new Vector2(0, Knockback + KnockBackPlus);
            P1H.Health -= Damage;
            P1G.Steam += MeterGain;
            StartCoroutine(HS.Stun(HitStun));
            Debug.Log("Hit");
        }
    }
}
