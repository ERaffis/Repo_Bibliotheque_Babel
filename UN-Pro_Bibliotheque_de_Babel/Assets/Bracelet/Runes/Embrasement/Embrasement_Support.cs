using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Embrasement_Support : MonoBehaviour
{
    public Projectile_Joueur projectile_Joueur;
    public int lvlRune;

    private void Start()
    {
        lvlRune = 1;
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(lvlRune == 1)
        { 
            //Projectile entre en contact avec un ennemy
            if (collider.gameObject.CompareTag("Ennemy") || collider.gameObject.CompareTag("Tour"))
            {
                if (collider.gameObject.transform.childCount < 3)
                {
                    collider.gameObject.GetComponent<Entities>().StartCoroutine(collider.GetComponent<Entities>().DamageoverTime(projectile_Joueur.dotDamage, projectile_Joueur.dotDuration));
                }
            }


            //Projectile entre en contact avec un Boss
            if (collider.gameObject.CompareTag("Boss"))
            {
                if (collider.gameObject.transform.childCount < 3)
                {
                    collider.gameObject.GetComponent<Entities>().StartCoroutine(collider.GetComponent<Entities>().DamageoverTime(projectile_Joueur.dotDamage, projectile_Joueur.dotDuration));
                }
            }

            if (collider.gameObject.CompareTag("TargetDummy"))
            {
                collider.gameObject.GetComponent<TargetDummy>().StartCoroutine(collider.GetComponent<TargetDummy>().DamageoverTime(projectile_Joueur.dotDamage, projectile_Joueur.dotDuration));
            }

        }

        if (lvlRune == 2)
        {
            //Projectile entre en contact avec un ennemy
            if (collider.gameObject.CompareTag("Ennemy") || collider.gameObject.CompareTag("Tour"))
            {
                if (collider.gameObject.transform.childCount < 3)
                {
                    collider.gameObject.GetComponent<Entities>().StartCoroutine(collider.GetComponent<Entities>().DamageoverTime(projectile_Joueur.dotDamage, projectile_Joueur.dotDuration*2));
                }
            }


            //Projectile entre en contact avec un Boss
            if (collider.gameObject.CompareTag("Boss"))
            {
                if (collider.gameObject.transform.childCount < 3)
                {
                    collider.gameObject.GetComponent<Entities>().StartCoroutine(collider.GetComponent<Entities>().DamageoverTime(projectile_Joueur.dotDamage, projectile_Joueur.dotDuration*2));
                }
            }

            if (collider.gameObject.CompareTag("TargetDummy"))
            {
                collider.gameObject.GetComponent<TargetDummy>().StartCoroutine(collider.GetComponent<TargetDummy>().DamageoverTime(projectile_Joueur.dotDamage, projectile_Joueur.dotDuration*2));
            }

        }

        if (lvlRune == 3)
        {
            //Projectile entre en contact avec un ennemy
            if (collider.gameObject.CompareTag("Ennemy") || collider.gameObject.CompareTag("Tour"))
            {
                if (collider.gameObject.transform.childCount < 3)
                {
                    collider.gameObject.GetComponent<Entities>().StartCoroutine(collider.GetComponent<Entities>().DamageoverTime(projectile_Joueur.dotDamage, projectile_Joueur.dotDuration*2));
                    StartCoroutine(PlayerScript.Instance.gameObject.GetComponent<PlayerMovement>().BoostSpeed());
                }
            }


            //Projectile entre en contact avec un Boss
            if (collider.gameObject.CompareTag("Boss"))
            {
                if (collider.gameObject.transform.childCount < 3)
                {
                    collider.gameObject.GetComponent<Entities>().StartCoroutine(collider.GetComponent<Entities>().DamageoverTime(projectile_Joueur.dotDamage, projectile_Joueur.dotDuration*2));
                    StartCoroutine(PlayerScript.Instance.gameObject.GetComponent<PlayerMovement>().BoostSpeed());
                }
            }

            if (collider.gameObject.CompareTag("TargetDummy"))
            {
                collider.gameObject.GetComponent<TargetDummy>().StartCoroutine(collider.GetComponent<TargetDummy>().DamageoverTime(projectile_Joueur.dotDamage, projectile_Joueur.dotDuration*2));
            }
        }

    }

}
