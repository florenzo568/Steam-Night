using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1Attacking : MonoBehaviour
{
    [SerializeField] P1Move P1;
    [SerializeField] P2Health P2H;
    [SerializeField] P1Blocking P1B;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Block") && Input.GetButtonDown("Fire1") && P1.IsGrounded() && P1B.Blocking == true && P1.crouch)
        {
            Debug.Log("Special Inate");
            StartCoroutine(P1.GetComponent<P1Special1>().Special());
            P2H.Health -= P1.GetComponent<P1Special1>().Damage;
            P1B.Blocking = false;
            P1.DragP = true;
        }
        if (Input.GetButton("Block") && Input.GetButtonDown("Fire1") && P1.IsGrounded() && P1B.Blocking == true && !P1.crouch && P1.canMove)
        {
            Debug.Log("Special 1");
            StartCoroutine(P1.GetComponent<P1Special2>().Special());
        }
        if (Input.GetButton("Block") && Input.GetButtonDown("Fire2") && P1.IsGrounded() && P1B.Blocking == true)
        {
            Debug.Log("Special 2");
        }
        if (Input.GetButton("Block") && Input.GetButtonDown("Fire3") && P1.IsGrounded() && P1B.Blocking == true)
        {
            Debug.Log("Special 3");
        }
        if (Input.GetButtonDown("Fire1") && P1.IsGrounded() && !Input.GetKey("s") && P1.canMove && P1B.Blocking == false)
        {
            StartCoroutine(P1.GetComponent<P1Light>().Light());
            P2H.Health -= P1.GetComponent<P1Light>().Damage;
        }
        if (Input.GetButtonDown("Fire1") && P1.IsGrounded() && Input.GetKey("s") && P1B.Blocking == false)
        {
            StartCoroutine(P1.GetComponent<P1DownLight>().Light());
            P2H.Health -= P1.GetComponent<P1DownLight>().Damage;
        }
        if (Input.GetButtonDown("Fire1") && P1.IsGrounded() == false && P1.canMove)
        {
            StartCoroutine(P1.GetComponent<P1JumpLight>().Light());
            P2H.Health -= P1.GetComponent<P1JumpLight>().Damage;
        }
        if (Input.GetButtonDown("Fire2") && P1.IsGrounded() && !Input.GetKey("s") && P1.canMove && P1B.Blocking == false)
        {
            StartCoroutine(P1.GetComponent<P1Medium>().Medium());
            P2H.Health -= P1.GetComponent<P1Medium>().Damage;
        }
        if (Input.GetButtonDown("Fire2") && P1.IsGrounded() && Input.GetKey("s"))
        {
            StartCoroutine(P1.GetComponent<P1DownMedium>().Medium());
            P2H.Health -= P1.GetComponent<P1DownMedium>().Damage;
        }
        if (Input.GetButtonDown("Fire2") && P1.IsGrounded() == false && P1.canMove)
        {
            StartCoroutine(P1.GetComponent<P1JumpMedium>().Medium());
            P2H.Health -= P1.GetComponent<P1JumpMedium>().Damage;
        }
        if (Input.GetButtonDown("Fire3") && P1.IsGrounded() && !Input.GetKey("s") && P1.canMove && P1B.Blocking == false)
        {
            StartCoroutine(P1.GetComponent<P1Heavy>().Heavy());
            P2H.Health -= P1.GetComponent<P1Heavy>().Damage;
        }
        if (Input.GetButtonDown("Fire3") && P1.IsGrounded() && Input.GetKey("s"))
        {
            StartCoroutine(P1.GetComponent<P1DownHeavy>().Heavy());
            P2H.Health -= P1.GetComponent<P1DownHeavy>().Damage;
        }
        if (Input.GetButtonDown("Fire3") && P1.IsGrounded() == false && P1.canMove)
        {
            StartCoroutine(P1.GetComponent<P1JumpHeavy>().Heavy());
            P2H.Health -= P1.GetComponent<P1JumpHeavy>().Damage;
        }
    }
}
