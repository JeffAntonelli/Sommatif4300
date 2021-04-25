using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GrabChariot : MonoBehaviour
{
    [SerializeField] private Text GrabText_;
    [SerializeField] private LayerMask chariotMask_;
    [SerializeField] private float distance = 1f;
    private bool grabbed_;
    private RaycastHit2D hitRight_;
    private RaycastHit2D hitLeft_;
    private RaycastHit2D hitUp_;
    private RaycastHit2D hitDown_;
    private GameObject chariot_;

    private void Start()
    {
       

    }
    // Update is called once per frame
    void Update()
    {


            Physics2D.queriesStartInColliders = false;
            RaycastHit2D hitRight = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance, chariotMask_);
            RaycastHit2D hitLeft = Physics2D.Raycast(transform.position, Vector2.left * transform.localScale.x, distance, chariotMask_);
            RaycastHit2D hitUp = Physics2D.Raycast(transform.position, Vector2.up * transform.localScale.x, distance, chariotMask_);
            RaycastHit2D hitDown = Physics2D.Raycast(transform.position, Vector2.down * transform.localScale.x, distance, chariotMask_);

        if (hitRight.collider != null && hitRight.collider.gameObject.tag == "Chariot" && Input.GetButtonDown("Fire2"))
        {
                 chariot_ = hitRight.collider.gameObject;

                 chariot_.GetComponent<FixedJoint2D>().enabled = true;
                 chariot_.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
        }

        else if (hitLeft.collider != null && hitLeft.collider.gameObject.tag == "Chariot" && Input.GetButtonDown("Fire3"))
        {
            chariot_ = hitLeft.collider.gameObject;

            chariot_.GetComponent<FixedJoint2D>().enabled = true;
            chariot_.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
        }

        else if (hitUp.collider != null && hitUp.collider.gameObject.tag == "Chariot" && Input.GetButtonDown("Jump"))
        {
            chariot_ = hitUp.collider.gameObject;

            chariot_.GetComponent<FixedJoint2D>().enabled = true;
            chariot_.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
        }
        else if (hitDown.collider != null && hitDown.collider.gameObject.tag == "Chariot" && Input.GetButtonDown("Fire1"))
        {
            chariot_ = hitDown.collider.gameObject;

            chariot_.GetComponent<FixedJoint2D>().enabled = true;
            chariot_.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
        }

        else if (Input.GetButtonUp("Fire2"))
        {
                 chariot_.GetComponent<FixedJoint2D>().enabled = false;

        }

        else if (Input.GetButtonUp("Fire3"))
        {
            chariot_.GetComponent<FixedJoint2D>().enabled = false;

        }

        else if (Input.GetButtonUp("Jump"))
        {
            chariot_.GetComponent<FixedJoint2D>().enabled = false;

        }

        else if (Input.GetButtonUp("Fire1"))
        {
            chariot_.GetComponent<FixedJoint2D>().enabled = false;

        }
    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        Gizmos.DrawLine( transform.position, (Vector2)transform.position + Vector2.right * transform.localScale.x * distance);
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + Vector2.left * transform.localScale.x * distance);
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + Vector2.up * transform.localScale.x * distance);
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + Vector2.down * transform.localScale.x * distance);
    }
}


