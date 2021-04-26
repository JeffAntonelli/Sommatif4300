using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player_;
    [SerializeField] private float smoothing_;
    [SerializeField] private Vector3 offset_;
    
    public static CameraFollow instance;

    private void Awake() 
    {
        if (!instance)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        transform.position = player_.transform.position + offset_;
    }

    void FixedUpdate() // Camera that follows the player
    {
        if (player_ != null)
        {
            Vector3 newPosition = Vector3.Lerp(transform.position, player_.transform.position + offset_, smoothing_);
            transform.position = newPosition;

        }
        else if(player_ == null)
        {
            player_ = GameObject.FindWithTag("Player").GetComponent<Transform>();
        }
    }
    
}