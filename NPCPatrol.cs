using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class NPCPatrol : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;

    [SerializeField]
    private float speed = 2f;

    [SerializeField]
    private Transform[] waypoints;
    private int currentWaypointIndex = 0;
    private Vector2 move;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        move = waypoints[currentWaypointIndex].position - transform.position;

        if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) < .2f) {
            currentWaypointIndex += 1;

            if (currentWaypointIndex > waypoints.Length - 1) {
                currentWaypointIndex = 0;
            }
        }

        animator.SetFloat("PosX", move.x);
        animator.SetFloat("PosY", move.y);
        animator.SetFloat("Speed", move.sqrMagnitude);
    }

    void LateUpdate()
    {
        rb.MovePosition(rb.position + move * speed * Time.fixedDeltaTime);
    }
}
