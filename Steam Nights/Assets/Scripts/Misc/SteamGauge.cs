using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SteamGauge : MonoBehaviour
{
    [SerializeField] Image SteamBar1;
    [SerializeField] Image SteamBar2;
    [SerializeField] P1Gauge P1G;
    [SerializeField] P2Gauge P2G;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SteamBar1.fillAmount = P1G.Steam / 100;
        SteamBar2.fillAmount = P2G.Steam / 100;
    }
}
