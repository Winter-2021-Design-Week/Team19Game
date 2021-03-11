using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;

    [SerializeField]
    float speed = 5f, currentSpeed;
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
        rb.velocity = Vector2.zero;

        stepDirection.Normalize();

        rb.velocity = stepDirection * speed;

        currentSpeed = rb.velocity.magnitude;

        // Temporary animation parameter output
        anim.SetFloat("currentSpeed", currentSpeed);

        anim.SetFloat("currentXSpeed", stepDirection.x);
        anim.SetFloat("currentYSpeed", stepDirection.y);

        stepDirection = Vector2.zero;
    }
}
