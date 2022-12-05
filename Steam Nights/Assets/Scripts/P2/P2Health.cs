using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2Health : MonoBehaviour
{
    public float Health;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Health <= 0)
        {
            Debug.Log("P2 Dead");
        }
    }
}
