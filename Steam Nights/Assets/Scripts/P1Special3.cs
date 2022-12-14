using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1Special3 : MonoBehaviour
{
    public float StartUp;
    public float Active;
    public float Recovery;
    public float MeterGain;
    [SerializeField] P1Gauge P2G;
    private SpriteRenderer Sprite;
    private BoxCollider2D HB;
    [SerializeField] FramesToSec Frames;
    [SerializeField] Transform FirePoint;
    [SerializeField] GameObject FireBall;
    [SerializeField] GameObject P2;
    [SerializeField] GameObject P1GO;
    [SerializeField] P1Move P1;
    [SerializeField] P2Blocking P2B;
    [SerializeField] HitStun HS;
    public Animator animator;
    void Start()
    {
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

    public IEnumerator Special()
    {
        P1.canDash = false;
        P1.canMove = false;
        Debug.Log("StartUp");
        animator.SetBool("MarisaSuper2", true);
        yield return new WaitForSeconds(Frames.Seconds(StartUp));
        Instantiate(FireBall, FirePoint.position, Quaternion.identity);
        Debug.Log("Active");
        yield return new WaitForSeconds(Frames.Seconds(Active));
        Debug.Log("recovery");
        yield return new WaitForSeconds(Frames.Seconds(Recovery));
        animator.SetBool("MarisaSuper2", false);
        P1.canDash = true;
        P1.canMove = true;
    }
}
