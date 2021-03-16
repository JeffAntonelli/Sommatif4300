using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float moveSpeed_ = 5f;
    [SerializeField] private Rigidbody2D rb_;
    [SerializeField] private Animator animator_;


    private Vector2 movement;
    // Update is called once per frame
    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        
        animator_.SetFloat("Horizontal", movement.x);
        animator_.SetFloat("Vertical", movement.y);
        animator_.SetFloat("Speed", movement.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        rb_.MovePosition(rb_.position + movement * (moveSpeed_ * Time.fixedDeltaTime));
    }
}
