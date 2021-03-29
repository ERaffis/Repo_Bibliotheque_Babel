using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Embrasement_Maitresse : MonoBehaviour
{
    public Projectile_Joueur projectile_Joueur;

    

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == 6 && !collider.gameObject.CompareTag("Player1"))
        {
            collider.gameObject.GetComponent<Entities>().SetHealth((int)projectile_Joueur.damage);

            Destroy(gameObject);
        }
    }
}
