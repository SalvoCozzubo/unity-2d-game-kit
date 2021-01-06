using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private InputManager input;
    private Animator animator;
    private Rigidbody2D rb;
    private Vector2 movePlayer;

    [Header("Movement")]
    [SerializeField]
    private float speed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        movePlayer = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void LateUpdate()
    {
        rb.MovePosition(rb.position + movePlayer * speed * Time.fixedDeltaTime);
    }

    void Move()
    {
        movePlayer.y = input.GetVerticalAxis();
        movePlayer.x = input.GetHorizontalAxis();

        if (movePlayer != Vector2.zero) {
            animator.SetFloat("PosX", movePlayer.x);
            animator.SetFloat("PosY", movePlayer.y);
        }

        animator.SetFloat("Speed", movePlayer.sqrMagnitude);
    }
}
