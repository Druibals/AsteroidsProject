using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotControl : MonoBehaviour
{
    public float speed = 10;
    Rigidbody2D lasershotRB;
    // Start is called before the first frame update
    void Start()
    {
        lasershotRB = GetComponent<Rigidbody2D>();
        lasershotRB.AddForce(transform.up * speed);
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag ("Asteroid")) 
        {
            collision.gameObject.GetComponent<AsteroidControl>().Muerte();
            Destroy(gameObject);
        }
        if(collision.CompareTag ("UFO"))
        {
            collision.gameObject.GetComponent<UFOControl>().Muerte();
            Destroy(gameObject);
        }
    }

}
