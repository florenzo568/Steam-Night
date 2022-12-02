using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitStun : MonoBehaviour
{
    [SerializeField] P2Move P2;
    [SerializeField] FramesToSec Sec;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Stun(float HS)
    {
        P2.canMove = false;
        yield return new WaitForSeconds(Sec.Seconds(HS));
        P2.canMove = true;
    }
}
