using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2Special2 : MonoBehaviour
{
    public float StartUp;
    public float Active;
    public float Recovery;
    public float MeterGain;
    [SerializeField] P2Gauge P2G;
    private SpriteRenderer Sprite;
    private BoxCollider2D HB;
    [SerializeField] FramesToSec Frames;
    [SerializeField] GameObject P1;
    [SerializeField] GameObject P2GO;
    [SerializeField] P2Move P2;
    [SerializeField] P1Blocking P1B;
    [SerializeField] P1HitStun HS;
    public Animator animator;
    void Start()
    {
        animator = GameObject.FindGameObjectWithTag("Player2").GetComponent<Animator>();
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
        P2.canDash = false;
        P2.canMove = false;
        Debug.Log("StartUp");
        animator.SetBool("LeonSuper1", true);
        yield return new WaitForSeconds(Frames.Seconds(StartUp));
        P2G.Ammo = 8;
        Debug.Log("Active");
        yield return new WaitForSeconds(Frames.Seconds(Active));
        Debug.Log("recovery");
        yield return new WaitForSeconds(Frames.Seconds(Recovery));
        animator.SetBool("LeonSuper1", false);
        P2.canDash = true;
        P2.canMove = true;
    }
}
