using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion_Maitresse : MonoBehaviour
{
    public Projectile_Joueur projectile_Joueur;



    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Ennemy") || collider.gameObject.CompareTag("Tour"))
        {
            
            Vector2 explosionPos = transform.position;
            
            Collider2D[] colliders = Physics2D.OverlapCircleAll(explosionPos, projectile_Joueur.aoeSize);


            float tempDmg = projectile_Joueur.damage;
            //hit.attachedRigidbody.AddExplosionForce(projectile_Joueur.explosionForce, explosionPos, projectile_Joueur.aoeSize, 0);
            foreach (Collider2D hit in colliders)
            {

                switch (colliders.Length)
                {
                    case 1:
                        if (hit.gameObject.CompareTag("Ennemy"))
                            hit.GetComponent<Entities>().SetHealth(projectile_Joueur.damage);

                        break;

                    case 2:
                        if (hit.gameObject.CompareTag("Ennemy"))
                        {
                            hit.GetComponent<Entities>().SetHealth(projectile_Joueur.damage);
                            projectile_Joueur.damage = tempDmg * 0.80f;
                        }
                        break;

                    case 3:
                        if (hit.gameObject.CompareTag("Ennemy"))
                        {
                            hit.GetComponent<Entities>().SetHealth(projectile_Joueur.damage);
                            projectile_Joueur.damage = tempDmg * 0.60f;
                        }
                        break;

                    case 4:
                        if (hit.gameObject.CompareTag("Ennemy"))
                        {
                            hit.GetComponent<Entities>().SetHealth(projectile_Joueur.damage);
                            projectile_Joueur.damage = tempDmg * 0.40f;
                        }
                        break;

                    default:
                        break;
                }
             
            }
            projectile_Joueur.damage = tempDmg;
            StartCoroutine(DisableProjectile());
        }

        if (collider.gameObject.CompareTag("Boss"))
        {
            //Deal damage to Boss.
        }

    }

    IEnumerator DisableProjectile()
    {
        this.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        if (TryGetComponent(out Collider2D a))
            Destroy(a);
        if (TryGetComponent(out Collider2D b))
            Destroy(b);
        if (TryGetComponent(out AreaEffector2D c))
            Destroy(c);
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }

}
