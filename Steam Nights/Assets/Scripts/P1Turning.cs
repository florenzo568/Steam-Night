using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1Turning : MonoBehaviour
{
    [SerializeField] GameObject P1;
    [SerializeField] GameObject P2;
    public bool Flip;
    private bool Last;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float dist = P1.transform.position.x - P2.transform.position.x;
        if(dist < 0)
        {
            Flip = false;
        }
        else if(dist >= 0)
        {
            Flip = true;
        }

        
    }
}
