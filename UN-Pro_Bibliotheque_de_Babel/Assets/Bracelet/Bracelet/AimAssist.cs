using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimAssist : MonoBehaviour
{
    public Projectile_Joueur projectile_Joueur;
    public float speed;
    public Transform target;
    public float cooldown;

    // Start is called before the first frame update
    void Start()
    {
        cooldown = 0.25f;
    }

    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;

        if (cooldown <= 0 && target == null)
        {
            cooldown = 0.35f;
            FindTarget();
        }

        // Move our position a step closer to the target.
        if (target != null) 
        {
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            float step = speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);

            if (target == null)
            {
                Destroy(gameObject);
            }

            if(cooldown >= 7.5f )
            {
                Destroy(gameObject);
            }
        }
       

    }

    public void FindTarget()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.75f);

        foreach (Collider2D hit in colliders)
        {
            if (hit.gameObject.CompareTag("Ennemy") || hit.gameObject.CompareTag("Boss"))
            {
                target = hit.gameObject.transform;
                break;
            }
        }
    }
}
