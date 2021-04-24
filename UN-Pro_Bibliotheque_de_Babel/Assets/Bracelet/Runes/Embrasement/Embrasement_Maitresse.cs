using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Embrasement_Maitresse : MonoBehaviour
{
    public Projectile_Joueur projectile_Joueur;
    public int lvlRune;


    void OnTriggerEnter2D(Collider2D collider)
    {
        if (lvlRune == 1)
        {
            //Projectile entre en contact avec un ennemy
            if (collider.gameObject.CompareTag("Ennemy") || collider.gameObject.CompareTag("Tour"))
            {
                if (collider.gameObject.transform.childCount < 3)
                {

                    Transform ennemyTransform = collider.gameObject.transform;
                    transform.parent = ennemyTransform;

                    collider.GetComponent<Entities>().SetHealth(projectile_Joueur.damage);
                    collider.gameObject.GetComponent<Entities>().StartCoroutine(collider.GetComponent<Entities>().DamageoverTime(projectile_Joueur.dotDamage, projectile_Joueur.dotDuration));

                    DisableProjectile();
                }
            }

            //Projectile entre en contact avec un Boss
            if (collider.gameObject.CompareTag("Boss"))
            {
                Transform ennemyTransform = collider.gameObject.transform;
                transform.parent = ennemyTransform;

                collider.GetComponent<Entities>().SetHealth(projectile_Joueur.damage);
                collider.gameObject.GetComponent<Entities>().StartCoroutine(collider.GetComponent<Entities>().DamageoverTime(projectile_Joueur.dotDamage, projectile_Joueur.dotDuration));
                DisableProjectile();
            }

            if (collider.gameObject.CompareTag("TargetDummy"))
            {
                collider.GetComponent<TargetDummy>().TargetDamage(projectile_Joueur.damage);
                collider.gameObject.GetComponent<TargetDummy>().StartCoroutine(collider.GetComponent<TargetDummy>().DamageoverTime(projectile_Joueur.dotDamage, projectile_Joueur.dotDuration));
                DisableProjectile();
            }

        }

        if (lvlRune == 2)
        {
            //Projectile entre en contact avec un ennemy
            if (collider.gameObject.CompareTag("Ennemy") || collider.gameObject.CompareTag("Tour"))
            {
                if (collider.gameObject.transform.childCount < 3)
                {

                    Transform ennemyTransform = collider.gameObject.transform;
                    transform.parent = ennemyTransform;

                    collider.GetComponent<Entities>().SetHealth(projectile_Joueur.damage);
                    collider.gameObject.GetComponent<Entities>().StartCoroutine(collider.GetComponent<Entities>().DamageoverTime(projectile_Joueur.dotDamage, projectile_Joueur.dotDuration * 2));

                    DisableProjectile();
                }
            }

            //Projectile entre en contact avec un Boss
            if (collider.gameObject.CompareTag("Boss"))
            {
                Transform ennemyTransform = collider.gameObject.transform;
                transform.parent = ennemyTransform;

                collider.GetComponent<Entities>().SetHealth(projectile_Joueur.damage);
                collider.gameObject.GetComponent<Entities>().StartCoroutine(collider.GetComponent<Entities>().DamageoverTime(projectile_Joueur.dotDamage, projectile_Joueur.dotDuration * 2));
                DisableProjectile();
            }

            if (collider.gameObject.CompareTag("TargetDummy"))
            {
                collider.GetComponent<TargetDummy>().TargetDamage(projectile_Joueur.damage);
                collider.gameObject.GetComponent<TargetDummy>().StartCoroutine(collider.GetComponent<TargetDummy>().DamageoverTime(projectile_Joueur.dotDamage, projectile_Joueur.dotDuration * 2));
                DisableProjectile();
            }

        }

        if (lvlRune == 3)
        {
            //Projectile entre en contact avec un ennemy
            if (collider.gameObject.CompareTag("Ennemy") || collider.gameObject.CompareTag("Tour"))
            {
                if (collider.gameObject.transform.childCount < 3)
                {

                    Transform ennemyTransform = collider.gameObject.transform;
                    transform.parent = ennemyTransform;

                    collider.GetComponent<Entities>().SetHealth(projectile_Joueur.damage);
                    collider.gameObject.GetComponent<Entities>().StartCoroutine(collider.GetComponent<Entities>().DamageoverTime(projectile_Joueur.dotDamage, projectile_Joueur.dotDuration * 2));

                    DisableProjectile();
                }
            }

            //Projectile entre en contact avec un Boss
            if (collider.gameObject.CompareTag("Boss"))
            {
                Transform ennemyTransform = collider.gameObject.transform;
                transform.parent = ennemyTransform;

                collider.GetComponent<Entities>().SetHealth(projectile_Joueur.damage);
                collider.gameObject.GetComponent<Entities>().StartCoroutine(collider.GetComponent<Entities>().DamageoverTime(projectile_Joueur.dotDamage, projectile_Joueur.dotDuration * 2));
                StartCoroutine(PlayerScript.Instance.gameObject.GetComponent<PlayerMovement>().BoostSpeed());
                DisableProjectile();
            }

            if (collider.gameObject.CompareTag("TargetDummy"))
            {
                collider.GetComponent<TargetDummy>().TargetDamage(projectile_Joueur.damage);
                collider.gameObject.GetComponent<Entities>().StartCoroutine(collider.GetComponent<Entities>().DamageoverTime(projectile_Joueur.dotDamage, projectile_Joueur.dotDuration * 2));
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
