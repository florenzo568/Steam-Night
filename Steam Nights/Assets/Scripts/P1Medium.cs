using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1Medium : MonoBehaviour
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
    private BoxCollider2D HB;
    [SerializeField] FramesToSec Frames;
    [SerializeField] GameObject Punch;
    [SerializeField] GameObject P2;
    [SerializeField] GameObject P1GO;
    [SerializeField] P1Move P1;
    [SerializeField] P2Blocking P2B;
    [SerializeField] HitStun HS;
    void Start()
    {
        Sprite = Punch.GetComponent<SpriteRenderer>();
        Sprite.enabled = false;
        HB = Punch.GetComponent<BoxCollider2D>();
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

    public IEnumerator Medium()
    {
        P1.canDash = false;
        P1.canMove = false;
        Debug.Log("StartUp");
        yield return new WaitForSeconds(Frames.Seconds(StartUp));
        Sprite.enabled = true;
        HB.enabled = true;
        P1GO.GetComponent<Rigidbody2D>().AddForce(P1GO.transform.localScale.x * transform.right * Knockback * 2, ForceMode2D.Impulse);
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
            enemRB.AddForce(P1GO.transform.localScale.x * transform.right * Knockback, ForceMode2D.Force);
            P2G.Steam += MeterGain;
            StartCoroutine(HS.Stun(HitStun));
            Debug.Log("Hit");
        }
    }
}
