using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Givre_Maitresse : MonoBehaviour
{

    public Projectile_Joueur projectile_Joueur;

    void OnTriggerEnter2D(Collider2D collider)
    {
        //Projectile entre en collision avec un ennemi
        if (collider.gameObject.CompareTag("Ennemy"))
        {
            //Debuff & Stun Enemy
            StartCoroutine(collider.gameObject.GetComponent<Entities>().WeakenEnemy(projectile_Joueur.debuff, projectile_Joueur.debuffDuration));
            StartCoroutine(collider.gameObject.GetComponent<Entities>().StunEnnemy(projectile_Joueur.stuntDuration));

            //Damage Enemy
            collider.GetComponent<Entities>().SetHealth(projectile_Joueur.damage);

            //DestroyProjectile
            StartCoroutine(DisableProjectile());
            
        }

        //Projectile entre en collision avec un boss
        if (collider.gameObject.CompareTag("Boss"))
        {
            Debug.Log("The Boss was hit");
            StartCoroutine(DisableProjectile());
        }

    }


    IEnumerator DisableProjectile()
    {
        this.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        if (TryGetComponent(out Collider2D a))
            Destroy(a);
        if (TryGetComponent(out Collider2D b))
            Destroy(b);
        if (TryGetComponent(out AreaEffector2D c))
            Destroy(c);
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }

}
