using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1Blocking : MonoBehaviour
{
    [SerializeField] P1Move P1;
    public bool Blocking;
    public Animator animator;
    public bool High;
    public bool Low;
    void Start()
    {
        animator = GameObject.FindGameObjectWithTag("Player1").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(P1.canMove == true)
        {
            if(Input.GetButton("Block"))
            {
                Blocking = true;
                animator.SetBool("MarisaBlocking", true);
                if (P1.crouch == true)
                {
                    Low = true;
                }
                if (P1.crouch == false)
                {
                    High = true;
                }
                if (Low && High)
                {
                    High = false;
                }
            }
            else
            {
                Blocking = false;
                High = false;
                Low = false;
                animator.SetBool("MarisaBlocking", false);
            }
        }
    }
}
