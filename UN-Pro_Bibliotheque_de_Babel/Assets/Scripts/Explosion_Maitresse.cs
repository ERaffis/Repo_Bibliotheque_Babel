using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion_Maîtresse : MonoBehaviour
{
    public Projectile_Joueur projectile_Joueur;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.layer == 6)
        {
            

                Vector3 explosionPos = transform.position;
                Collider[] colliders = Physics.OverlapSphere(explosionPos, projectile_Joueur.aoeSize);

            
            foreach (Collider hit in colliders)
            {
                Rigidbody2D rb = hit.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    rb.AddExplosionForce(projectile_Joueur.explosionForce, explosionPos, projectile_Joueur.aoeSize);
                }

                //+5% dégâts au projo par ennemi dans aoe
                //puis degâts
            }

        }

        Destroy(GameObject);
    }
}
