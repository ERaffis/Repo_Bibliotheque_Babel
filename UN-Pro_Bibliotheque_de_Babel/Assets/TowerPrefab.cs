using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPrefab : Entities
{
    [Header("Projectile Settings")]
    public int numberOfProjectiles =3;
    public float projectileSpeed;
    public GameObject BossProjectilePrefab;

    [Header("Private Variables")]
    private Vector2 startPoint;
    private const float radius = 1f;


    private float timeBtwShots;
    private float startTimeBtwShots;

    public bool isAlive;

    public Animator anim;
    public CapsuleCollider2D collider2d;

    [Header("DeadSprite")]
    public GameObject afterSprite;

    public Ennemi3_SpawnAttack ennemi3maxtower;

    public void Start()
    {
        timeBtwShots = startTimeBtwShots;
        startTimeBtwShots = 2f;
        projectileSpeed = 2f;
        currentHealth = 128;
        isAlive = true;
        anim = GetComponent<Animator>();
        anim.SetBool("isAlive", true);
        collider2d = GetComponent<CapsuleCollider2D>();
        
    }

    
    public void Update()
    {
        if (timeBtwShots <= 0)
        {
            startPoint = this.transform.position;
            timeBtwShots = startTimeBtwShots;
            SpawnProjectiles(numberOfProjectiles);

        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }



        if(currentHealth <= 0)
        {
            
            isAlive = false;
            anim.SetBool("isAlive", false);
            StartCoroutine(DestroyComponents());
            
        }
    }


    private void SpawnProjectiles(int _numberOfProjectiles)
    {
       if(isAlive == true)
        { 
        float angleStep = 360f / _numberOfProjectiles;
        float angle = 0f;

            for (int i = 0; i <= _numberOfProjectiles - 1; i++)
            {
                angle += angleStep;

                float projectileDirXPosition = startPoint.x + Mathf.Sin((angle * Mathf.PI) / 180) * radius;
                float projectileDirYPosition = startPoint.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius;

                Vector2 projectileVector = new Vector2(projectileDirXPosition, projectileDirYPosition);
                Vector2 projectileMoveDirection = (projectileVector - startPoint).normalized * projectileSpeed;

                GameObject tmpObj = Instantiate(BossProjectilePrefab, startPoint, Quaternion.identity);
                tmpObj.GetComponent<SpriteRenderer>().enabled = true;
                tmpObj.GetComponent<BoxCollider2D>().enabled = true;
                tmpObj.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileMoveDirection.x, projectileMoveDirection.y);
            }


        }
    }

   public IEnumerator DestroyComponents()
    {
        ennemi3maxtower.maxTowerSpawned--;
        GameObject obj = Instantiate(afterSprite, transform);
        obj.transform.parent = null;
        yield return new WaitForEndOfFrame();
        Destroy(this.gameObject);
    }
}
