using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FramesToSec : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public float Seconds(float Frames)
    {
        float SecondsCon = Frames / 60;
        return SecondsCon;
    }
}
