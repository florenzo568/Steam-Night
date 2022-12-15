using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2Gauge : MonoBehaviour
{
    public float Steam;
    public float Night;
    public int Ammo = 8;
    public int Hot;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Steam >= 100)
        {
            Steam = 100;
        }
    }
}
