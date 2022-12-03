using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1Blocking : MonoBehaviour
{
    [SerializeField] P1Move P1;
    public bool Blocking;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(P1.canMove == true)
        {
            if(Input.GetButton("Block"))
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
