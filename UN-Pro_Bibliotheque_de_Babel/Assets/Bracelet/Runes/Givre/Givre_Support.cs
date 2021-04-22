using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Givre_Support : MonoBehaviour
{
    public Projectile_Joueur projectile_Joueur;
    public float weakenMultiplier;
    public float weakenDurationMultiplier;
    public float slowMultiplier;
    public float slowDurationMultiplier;

    public int lvlRune;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (lvlRune == 1 || lvlRune == 2)
        {
            //Projectile entre en collision avec un ennemi
            if (collider.gameObject.CompareTag("Ennemy"))
            {
                collider.gameObject.GetComponent<Entities>().StartCoroutine(collider.gameObject.GetComponent<Entities>().SlowEnnemy(projectile_Joueur.slowPower, projectile_Joueur.stuntDuration));
            }

            //Projectile entre en collision avec un boss
            if (collider.gameObject.CompareTag("Boss"))
            {
                collider.gameObject.GetComponent<Entities>().StartCoroutine(collider.gameObject.GetComponent<Entities>().SlowEnnemy(projectile_Joueur.slowPower, projectile_Joueur.stuntDuration));
            }
        }

        if (lvlRune == 3)
        {
            weakenMultiplier = 1.5f;
            weakenDurationMultiplier = 2f;

            slowMultiplier = 0.85f;
            slowDurationMultiplier = 0.75f;

            //Projectile entre en collision avec un ennemi
            if (collider.gameObject.CompareTag("Ennemy"))
            {
                //SuperWeakenEnnemy
                collider.gameObject.GetComponent<Entities>().StartCoroutine(collider.gameObject.GetComponent<Entities>().WeakenEnemy(projectile_Joueur.debuff * weakenMultiplier, projectile_Joueur.debuffDuration * weakenDurationMultiplier));

                //SuperSlowEnnemy
                collider.gameObject.GetComponent<Entities>().StartCoroutine(collider.gameObject.GetComponent<Entities>().SlowEnnemy(projectile_Joueur.slowPower * slowMultiplier, projectile_Joueur.stuntDuration * slowDurationMultiplier));
            }

            //Projectile entre en collision avec un boss
            if (collider.gameObject.CompareTag("Boss"))
            {
                //SuperWeakenEnnemy
                collider.gameObject.GetComponent<Entities>().StartCoroutine(collider.gameObject.GetComponent<Entities>().WeakenEnemy(projectile_Joueur.debuff * weakenMultiplier, projectile_Joueur.debuffDuration * weakenDurationMultiplier));

                //SuperSlowEnnemy
                collider.gameObject.GetComponent<Entities>().StartCoroutine(collider.gameObject.GetComponent<Entities>().SlowEnnemy(projectile_Joueur.slowPower * slowMultiplier, projectile_Joueur.stuntDuration * slowDurationMultiplier));
            }
        }

        

    }
}
/*public Projectile_Joueur projectile_Joueur;
    


    private void OnEnable()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        */