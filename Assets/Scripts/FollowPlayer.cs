using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public float walkSpeed = 5.0f;
    public float range = 10.0f;
    private float distToPlayer;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        distToPlayer = Vector2.Distance(transform.position, player.transform.position);
        
        if(distToPlayer <= range && distToPlayer >= 5)
        {
            Vector3 direction = player.transform.position - transform.position;
            rb.MovePosition(transform.position + (direction * walkSpeed * Time.deltaTime));
        }
    }
}
