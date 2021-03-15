using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectilePrefab : MonoBehaviour
{
    private SpriteRenderer sprite;
    private ParticleSystem BossProjectileExplosion;
    private BoxCollider2D boxCollider;
    public int damage;

    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player1");
        BossProjectileExplosion = GetComponentInChildren<ParticleSystem>();
        sprite = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
        damage = 12;
    }

   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player1"))
        {
            if (!player.GetComponent<PlayerScript>().isImmune)
            {
                player.GetComponent<PlayerScript>().SetPlayerHealth(damage);
                StartCoroutine(DestroyProjectile());
            }
        }

        if(collision.gameObject.layer == 9)
        {
            StartCoroutine(DestroyProjectile());
        }
    }



    private IEnumerator DestroyProjectile()
    {
        BossProjectileExplosion.Play();
        sprite.enabled = false;
        boxCollider.enabled = false;
        yield return new WaitForSeconds(BossProjectileExplosion.main.startLifetime.constantMax);
        Destroy(gameObject);
    }

}
