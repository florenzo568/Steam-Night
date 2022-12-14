using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1Blocking : MonoBehaviour
{
    [SerializeField] P1Move P1;
    public bool Blocking;
    public Animator animator;
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
            }
            else
            {
                Blocking = false;
                animator.SetBool("MarisaBlocking", false);
            }
        }
    }
}
