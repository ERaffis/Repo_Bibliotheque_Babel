using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Empalement_Support : MonoBehaviour
{
    public float rootTime;

    //Gestion collision
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player1"))
        {
            if (collision.gameObject.layer == 6)
            {
                if (collision.gameObject.transform.childCount <= 3)
                {
                    StartCoroutine(RootEnemy(collision.gameObject));
                }
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
        }
        else if (enemy.TryGetComponent(out Entities b))
        {
            enemy.GetComponent<Entities>().SetMovement();
            yield return new WaitForSeconds(rootTime);
            enemy.GetComponent<Entities>().SetMovement();
        }

    }
}
