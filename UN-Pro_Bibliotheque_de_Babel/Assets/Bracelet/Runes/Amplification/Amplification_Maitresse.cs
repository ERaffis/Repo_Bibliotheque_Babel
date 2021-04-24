using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Amplification_Maitresse : MonoBehaviour
{
    public Projectile_Joueur projectile_Joueur;
    public int lvlRune;

    public void OnEnable()
    {
        transform.localScale = transform.localScale * 2;
        if (lvlRune == 2)
        {
            GetComponent<Rigidbody2D>().velocity *= 1.25f;
        }

        if (lvlRune == 3)
        {
            GetComponent<Rigidbody2D>().velocity *= 1.5f;
        }
    }


    void OnTriggerEnter2D(Collider2D collider)
    {
        if (lvlRune == 1 || lvlRune == 2)
        {
            //Projectile entre en collision avec un ennemi
            if (collider.gameObject.CompareTag("Ennemy") || collider.gameObject.CompareTag("Tour"))
            {
                //Damage Enemy
                collider.GetComponent<Entities>().SetHealth(projectile_Joueur.damage);

                //DestroyProjectile
                DisableProjectile();
            }

            //Projectile entre en collision avec un boss
            if (collider.gameObject.CompareTag("Boss"))
            {
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
        if (lvlRune == 3)
        {
            //Projectile entre en collision avec un ennemi
            if (collider.gameObject.CompareTag("Ennemy") || collider.gameObject.CompareTag("Tour"))
            {
                //Damage Enemy
                collider.GetComponent<Entities>().SetHealth(projectile_Joueur.damage * 1.10f);

                //DestroyProjectile
                DisableProjectile();
            }

            //Projectile entre en collision avec un boss
            if (collider.gameObject.CompareTag("Boss"))
            {
                //Damage Enemy
                collider.GetComponent<Entities>().SetHealth(projectile_Joueur.damage * 1.10f);

                //DestroyProjectile
                DisableProjectile();
            }

            if (collider.gameObject.CompareTag("TargetDummy"))
            {
                collider.GetComponent<TargetDummy>().TargetDamage(projectile_Joueur.damage * 1.10f);
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
