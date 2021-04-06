using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Embrasement_Maitresse : MonoBehaviour
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

                collider.GetComponent<Entities>().SetHealth(projectile_Joueur.damage);
                StartCoroutine(collider.GetComponent<Entities>().DamageoverTime(projectile_Joueur.dotDamage, projectile_Joueur.dotDuration));

                StartCoroutine(DisableProjectile());
            }
        }

        //Projectile entre en contact avec un Boss
        if (collider.gameObject.CompareTag("Boss"))
        {
            Debug.Log("The Boss was hit");
            Destroy(gameObject);
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
