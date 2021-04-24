using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Givre_Maitresse : MonoBehaviour
{

    public Projectile_Joueur projectile_Joueur;

    public int lvlRune;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (lvlRune == 1)
        {
            //Projectile entre en collision avec un ennemi
            if (collider.gameObject.CompareTag("Ennemy"))
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
                collider.gameObject.GetComponent<Entities>().StartCoroutine(collider.gameObject.GetComponent<Entities>().WeakenEnemy(projectile_Joueur.debuff, projectile_Joueur.debuffDuration));
                collider.gameObject.GetComponent<Entities>().StartCoroutine(collider.gameObject.GetComponent<Entities>().StunEnnemy(projectile_Joueur.stuntDuration));

                //Damage Enemy
                collider.GetComponent<Entities>().SetHealth(projectile_Joueur.damage);

                //DestroyProjectile
                DisableProjectile();
            }

            if (collider.gameObject.CompareTag("TargetDummy"))
            {
                collider.GetComponent<TargetDummy>().TargetDamage(projectile_Joueur.damage);
                DisableProjectile();
            }
        }

        if (lvlRune == 2 || lvlRune == 3)
        {
            //Projectile entre en collision avec un ennemi
            if (collider.gameObject.CompareTag("Ennemy"))
            {
                //Debuff & Stun Enemy
                collider.gameObject.GetComponent<Entities>().StartCoroutine(collider.gameObject.GetComponent<Entities>().WeakenEnemy(projectile_Joueur.debuff, projectile_Joueur.debuffDuration));
                collider.gameObject.GetComponent<Entities>().StartCoroutine(collider.gameObject.GetComponent<Entities>().StunEnnemy(projectile_Joueur.stuntDuration));

                //Damage Enemy
                collider.GetComponent<Entities>().SetHealth(projectile_Joueur.damage + 80);

                //DestroyProjectile
                DisableProjectile();

            }

            if (collider.gameObject.CompareTag("Tour"))
            {
                //Damage Enemy
                if (collider != null)
                    collider.GetComponent<Entities>().SetHealth(projectile_Joueur.damage + 80);

                //DestroyProjectile
                DisableProjectile();

            }

            //Projectile entre en collision avec un boss
            if (collider.gameObject.CompareTag("Boss"))
            {
                collider.gameObject.GetComponent<Entities>().StartCoroutine(collider.gameObject.GetComponent<Entities>().WeakenEnemy(projectile_Joueur.debuff, projectile_Joueur.debuffDuration));
                collider.gameObject.GetComponent<Entities>().StartCoroutine(collider.gameObject.GetComponent<Entities>().StunEnnemy(projectile_Joueur.stuntDuration));

                //Damage Enemy
                collider.GetComponent<Entities>().SetHealth(projectile_Joueur.damage + 80);

                //DestroyProjectile
                DisableProjectile();
            }

            if (collider.gameObject.CompareTag("TargetDummy"))
            {
                collider.GetComponent<TargetDummy>().TargetDamage(projectile_Joueur.damage + 80);
                DisableProjectile();
            }
        }



    }


    void DisableProjectile()
    {
        //Faire Explosion de particules
        Destroy(gameObject);
    }

}
