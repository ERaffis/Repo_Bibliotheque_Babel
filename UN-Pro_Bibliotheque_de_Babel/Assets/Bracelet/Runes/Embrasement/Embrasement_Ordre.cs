using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Embrasement_Ordre : MonoBehaviour
{
    public Projectile_Joueur projectile_Joueur;
    public GameObject AoE_Feu;

    private void OnTriggerEnter2D(Collider2D collider)
    {
       
        if (collider.gameObject.CompareTag("Ennemy"))
        {    
            if (collider.gameObject.transform.childCount < 3)
            { 
                Transform ennemyTransform = collider.gameObject.transform;
                transform.parent = ennemyTransform;

                Vector3 position = Instantiate(AoE_Feu, transform.position, Quaternion.identity).transform.position;
                Instantiate(AoE_Feu, transform.position, Quaternion.identity);

                collider.gameObject.GetComponent<Entities>().StartCoroutine(collider.gameObject.GetComponent<Entities>().AoEEffect(position, projectile_Joueur.dotDuration, projectile_Joueur.dotDamage));
            }
        }

        if (collider.gameObject.CompareTag("Boss"))
        {
            
        }
    } 
}