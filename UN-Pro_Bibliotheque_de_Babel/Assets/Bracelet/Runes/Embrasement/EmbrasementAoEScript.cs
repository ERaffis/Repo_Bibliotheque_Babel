using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmbrasementAoEScript : MonoBehaviour
{
    public Projectile_Joueur projectile_Joueur;
    public int dmg;

    private void Start()
    {
        dmg = projectile_Joueur.dotDamage;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        //Projectile entre en collision avec un ennemi
        if (collision.gameObject.CompareTag("Ennemy"))
        {
            collision.gameObject.GetComponent<Entities>().SetHealth(dmg);
        }

        //Projectile entre en collision avec un boss
        if (collision.gameObject.CompareTag("Boss"))
        {
            collision.gameObject.GetComponent<Entities>().SetHealth(dmg);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //Projectile entre en collision avec un ennemi
        if (collision.gameObject.CompareTag("Ennemy"))
        {
            collision.gameObject.GetComponent<Entities>().SetHealth(dmg);
        }

        //Projectile entre en collision avec un boss
        if (collision.gameObject.CompareTag("Boss"))
        {
            collision.gameObject.GetComponent<Entities>().SetHealth(dmg);
        }
    }
}
