using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    private void awake()
    {
        GameObject.FindGameObjectWithTag("Player").transform.position = transform.position;
    }
}
