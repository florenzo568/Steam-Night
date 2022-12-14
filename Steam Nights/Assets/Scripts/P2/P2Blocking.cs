using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2Blocking : MonoBehaviour
{
    [SerializeField] P2Move P2;
    public bool Blocking;
    public Animator animator;
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
            }
            else
            {
                Blocking = false;
                animator.SetBool("LeonBlocking", false);
            }
        }
    }
}
