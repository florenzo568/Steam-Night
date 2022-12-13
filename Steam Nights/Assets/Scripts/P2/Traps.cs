using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traps : MonoBehaviour
{
    public GameObject Player2;
    public P2Gauge P2G;
    public P1Health P1H;
    public P1Blocking P1B;
    public float Speed;
    public float Damage;
    public float Life;
    public Rigidbody2D rb;
    public bool foo;
    public float ForceTime;
    void Start()
    {
        Player2 = GameObject.FindGameObjectWithTag("Player2");
        P1H = GameObject.FindGameObjectWithTag("Player1").GetComponent<P1Health>();
        P1B = GameObject.FindGameObjectWithTag("Player1").GetComponent<P1Blocking>();
        P2G = GameObject.FindGameObjectWithTag("Player2").GetComponent<P2Gauge>();
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        //StartCoroutine(Force());

    }

    // Update is called once per frame
    void Update()
    {
        Life -= Time.deltaTime;
        if(Life <= 0 )
        {
            Destroy(this.gameObject);
        }
        if(foo == true)
        {
            rb.AddForce(-Player2.transform.localScale.x * transform.right * Speed);
            ForceTime -= Time.deltaTime;
            if(ForceTime <= 0)
            {
                foo = false;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player1") && P1B.Blocking == false)
        {
            Debug.Log("Trap hit");
            P1H.Health -= Damage;
            Destroy(this.gameObject);
        }
    }

    public IEnumerator Force()
    {
        rb.AddForce(-Player2.transform.localScale.x * transform.right * Speed);
        yield return new WaitForSeconds(ForceTime);
    }
}
