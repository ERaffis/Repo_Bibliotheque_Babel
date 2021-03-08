using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Embrasement_Support : MonoBehaviour
{
    public int numberOfTick;
    public int dotDamage;
    public int damage;


    //Collision pour le DOT
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player1") )
        {
            if (collision.gameObject.layer == 6)
            {
                if(collision.gameObject.transform.childCount <= 3)
                {
                    collision.GetComponent<Entities>().currentHealth -= damage;
                    StartCoroutine(DamageoverTime(collision.gameObject));
                }
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
    }
}
