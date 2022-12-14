using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitStun : MonoBehaviour
{
    [SerializeField] P2Move P2;
    [SerializeField] FramesToSec Sec;
    public Animator animator;
    void Start()
    {
        animator = GameObject.FindGameObjectWithTag("Player2").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Stun(float HS)
    {
        P2.canMove = false;
        animator.SetBool("LeonDamaged", true);
        yield return new WaitForSeconds(Sec.Seconds(HS));
        animator.SetBool("LeonDamaged", false);
        P2.canMove = true;
    }
}
