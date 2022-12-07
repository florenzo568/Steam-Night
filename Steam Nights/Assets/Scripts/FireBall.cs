using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public GameObject Player1;
    public float Speed;
    public float Life;
    void Start()
    {
        Player1 = GameObject.FindGameObjectWithTag("Player1");
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
            Destroy(this.gameObject);
        }
    }
}
