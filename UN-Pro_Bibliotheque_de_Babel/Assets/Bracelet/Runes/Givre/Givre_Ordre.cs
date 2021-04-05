using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Givre_Ordre : MonoBehaviour
{
    public Projectile_Joueur projectile_Joueur;
    public float weakenMultiplier;
    public float weakenDurationMultiplier;
    public float slowMultiplier;
    public float slowDurationMultiplier;


    private void OnEnable()
    {
        weakenMultiplier = 1.5f;
        weakenDurationMultiplier = 2f;

        slowMultiplier = 0.85f;
        slowDurationMultiplier = 0.75f;
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        //Projectile entre en collision avec un ennemi
        if (collider.gameObject.CompareTag("Ennemy"))
        {
            //SuperWeakenEnnemy
            StartCoroutine(collider.gameObject.GetComponent<Entities>().WeakenEnemy(projectile_Joueur.debuff * weakenMultiplier, projectile_Joueur.debuffDuration * weakenDurationMultiplier));

            //SuperSlowEnnemy
            StartCoroutine(collider.gameObject.GetComponent<Entities>().SlowEnnemy(projectile_Joueur.slowPower * slowMultiplier, projectile_Joueur.stuntDuration * slowDurationMultiplier));
        }

        //Projectile entre en collision avec un boss
        if (collider.gameObject.CompareTag("Boss"))
        {

        }

    }
}
