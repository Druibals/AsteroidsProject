using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidControl : MonoBehaviour
{
    public float speed_min;
    public float speed_max;
    Rigidbody2D asteroidRigidBody;
    public AsteroidManager manager;
    // Start is called before the first frame update
    void Start()
    {
        asteroidRigidBody = GetComponent<Rigidbody2D>();
        Vector2 direccion = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        direccion = direccion * Random.Range(speed_min, speed_max);
        asteroidRigidBody.AddForce(direccion);
        manager.conteoasteroide += 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Muerte()
    {
        if(transform.localScale.x > 0.25f)
        {

        GameObject temp1 = Instantiate(manager.asteroide, transform.position, transform.rotation);
        temp1.GetComponent<AsteroidControl>().manager = manager;
        temp1.transform.localScale = transform.localScale * 0.5f;

        GameObject temp2 = Instantiate(manager.asteroide, transform.position, transform.rotation);
        temp2.GetComponent<AsteroidControl>().manager = manager;
        temp2.transform.localScale = transform.localScale * 0.5f;

        }
        GameManager.instance.puntuacion += 25;
        manager.conteoasteroide -= 1;


        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerMovement>().Muerte();
        }
    }
}
