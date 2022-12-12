using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallAngle : MonoBehaviour
{
    public GameObject Player2;
    public P1Health P1H;
    private GameObject Self;
    public float Speed;
    public float Damage;
    public float Life;
    public int Angle;
    void Start()
    {
        Player2 = GameObject.FindGameObjectWithTag("Player2");
        P1H = GameObject.FindGameObjectWithTag("Player1").GetComponent<P1Health>();
        if(Player2.transform.localScale.x < 0)
        {
            Angle -= 40;
        }
        transform.rotation = Quaternion.Euler(0,0,Angle);
    }

    // Update is called once per frame
    void Update()
    {
        Life -= Time.deltaTime;
        if(Life <= 0 )
        {
            Destroy(this.gameObject);
        }
        
        transform.Translate(transform.right * Speed);
        //transform.position += -Player2.transform.localScale.x * transform.right * Speed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player1"))
        {
            Debug.Log("Bullet hit");
            P1H.Health -= Damage;
            Destroy(this.gameObject);
        }
    }
}
