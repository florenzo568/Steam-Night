using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2Attacking : MonoBehaviour
{
    [SerializeField] P2Move P2;
    [SerializeField] P2Blocking P2B;
    [SerializeField] P1Health P1H;
    [SerializeField] P2Light P2L;
    [SerializeField] P2DownLight P2DL;
    [SerializeField] P2JumpLight P2JL;
    [SerializeField] P2Medium P2M;
    [SerializeField] P2DownMedium P2DM;
    [SerializeField] P2JumpMedium P2JM;
    [SerializeField] P2Heavy P2SH;
    [SerializeField] P2DownHeavy P2DH;
    [SerializeField] P2JumpHeavy P2JH;
    [SerializeField] P2Special1 P2S1;
    [SerializeField] P2Special2 P2S2;
    [SerializeField] P2Special3 P2S3;
    [SerializeField] P2Special4 P2S4;
    [SerializeField] P2Gauge P2G;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Block2") && Input.GetButtonDown("Fire4") && P2.IsGrounded() && P2B.Blocking == true && P2.crouch && P2G.Steam >= 30)
        {
            StartCoroutine(P2S1.Special());
            P2G.Steam -= 30;
        }
        if (Input.GetButton("Block2") && Input.GetButtonDown("Fire4") && P2.IsGrounded() && P2B.Blocking == true && !P2.crouch && P2.canMove && P2G.Steam >= 50)
        {
            StartCoroutine(P2S2.Special());
            P2G.Steam -= 50;
        }
        if (Input.GetButton("Block2") && Input.GetButtonDown("Fire5") && P2.IsGrounded() && P2B.Blocking == true && !P2.crouch && P2.canMove && P2G.Steam >= 50)
        {
            StartCoroutine(P2S3.Special());
            P2G.Steam -= 50;
        }
        if (Input.GetButton("Block2") && Input.GetButtonDown("Fire6") && P2.IsGrounded() && P2B.Blocking == true && !P2.crouch && P2.canMove && P2G.Steam >= 100)
        {
            StartCoroutine(P2S4.Special());
            P2G.Steam -= 100;
        }
        if (Input.GetButtonDown("Fire4") && P2.IsGrounded() && !Input.GetKey("down") && P2.canMove && P2B.Blocking == false)
        {
            StartCoroutine(P2L.Light());
        }
        if (Input.GetButtonDown("Fire4") && P2.IsGrounded() && Input.GetKey("down") && P2B.Blocking == false)
        {
            StartCoroutine(P2DL.Light());
        }
        if (Input.GetButtonDown("Fire4") && P2.IsGrounded() == false && P2.canMove)
        {
            StartCoroutine(P2JL.Light());
        }
        if (Input.GetButtonDown("Fire5") && P2.IsGrounded() && !Input.GetKey("down") && P2.canMove && P2B.Blocking == false)
        {
            StartCoroutine(P2M.Medium());
        }
        if (Input.GetButtonDown("Fire5") && P2.IsGrounded() && Input.GetKey("down"))
        {
            StartCoroutine(P2DM.Medium());
        }
        if (Input.GetButtonDown("Fire5") && P2.IsGrounded() == false && P2.canMove)
        {
            StartCoroutine(P2JM.Medium());
        }
        if (Input.GetButtonDown("Fire6") && P2.IsGrounded() && !Input.GetKey("down") && P2.canMove && P2B.Blocking == false && P2G.Ammo > 0)
        {
            StartCoroutine(P2SH.Heavy());
            P2G.Ammo -= 1;
        }
        if (Input.GetButtonDown("Fire6") && P2.IsGrounded() && Input.GetKey("down") && P2.canMove && P2B.Blocking == false && P2G.Ammo > 0)
        {
            StartCoroutine(P2DH.Heavy());
            P2G.Ammo -= 1;
        }
        if (Input.GetButtonDown("Fire6") && P2.IsGrounded() == false && P2.canMove && P2G.Ammo > 0)
        {
            StartCoroutine(P2JH.Heavy());
            P2G.Ammo -= 1;
        }
       P2L.KnockBackPlus = P1H.Knock * 0.1f;
       P2DL.KnockBackPlus = P1H.Knock * 0.1f;
       P2JL.KnockBackPlus = P1H.Knock * 0.1f;
       P2M.KnockBackPlus = P1H.Knock * 0.1f;
       P2DM.KnockBackPlus = P1H.Knock * 0.1f;
       P2JM.KnockBackPlus = P1H.Knock * 0.1f;
    }
}
