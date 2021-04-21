using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Givre_Maitresse : MonoBehaviour
{

    public Projectile_Joueur projectile_Joueur;

    void OnTriggerEnter2D(Collider2D collider)
    {
        //Projectile entre en collision avec un ennemi
        if (collider.gameObject.CompareTag("Ennemy" ))
        {
            //Debuff & Stun Enemy
            collider.gameObject.GetComponent<Entities>().StartCoroutine(collider.gameObject.GetComponent<Entities>().WeakenEnemy(projectile_Joueur.debuff, projectile_Joueur.debuffDuration));
            collider.gameObject.GetComponent<Entities>().StartCoroutine(collider.gameObject.GetComponent<Entities>().StunEnnemy(projectile_Joueur.stuntDuration));
            
            //Damage Enemy
            collider.GetComponent<Entities>().SetHealth(projectile_Joueur.damage);

            //DestroyProjectile
            DisableProjectile();
            
        }

        if (collider.gameObject.CompareTag("Tour"))
        {
            //Damage Enemy
            if (collider != null)
                collider.GetComponent<Entities>().SetHealth(projectile_Joueur.damage);

            //DestroyProjectile
            DisableProjectile();

        }

        //Projectile entre en collision avec un boss
        if (collider.gameObject.CompareTag("Boss"))
        {
            Debug.Log("The Boss was hit");
            DisableProjectile();
        }

    }


    void DisableProjectile()
    {
        //Faire Explosion de particules
        Destroy(gameObject);
    }

}
