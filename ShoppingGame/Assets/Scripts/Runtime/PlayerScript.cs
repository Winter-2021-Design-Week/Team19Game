using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;

    [SerializeField]
    float speed = 3f, currentSpeed;
    Vector2 stepDirection;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            stepDirection.y = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            stepDirection.y = -1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            stepDirection.x = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            stepDirection.x = 1;
        }
    }

    private void FixedUpdate()
    {
        stepDirection.Normalize();

        rb.MovePosition((Vector2)transform.position + stepDirection * speed * Time.deltaTime);

        currentSpeed = rb.velocity.magnitude;

        // Temporary animation parameter output
        anim.SetFloat("currentSpeed", stepDirection.magnitude);

        if (stepDirection.y > 0)
        {
            anim.SetBool("up", false);
        }
        if (stepDirection.y < 0)
        {
            anim.SetBool("up", true);
        }
        if (stepDirection.x > 0)
        {
            anim.SetBool("right", true);
        }
        if (stepDirection.x < 0)
        {
            anim.SetBool("right", false);
        }

        stepDirection = Vector2.zero;
    }
}
