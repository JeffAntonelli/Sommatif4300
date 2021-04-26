using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class NPCBehavior : MonoBehaviour
{

    [SerializeField]  public GameObject textBox_;
    [SerializeField] [TextArea] private string dialogue_;
    
    
    // Start is called before the first frame update
    void Start()
    {
        textBox_.SetActive(false);
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            textBox_.GetComponentInChildren<Text>().text = dialogue_;
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
