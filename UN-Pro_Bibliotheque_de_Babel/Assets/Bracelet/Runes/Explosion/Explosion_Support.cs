using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion_Support : MonoBehaviour
{
    public Projectile_Joueur projectile_Joueur;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player1"))
        {
            if (collision.gameObject.CompareTag("Ennemy"))
            {
                for (int i = 0; i < projectile_Joueur.nmbProjectileExplosion; i++)
                {
                    GameObject newProjectile = Instantiate(gameObject, collision.transform.position + Vector3.up * 1.25f, new Quaternion(0, 0, 0, 0));
                    newProjectile.transform.RotateAround(collision.transform.position, Vector3.forward, 360 / projectile_Joueur.nmbProjectileExplosion * i);
                    Destroy(newProjectile.GetComponent<Explosion_Support>());
                    newProjectile.GetComponent<Rigidbody2D>().velocity = newProjectile.transform.right * GetComponent<Rigidbody2D>().velocity;
                }

            }
        }

    }

    
}
