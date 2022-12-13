using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallAngle : MonoBehaviour
{
    public GameObject Player2;
    public P1Health P1H;
    public P2Gauge P2G;
    public P1Blocking P1B;
    private GameObject Self;
    public bool Hot;
    public float Speed;
    public float Damage;
    public float Life;
    public int Angle;
    void Start()
    {
        Player2 = GameObject.FindGameObjectWithTag("Player2");
        P1H = GameObject.FindGameObjectWithTag("Player1").GetComponent<P1Health>();
        P1B = GameObject.FindGameObjectWithTag("Player1").GetComponent<P1Blocking>();
        P2G = GameObject.FindGameObjectWithTag("Player2").GetComponent<P2Gauge>();
        if(Player2.transform.localScale.x < 0)
        {
            Angle -= 40;
        }
        transform.rotation = Quaternion.Euler(0,0,Angle);
        if(P2G.Hot > 0)
        {
            Hot = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Life -= Time.deltaTime;
        if(Life <= 0 )
        {
            Destroy(this.gameObject);
            if(Hot)
            {
                P2G.Hot -= 1;
            }
        }
        
        transform.Translate(transform.right * Speed);
        //transform.position += -Player2.transform.localScale.x * transform.right * Speed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player1") && !Hot && P1B.Blocking == false)
        {
            Debug.Log("Bullet hit");
            P1H.Health -= Damage;
            Destroy(this.gameObject);
        }
        else if(other.gameObject.CompareTag("Player1") && Hot)
        {
            P2G.Hot -= 1;
            P1H.Health -= 90;
        }
    }
}
