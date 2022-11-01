using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CircleCollider2D circleCollider;
    SpriteRenderer spriteRenderer;
    Rigidbody2D Nave_rigidbody;
    Animator animator;
    public float speed = 10;
    public float rotationSpeed = 10;
    public GameObject bala;
    public GameObject boquilla;
    public GameObject particulaMuerte;
    bool muerto;

    // Start is called before the first frame update
    void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        Nave_rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (muerto == false)
        {
            float vertical = Input.GetAxis("Vertical");
            if(vertical > 0)
            {
                Nave_rigidbody.AddForce(transform.up * vertical * speed * Time.deltaTime);
                animator.SetBool("MoveBoolean", true);
            }
            else
            {
            animator.SetBool("MoveBoolean", false);
            }
            float horizontal = Input.GetAxis("Horizontal");
            transform.eulerAngles = transform.eulerAngles - new Vector3(0, 0, horizontal * rotationSpeed * Time.deltaTime);

            if (Input.GetButtonDown("Jump"))
            {

                GameObject temp = Instantiate(bala, boquilla.transform.position, transform.rotation);
                Destroy(temp, 1.5f);
            }
        }
    }

    public void Muerte()
    {
        GameObject temp = Instantiate(particulaMuerte, transform.position, transform.rotation);
        Destroy(temp, 2.5f);

        StartCoroutine(Respawn_Coroutine());

    }

    IEnumerator Respawn_Coroutine()
    {
        muerto = true;
        circleCollider.enabled = false;
        spriteRenderer.enabled = false;
        yield return new WaitForSeconds(2);
        GameManager.instance.vidas -= 1;
        if (
            GameManager.instance.vidas <= 0)
        {
            Destroy(gameObject);
            Time.timeScale = 0;
        }
        transform.position = new Vector3(0, 0, 0);
        Nave_rigidbody.velocity = new Vector2(0, 0);
        muerto = false;
        spriteRenderer.enabled = true;
        yield return new WaitForSeconds(5); //Respawn Inmunity
        circleCollider.enabled = true;
    }
}   
