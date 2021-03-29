using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Embrasement_Ordre : MonoBehaviour
{
    public Projectile_Joueur projectile_Joueur;
    public GameObject AoE_Feu;

   /* public void SpawnFeu()
    {
        Instantiate(AoE_Feu, transform.position, Quaternion.identity);
    }
*/
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player1"))
        {
            if (collision.gameObject.layer == 6)
            {

                
                if (collision.gameObject.transform.childCount < 3) //demander edouard pour childcount
                {

                    Transform ennemyTransform = collision.gameObject.transform;
                    transform.parent = ennemyTransform;

                    Vector3 position = Instantiate(AoE_Feu, transform.position, Quaternion.identity).transform.position;
                    //Instantiate(AoE_Feu, transform.position, Quaternion.identity);
                    

                    StartCoroutine(DisableProjectile());
                    StartCoroutine(AoEEffect(position));
                }

            }

            if (collision.gameObject.layer == 9)
            {
                StartCoroutine(ExplodeProjectile());
               
            }
        }

    }

    IEnumerator AoEEffect(Vector3 position)
    {
        int i = 0;
        while ( i < projectile_Joueur.dotDuration)
        {
            Collider[] hitColliders = Physics.OverlapSphere(position, 1.65f);
            int j = 0;
            while (j < hitColliders.Length)
            {
                hitColliders [j].GetComponent<Entities>().SetHealth(projectile_Joueur.dotDamage);
                j++;
            }
            i++;

            yield return new WaitForSeconds(.2f);
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