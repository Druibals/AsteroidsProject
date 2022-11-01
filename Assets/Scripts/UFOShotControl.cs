using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOShotControl : MonoBehaviour
{
    public float speed = 10;
    Rigidbody2D rigidbody2D;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.AddForce(transform.up * speed);
    }

    private void Update()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerMovement>().Muerte();
            Destroy(gameObject);
        }
    }
}
