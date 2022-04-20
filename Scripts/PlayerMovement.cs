using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    public float moveSpeed;

    Vector2 input;
    public Vector3 move;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        input[0] = Input.GetAxis("Horizontal");
        input[1] = Input.GetAxis("Vertical");

        move = new Vector3(input[0] * moveSpeed, input[1] * moveSpeed, 0f);
        animator.SetFloat("Vertical_Speed", input[1]);
        animator.SetFloat("Horizontal_Speed", input[0]);
    }

    //Fixed Update is called a fixed amount of times
    void FixedUpdate()
    {
        rb.velocity = move;
    }
}
