using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1Health : MonoBehaviour
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
            Debug.Log("P1 Dead");
        }
    }
}
