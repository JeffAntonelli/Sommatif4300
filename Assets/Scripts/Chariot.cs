using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chariot : MonoBehaviour
{
    [SerializeField] private Transform player;

    private bool hasPlayer_ = false; // Proximité du joueur pour saisir l'objet.
    private bool beingCarried_ = false; // Est-ce que l'objet est porté.
    private bool touched_ = false; // Detection si on touche un autre collider.

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     // Check distance entre l'objet est le joueur.
     float distance = Vector3.Distance(gameObject.transform.position, player.position);

     // Si moins ou égal 1 unité de distance on peut ramasser.
     if (distance <= 1f)
     {
         hasPlayer_ = true;
     }
     else
     {
         hasPlayer_ = false; // Doit pas y avoir besoin de ce else.
     }

     // Si on peut ramasser et qu'on appuie sur le bouton, on porte l'objet.
     if (hasPlayer_ && Input.GetButtonDown("Jump"))
     {
         GetComponent<Rigidbody2D>().isKinematic = true; // Permet de porter l'objet (Pas sur de l'utillité).
         transform.parent = player; // On change le parent de l' objet.
         beingCarried_ = true; // On porte l'objet.
     }

     // Si on porte l'objet.
     if (beingCarried_)
     {
         // Si on touche un autre collider en portant l'objet.
         if (touched_)
         {
             GetComponent<Rigidbody2D>().isKinematic = false;
             transform.parent = null;
             beingCarried_ = false;
             touched_ = false;
         }

         // Pour lâcher l'objet.
         if (Input.GetButtonDown("Fire1"))
         {
             GetComponent<Rigidbody2D>().isKinematic = false;
             transform.parent = null;
             beingCarried_ = false;
         }
     }
    }

    void onTriggerEnter()
    {
        if (beingCarried_)
        {
            touched_ = true;
        }
    }
}
