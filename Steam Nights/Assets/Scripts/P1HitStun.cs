using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1HitStun : MonoBehaviour
{
    [SerializeField] P1Move P1;
    [SerializeField] FramesToSec Sec;
    public Animator animator;
    void Start()
    {
        animator = GameObject.FindGameObjectWithTag("Player1").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Stun(float HS)
    {
        P1.canMove = false;
        animator.SetBool("MarisaDamage", true);
        yield return new WaitForSeconds(Sec.Seconds(HS));
        animator.SetBool("MarisaDamage", false);
        P1.canMove = true;
    }
}
