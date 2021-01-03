using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 movePlayer;

    [Header("Movement")]
    [SerializeField]
    private float speed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
        movePlayer = Vector2.zero;

        movePlayer.y = Input.GetAxisRaw("Vertical");
        movePlayer.x = Input.GetAxisRaw("Horizontal");
    }
}
