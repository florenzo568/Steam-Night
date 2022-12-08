using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1Attacking : MonoBehaviour
{
    [SerializeField] P1Move P1;
    [SerializeField] P2Health P2H;
    [SerializeField] P1Blocking P1B;
    [SerializeField] P1Light P1L;
    [SerializeField] P1DownLight P1DL;
    [SerializeField] P1JumpLight P1JL;
    [SerializeField] P1Medium P1M;
    [SerializeField] P1DownMedium P1DM;
    [SerializeField] P1JumpMedium P1JM;
    [SerializeField] P1Heavy P1H;
    [SerializeField] P1DownHeavy P1DH;
    [SerializeField] P1JumpHeavy P1JH;
    [SerializeField] P1Special1 P1S1;
    [SerializeField] P1Special4 P1S4;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Block") && Input.GetButtonDown("Fire1") && P1.IsGrounded() && P1B.Blocking == true && P1.crouch)
        {
            Debug.Log("Special Innate");
            StartCoroutine(P1S1.Special());
            P1B.Blocking = false;
            P1.DragP = true;
        }
        if (Input.GetButton("Block") && Input.GetButtonDown("Fire1") && P1.IsGrounded() && P1B.Blocking == true && !P1.crouch && P1.canMove)
        {
            Debug.Log("Special 2");
            StartCoroutine(P1.GetComponent<P1Special2>().Special());
        }
        if (Input.GetButton("Block") && Input.GetButtonDown("Fire2") && P1.IsGrounded() && P1B.Blocking == true && !P1.crouch && P1.canMove)
        {
            Debug.Log("Special 3");
            StartCoroutine(P1.GetComponent<P1Special3>().Special());
        }
        if (Input.GetButton("Block") && Input.GetButtonDown("Fire3") && P1.IsGrounded() && P1B.Blocking == true && !P1.crouch && P1.canMove)
        {
            Debug.Log("Special 4");
            StartCoroutine(P1S4.Special());
        }
        if (Input.GetButtonDown("Fire1") && P1.IsGrounded() && !Input.GetKey("s") && P1.canMove && P1B.Blocking == false)
        {
            StartCoroutine(P1L.Light());
        }
        if (Input.GetButtonDown("Fire1") && P1.IsGrounded() && Input.GetKey("s") && P1B.Blocking == false)
        {
            StartCoroutine(P1DL.Light());
        }
        if (Input.GetButtonDown("Fire1") && P1.IsGrounded() == false && P1.canMove)
        {
            StartCoroutine(P1JL.Light());
        }
        if (Input.GetButtonDown("Fire2") && P1.IsGrounded() && !Input.GetKey("s") && P1.canMove && P1B.Blocking == false)
        {
            StartCoroutine(P1M.Medium());
        }
        if (Input.GetButtonDown("Fire2") && P1.IsGrounded() && Input.GetKey("s"))
        {
            StartCoroutine(P1DM.Medium());
        }
        if (Input.GetButtonDown("Fire2") && P1.IsGrounded() == false && P1.canMove)
        {
            StartCoroutine(P1JM.Medium());
        }
        if (Input.GetButtonDown("Fire3") && P1.IsGrounded() && !Input.GetKey("s") && P1.canMove && P1B.Blocking == false)
        {
            StartCoroutine(P1H.Heavy());
        }
        if (Input.GetButtonDown("Fire3") && P1.IsGrounded() && Input.GetKey("s"))
        {
            StartCoroutine(P1DH.Heavy());
        }
        if (Input.GetButtonDown("Fire3") && P1.IsGrounded() == false && P1.canMove)
        {
            StartCoroutine(P1JH.Heavy());
        }
    }
}
