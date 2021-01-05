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

    [SerializeField]
    private float waitTime = 2f;

    [SerializeField]
    private float range = .2f;
    private float nextChangeWaypoint;
    private int currentWaypointIndex = 0;
    private Vector2 move;

    private float currentSpeed = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        nextChangeWaypoint = waitTime;
        currentSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (waypoints.Length == 0) return;
        move = waypoints[currentWaypointIndex].position - transform.position;

        if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) < range)
        {
            currentSpeed = 0;
            nextChangeWaypoint -= Time.deltaTime;

            if (nextChangeWaypoint <= 0) {
                nextChangeWaypoint = waitTime;
                currentWaypointIndex += 1;
                currentSpeed = speed;

                if (currentWaypointIndex > waypoints.Length - 1) {
                    currentWaypointIndex = 0;
                }
            }
        }

        move.Normalize();

        animator.SetFloat("PosX", move.x);
        animator.SetFloat("PosY", move.y);
        animator.SetFloat("Speed", currentSpeed);

        rb.velocity = move * currentSpeed;
    }
}
