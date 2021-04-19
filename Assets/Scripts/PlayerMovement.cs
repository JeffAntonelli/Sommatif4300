using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float moveSpeed_ = 5f;
    [SerializeField] private Rigidbody2D rb_;
    [SerializeField] private Animator animator_;


    private Vector2 movement_;
    private Vector2 lastMovement_;
    // Update is called once per frame
    private void Update()
    {
        movement_.x = Input.GetAxisRaw("Horizontal");
        movement_.y = Input.GetAxisRaw("Vertical");
        
        if (movement_.x < -0.5f || movement_.x > 0.5f) {
            lastMovement_ = new Vector2(movement_.x, 0.0f);
        }
        if (movement_.y < -0.5f || movement_.y > 0.5f) {
            lastMovement_ = new Vector2(0.0f, movement_.y);
        }
        
        
        animator_.SetFloat("Horizontal", movement_.x);
        animator_.SetFloat("Vertical", movement_.y);
        animator_.SetFloat("Speed", movement_.sqrMagnitude);
        animator_.SetFloat("LastMovementX", lastMovement_.x);
        animator_.SetFloat("LastMovementY", lastMovement_.y);
    }

    private void FixedUpdate()
    {
        rb_.MovePosition(rb_.position + movement_ * (moveSpeed_ * Time.fixedDeltaTime));
    }
}
