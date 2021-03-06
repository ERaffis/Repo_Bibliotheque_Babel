using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float speed;

    private Transform player1;
    private Vector2 target;

    private SpriteRenderer sprite;
    private ParticleSystem projectileExplosion;
    private BoxCollider2D boxCollider;

    void Start()
    {
        player1 = GameObject.FindGameObjectWithTag("Player1").transform;
        target = new Vector2(player1.position.x, player1.position.y);
        speed = 3f;
        projectileExplosion = GetComponentInChildren<ParticleSystem>();
        sprite = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if(transform.position.x == target.x && transform.position.y == target.y)
        {
            StartCoroutine(DestroyProjectile());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player1"))
        {
            StartCoroutine(DestroyProjectile());
        }
    }



    private IEnumerator DestroyProjectile()
    {
        projectileExplosion.Play();
        sprite.enabled = false;
        boxCollider.enabled = false;
        yield return new WaitForSeconds(projectileExplosion.main.startLifetime.constantMax);
        Destroy(gameObject);
    }
}
