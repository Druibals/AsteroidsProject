using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D Nave_rigidbody;
    Animator animator;
    public float speed = 10;
    public float rotationSpeed = 10;
    // Start is called before the first frame update
    void Start()
    {
        Nave_rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
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

    }
}
