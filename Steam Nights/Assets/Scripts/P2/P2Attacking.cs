using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2Attacking : MonoBehaviour
{
    [SerializeField] P2Move P2;
    [SerializeField] P1Health P1H;
    [SerializeField] P2Blocking P2B;
    [SerializeField] P2Light P2L;
    [SerializeField] P1DownLight P1DL;
    [SerializeField] P1JumpLight P1JL;
    [SerializeField] P1Medium P1M;
    [SerializeField] P1DownMedium P1DM;
    [SerializeField] P1JumpMedium P1JM;
    //[SerializeField] P1Heavy P1H;
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
        if (Input.GetButton("Block2") && Input.GetButtonDown("Fire4") && P2.IsGrounded() && P2B.Blocking == true && P2.crouch)
        {
            Debug.Log("Special Innate");
        }
        if (Input.GetButton("Block2") && Input.GetButtonDown("Fire4") && P2.IsGrounded() && P2B.Blocking == true && !P2.crouch && P2.canMove)
        {
            Debug.Log("Special 2");
        }
        if (Input.GetButton("Block2") && Input.GetButtonDown("Fire5") && P2.IsGrounded() && P2B.Blocking == true && !P2.crouch && P2.canMove)
        {
            Debug.Log("Special 3");
        }
        if (Input.GetButton("Block2") && Input.GetButtonDown("Fire6") && P2.IsGrounded() && P2B.Blocking == true && !P2.crouch && P2.canMove)
        {
            Debug.Log("Special 4");
        }
        if (Input.GetButtonDown("Fire4") && P2.IsGrounded() && !Input.GetKey("down") && P2.canMove && P2B.Blocking == false)
        {
            StartCoroutine(P2L.Light());
        }
        if (Input.GetButtonDown("Fire4") && P2.IsGrounded() && Input.GetKey("down") && P2B.Blocking == false)
        {
            Debug.Log("Light");
        }
        if (Input.GetButtonDown("Fire4") && P2.IsGrounded() == false && P2.canMove)
        {
            Debug.Log("Light");
        }
        if (Input.GetButtonDown("Fire5") && P2.IsGrounded() && !Input.GetKey("down") && P2.canMove && P2B.Blocking == false)
        {
            Debug.Log("Medium");
        }
        if (Input.GetButtonDown("Fire5") && P2.IsGrounded() && Input.GetKey("down"))
        {
            Debug.Log("Medium");
        }
        if (Input.GetButtonDown("Fire5") && P2.IsGrounded() == false && P2.canMove)
        {
            Debug.Log("Medium");
        }
        if (Input.GetButtonDown("Fire6") && P2.IsGrounded() && !Input.GetKey("down") && P2.canMove && P2B.Blocking == false)
        {
            Debug.Log("Heavy");
        }
        if (Input.GetButtonDown("Fire6") && P2.IsGrounded() && Input.GetKey("down"))
        {
            Debug.Log("Heavy");
        }
        if (Input.GetButtonDown("Fire6") && P2.IsGrounded() == false && P2.canMove)
        {
            Debug.Log("Heavy");
        }
    }
}
