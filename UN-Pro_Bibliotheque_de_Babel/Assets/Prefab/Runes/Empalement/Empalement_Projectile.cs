using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Empalement_Projectile : MonoBehaviour
{
    public float rootTime;
    public Transform ennemyTransform;

    private void Update()
    {
        if(ennemyTransform != null)
            transform.transform.position = ennemyTransform.position;
    }

    //Gestion collision
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player1"))
        {
            if (collision.gameObject.layer == 6)
            {
                if (collision.gameObject.transform.childCount <= 3)
                {
                    ennemyTransform = collision.gameObject.transform;
                    transform.parent = ennemyTransform;

                    StartCoroutine(RootEnemy(collision.gameObject));

                    StartCoroutine(DisableProjectile());
                }
            }

            if (collision.gameObject.layer == 9)
            {
                StartCoroutine(ExplodeProjectile());
            }
        }
    }

    private IEnumerator RootEnemy(GameObject enemy)
    {

        if (enemy.TryGetComponent(out Ennemi2_Biome1 a))
        {
            enemy.GetComponent<Ennemi2_Biome1>().SetMovement();
            yield return new WaitForSeconds(rootTime);
            enemy.GetComponent<Ennemi2_Biome1>().SetMovement();
            Destroy(gameObject);

        }
        else if (enemy.TryGetComponent(out Entities b))
        {
            enemy.GetComponent<Entities>().SetMovement();
            yield return new WaitForSeconds(rootTime);
            enemy.GetComponent<Entities>().SetMovement();
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

        yield return new WaitForSeconds(.2f);

        if (TryGetComponent(out Effector2D c))
            Destroy(c);

        yield return new WaitForSeconds(2.5f);
    }

    IEnumerator ExplodeProjectile()
    {
        yield return new WaitForSeconds(0.01f);
        Destroy(this.gameObject);
    }
}
