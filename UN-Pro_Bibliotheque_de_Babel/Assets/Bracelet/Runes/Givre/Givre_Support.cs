using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Givre_Support : MonoBehaviour
{
    public Projectile_Joueur projectile_Joueur;
    void OnTriggerEnter2D(Collider2D collider)
    {
        //Projectile entre en collision avec un ennemi
        if (collider.gameObject.CompareTag("Ennemy"))
        {
            collider.gameObject.GetComponent<Entities>().StartCoroutine(collider.gameObject.GetComponent<Entities>().SlowEnnemy(projectile_Joueur.slowPower, projectile_Joueur.stuntDuration));
        }

        //Projectile entre en collision avec un boss
        if (collider.gameObject.CompareTag("Boss"))
        {

        }

    }
}
