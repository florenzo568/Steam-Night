using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public GameObject Player1;
    public P2Health P2H;
    public float Speed;
    public float Damage;
    public float Life;
    void Start()
    {
        Player1 = GameObject.FindGameObjectWithTag("Player1");
        P2H = GameObject.FindGameObjectWithTag("Player2").GetComponent<P2Health>();
    }

    // Update is called once per frame
    void Update()
    {
        Life -= Time.deltaTime;
        if(Life <= 0 )
        {
            Destroy(this.gameObject);
        }
        transform.position += Player1.transform.localScale.x * transform.right * Speed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player2"))
        {
            Debug.Log("Bullet hit");
            P2H.Health -= Damage;
            Destroy(this.gameObject);
        }
    }
}
