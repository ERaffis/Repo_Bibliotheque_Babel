using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Embrasement_Projectile : MonoBehaviour
{
    public int numberOfTick;
    public int dotDamage;
    public int damage;
    public Transform ennemyTransform;

    private void Update()
    {
        if(ennemyTransform != null)
            transform.transform.position = ennemyTransform.position;
    }
    //Collision pour le DOT
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player1") )
        {
            if (collision.gameObject.layer == 6)
            {
                if(collision.gameObject.transform.childCount < 3)
                {
                    ennemyTransform = collision.gameObject.transform;
                    transform.parent = ennemyTransform;

                    collision.GetComponent<Entities>().currentHealth -= damage;
                    StartCoroutine(DamageoverTime(collision.gameObject));

                    StartCoroutine(DisableProjectile());
                }
            }

            if (collision.gameObject.layer == 9)
            {
                StartCoroutine(ExplodeProjectile());
            }
        }
    }

    //Dégâts sur l'ennemi
    public IEnumerator DamageoverTime(GameObject col)
    {
        if (col.GetComponent<Entities>().isTakingDamage == false)
        {
            col.GetComponent<Entities>().isTakingDamage = true;

            for (int i = 0; i <= numberOfTick; i++)
            {

                col.GetComponent<Entities>().currentHealth -= dotDamage;

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
