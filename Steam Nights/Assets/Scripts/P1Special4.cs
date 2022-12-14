using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1Special4 : MonoBehaviour
{
public float StartUp;
    public float Active;
    public float Recovery;
    public float Knockback;
    public float HitStun;
    public float Damage;
    public float MeterGain;
    [SerializeField] P1Gauge P2G;
    private SpriteRenderer Sprite;
    public float KnockBackPlus;
    public BoxCollider2D HB;
    [SerializeField] FramesToSec Frames;
    [SerializeField] P2Health P2H;
    [SerializeField] GameObject Punch1;
    [SerializeField] GameObject P2;
    [SerializeField] GameObject P1GO;
    [SerializeField] P1Move P1;
    [SerializeField] P2Blocking P2B;
    [SerializeField] HitStun HS;
    void Start()
    {
        Sprite = Punch1.GetComponent<SpriteRenderer>();
        Sprite.enabled = false;
        HB.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        /*if(Input.GetButtonDown("Fire1") && P1.IsGrounded())
        {
            StartCoroutine(Light());
        }*/
    }

    public IEnumerator Special()
    {
        P1.canDash = false;
        P1.canMove = false;
        Debug.Log("StartUp");
        yield return new WaitForSeconds(Frames.Seconds(StartUp));
        Sprite.enabled = true;
        HB.enabled = true;
        Debug.Log("Active");
        yield return new WaitForSeconds(Frames.Seconds(Active));
        Sprite.enabled = false;
        HB.enabled = false;
        Debug.Log("recovery");
        yield return new WaitForSeconds(Frames.Seconds(Recovery));
        P1.canDash = true;
        P1.canMove = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player2") && P2B.Blocking == false)
        {
            Rigidbody2D enemRB = P2.GetComponent<Rigidbody2D>();
            enemRB.velocity = new Vector2(Knockback * other.gameObject.transform.localScale.x + KnockBackPlus, Knockback + KnockBackPlus);
            P2H.Health -= Damage;
            P2G.Steam += MeterGain;
            StartCoroutine(HS.Stun(HitStun));
            Debug.Log("Hit");
        }
    }
}
