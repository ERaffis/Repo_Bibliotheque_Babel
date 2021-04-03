using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Givre_Maitresse : MonoBehaviour
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

                if (TryGetComponent(out SpriteRenderer a))
                {
                    Destroy(a);
                }

                collider.GetComponent<Entities>().SetHealth((int)projectile_Joueur.damage);
                StartCoroutine(StunEnnemy(collider.gameObject));

                StartCoroutine(DisableProjectile());
            }
        }

        if (collider.gameObject.CompareTag("Boss"))
        {
            Debug.Log("The Boss was hit");
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator StunEnnemy(GameObject ennemy)
    {
        if (ennemy.TryGetComponent(out Entities ent))
            ent.isStuned = true;

        yield return new WaitForSeconds(projectile_Joueur.stuntDuration);

        ent.isStuned = false;
    }

    IEnumerator DisableProjectile()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        Destroy(gameObject, projectile_Joueur.stuntDuration + 2f);
        if (TryGetComponent(out Collider2D a))
            Destroy(a);
        if (TryGetComponent(out Collider2D b))
            Destroy(b);

        yield return new WaitForSeconds(.2f);

        if (TryGetComponent(out AreaEffector2D c))
            Destroy(c);

        yield return new WaitForSeconds(2.5f);
    }
}
