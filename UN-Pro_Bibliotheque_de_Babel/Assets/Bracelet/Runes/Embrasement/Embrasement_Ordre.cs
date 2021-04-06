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
       
        if (collision.gameObject.CompareTag("Ennemy"))
        {    
            if (collision.gameObject.transform.childCount < 3) //demander edouard pour childcount
            {

                Transform ennemyTransform = collision.gameObject.transform;
                transform.parent = ennemyTransform;

                Vector3 position = Instantiate(AoE_Feu, transform.position, Quaternion.identity).transform.position;
                Instantiate(AoE_Feu, transform.position, Quaternion.identity);
             
                StartCoroutine(AoEEffect(position));
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
}