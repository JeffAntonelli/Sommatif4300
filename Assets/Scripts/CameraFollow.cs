using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] private Transform player_;
    private float zPosition_ = -10;
    private void FixedUpdate()
    {
        transform.position = new Vector3(player_.position.x, player_.position.y, zPosition_);
    }
}
