using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2Blocking : MonoBehaviour
{
    [SerializeField] P2Move P2;
    public bool Blocking;
    public Animator animator;
    public bool High;
    public bool Low;
    
    void Start()
    {
        animator = GameObject.FindGameObjectWithTag("Player2").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(P2.canMove == true)
        {
            if(Input.GetButton("Block2"))
            {
                Blocking = true;
                animator.SetBool("LeonBlocking", true);
                if(P2.crouch == true)
                {
                    Low = true;
                }
                if(P2.crouch == false)
                {
                    High = true;
                }
                if(Low && High)
                {
                    High = false;
                }
            }
            else
            {
                Blocking = false;
                Low = false;
                High = false;
                animator.SetBool("LeonBlocking", false);
            }
        }
    }
}
