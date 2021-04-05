using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Embrasement_Maitresse : MonoBehaviour
{
    public Projectile_Joueur projectile_Joueur;

    

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Ennemy"))
        {
            if (collider.gameObject.transform.childCount < 3)
            {

                Transform ennemyTransform = collider.gameObject.transform;
                transform.parent = ennemyTransform;

                collider.GetComponent<Entities>().SetHealth((int)projectile_Joueur.damage);
                StartCoroutine(DamageoverTime(collider.gameObject));

                StartCoroutine(DisableProjectile());
            }
        }

        if (collider.gameObject.CompareTag("Boss"))
        {
            Debug.Log("The Boss was hit");
            Destroy(gameObject);
        }

    }

    public IEnumerator DamageoverTime(GameObject col)
    {
        yield return new WaitForSeconds(.5f);
        if (col.GetComponent<Entities>().isTakingDamage == false)
        {
            col.GetComponent<Entities>().isTakingDamage = true;

            for (int i = 0; i <= projectile_Joueur.dotDuration; i++)
            {

                col.GetComponent<Entities>().SetHealth(projectile_Joueur.dotDamage);

                yield return new WaitForSeconds(.25f);

            }

            col.GetComponent<Entities>().isTakingDamage = false;
        }

        Destroy(this.gameObject);
    }

    IEnumerator DisableProjectile()
    {
        this.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        if (TryGetComponent(out Collider2D a))
            Destroy(a);
        if (TryGetComponent(out Collider2D b))
            Destroy(b);

        yield return new WaitForSeconds(.2f);

        if (TryGetComponent(out AreaEffector2D c))
            Destroy(c);

        yield return new WaitForSeconds(2.5f);
    }

    IEnumerator ExplodeProjectile()
    {
        yield return new WaitForSeconds(0.01f);
        Destroy(this.gameObject);
    }
}
