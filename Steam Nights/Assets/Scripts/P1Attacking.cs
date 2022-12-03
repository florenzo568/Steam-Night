using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1Attacking : MonoBehaviour
{
    [SerializeField] P1Move P1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && P1.IsGrounded() && !Input.GetKey("s") && P1.canMove)
        {
            StartCoroutine(P1.GetComponent<P1Light>().Light());
        }
        if (Input.GetButtonDown("Fire1") && P1.IsGrounded() && Input.GetKey("s"))
        {
            StartCoroutine(P1.GetComponent<P1DownLight>().Light());
        }
        if (Input.GetButtonDown("Fire1") && P1.IsGrounded() == false && P1.canMove)
        {
            StartCoroutine(P1.GetComponent<P1JumpLight>().Light());
        }
        if (Input.GetButtonDown("Fire2") && P1.IsGrounded() && !Input.GetKey("s") && P1.canMove)
        {
            StartCoroutine(P1.GetComponent<P1Medium>().Medium());
        }
        if (Input.GetButtonDown("Fire2") && P1.IsGrounded() && Input.GetKey("s"))
        {
            StartCoroutine(P1.GetComponent<P1DownMedium>().Medium());
        }
        if (Input.GetButtonDown("Fire2") && P1.IsGrounded() == false && P1.canMove)
        {
            StartCoroutine(P1.GetComponent<P1JumpMedium>().Medium());
        }
    }
}
