using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class NPCBehavior : MonoBehaviour
{

    [SerializeField] private GameObject textBox_;
    
    
    // Start is called before the first frame update
    void Start()
    {
        textBox_.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            textBox_.SetActive(true);
            Debug.Log("Hi");
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            textBox_.SetActive(false);
            Debug.Log("Bye");
        }
    }
}
