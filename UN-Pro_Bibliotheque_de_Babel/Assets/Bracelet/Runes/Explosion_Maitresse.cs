using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion_Maitresse : MonoBehaviour
{
    public Projectile_Joueur projectile_Joueur;



    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == 6 && !collider.gameObject.CompareTag("Player1"))
        {
            
            Vector2 explosionPos = transform.position;
            
            Collider2D[] colliders = Physics2D.OverlapCircleAll(explosionPos, projectile_Joueur.aoeSize);

            


            foreach (Collider2D hit in colliders)
            {
               //hit.attachedRigidbody.AddExplosionForce(projectile_Joueur.explosionForce, explosionPos, projectile_Joueur.aoeSize, 0);
                if (colliders.Length == 1)
                {
                    if (hit.gameObject.CompareTag("Ennemy") )
                        hit.GetComponent<Entities>().SetHealth((int) projectile_Joueur.damage);

                }
                else if (colliders.Length==2)
                {
                    if (hit.gameObject.CompareTag("Ennemy"))
                        hit.GetComponent<Entities>().SetHealth((int)projectile_Joueur.damage);
                }
                else if (colliders.Length == 3)
                {
                    if (hit.gameObject.CompareTag("Ennemy"))
                        hit.GetComponent<Entities>().SetHealth((int)projectile_Joueur.damage);
                }
                else
                {
                    if (hit.gameObject.CompareTag("Ennemy"))
                        hit.GetComponent<Entities>().SetHealth((int)projectile_Joueur.damage);
                }

            }

            Destroy(gameObject);
        }

        
    }
}
