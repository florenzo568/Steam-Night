using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2Blocking : MonoBehaviour
{
    [SerializeField] P2Move P2;
    public bool Blocking;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(P2.canMove == true)
        {
            if(Input.GetButton("Block2"))
            {
                Blocking = true;
            }
            else
            {
                Blocking = false;
            }
        }
    }
}
