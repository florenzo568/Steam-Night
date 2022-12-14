using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTest : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Debug.Log("bam!");
            animator.SetBool("Marisa5H", false);
            animator.SetBool("Marisa5L", true);
            
        }
        if (Input.GetKeyDown("n"))
        {
            animator.SetBool("Marisa5H", false);
            animator.SetBool("Marisa5L", false);
        }

        if (Input.GetKeyDown("b"))
        {
            Debug.Log("pow!");
            animator.SetBool("Marisa5L", false);
            animator.SetBool("Marisa5H", true);
            
        }

    }
}
