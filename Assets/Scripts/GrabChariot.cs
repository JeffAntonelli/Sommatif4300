using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class GrabChariot : MonoBehaviour
{
    [SerializeField] private Text GrabText_;
    [SerializeField] private LayerMask chariotMask_;
    [SerializeField] private float distance;
    private bool grabbed_;
    private RaycastHit2D hit;
    private GameObject chariot_;
    

    private void Start()
    {
        GrabText_.gameObject.SetActive(false);

    }
    // Update is called once per frame
    void Update()
    {
        
        
            Physics2D.queriesStartInColliders = false;
             hit =   Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance, chariotMask_);

             if (hit.collider != null && hit.collider.gameObject.tag == "Chariot" && Input.GetKey(KeyCode.Space))
             {
                 chariot_ = hit.collider.gameObject;

                 chariot_.GetComponent<FixedJoint2D>().enabled = true;
                 chariot_.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
             }

             else if (Input.GetKeyUp(KeyCode.Space))
             {
                 chariot_.GetComponent<FixedJoint2D>().enabled = false;
                 
             }
    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        Gizmos.DrawLine (transform.position, (Vector2)transform.position + Vector2.right * transform.localScale.x * distance);
    }
}
