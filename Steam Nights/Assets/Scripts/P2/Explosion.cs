using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float ExpoTime;
    public P1Blocking P1B;
    public P1Health P1H;
    public float Damage;

    void Awake()
    {
        P1H = GameObject.FindGameObjectWithTag("Player1").GetComponent<P1Health>();
        P1B = GameObject.FindGameObjectWithTag("Player1").GetComponent<P1Blocking>();
    }

    // Update is called once per frame
    void Update()
    {
        ExpoTime -= Time.deltaTime;
        if(ExpoTime <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player1") && P1B.Blocking == false)
        {
            Debug.Log("Trap hit");
            P1H.Health -= Damage;
        }
    }
}
