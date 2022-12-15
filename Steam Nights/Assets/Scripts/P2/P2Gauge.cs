using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class P2Gauge : MonoBehaviour
{
    public float Steam;
    public float Night;
    public int Ammo = 8;
    public int Hot;
    public TextMeshProUGUI count;
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
        count.text = Ammo.ToString();
    }
}
