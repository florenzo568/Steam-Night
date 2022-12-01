using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1Blocking : MonoBehaviour
{
    [SerializeField] P1Move P1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Dash") && P1.horizontal == 0 && P1.canMove)
        {
            Debug.Log("Blocking");
        }
    }
}
