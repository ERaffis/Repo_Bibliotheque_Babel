using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Embrasement_Support : MonoBehaviour
{
    public Projectile_Joueur projectile_Joueur;

    void OnTriggerEnter2D(Collider2D collider)
    {
        //Projectile entre en contact avec un ennemy
        if (collider.gameObject.CompareTag("Ennemy"))
        {
            if (collider.gameObject.transform.childCount < 3)
            {

                Transform ennemyTransform = collider.gameObject.transform;
                transform.parent = ennemyTransform;

                StartCoroutine(collider.GetComponent<Entities>().DamageoverTime(projectile_Joueur.dotDamage, projectile_Joueur.dotDuration));

            }
        }

        //Projectile entre en contact avec un Boss
        if (collider.gameObject.CompareTag("Boss"))
        {
            Debug.Log("The Boss was hit");
            Destroy(gameObject);
        }

    }

}
