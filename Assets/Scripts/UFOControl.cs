using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class UFOControl : MonoBehaviour
{
    public float speed = 10;
    CapsuleCollider2D capsuleCollider;
    Rigidbody2D Rigidbody2D;
    public GameObject bala;
    public GameObject boquilla;
    public float firerate = 0.5f;
    public float nextfire = 0.0f;
    public UFOManager manager;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Vector2 direccion = new Vector2(Random.Range(-1f, 1f), 0);
        direccion = direccion * speed;
        Rigidbody2D.AddForce(direccion);

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextfire)
        {
            float x = transform.position.x;
            float y = transform.position.y;
            Vector3 shotpos = new Vector3(x, y, 0);
            Vector3 shotangle = new Vector3(Random.Range(180, -180), Random.Range(0, -90));
            GameObject temp = Instantiate(bala, shotpos, Quaternion.Euler(shotangle));
            nextfire = Time.time + firerate;
            Destroy(temp, 5f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag =="Player")
        {
            collision.gameObject.GetComponent<PlayerMovement>().Muerte();
        }
    }

    public void Muerte()
    {
        GameManager.instance.puntuacion += 500;
        manager.conteoufo -= 1;
        Destroy(gameObject);
    }
}

