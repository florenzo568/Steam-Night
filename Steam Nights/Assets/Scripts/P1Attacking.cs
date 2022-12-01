using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1Attacking : MonoBehaviour
{
    [SerializeField] P1Move P1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && P1.IsGrounded())
        {
            StartCoroutine(P1.GetComponent<P1Light>().Light());
        }
    }
}
