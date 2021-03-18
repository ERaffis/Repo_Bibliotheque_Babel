using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectileAttack : MonoBehaviour
{
    [Header("Projectile Settings")]
    public int numberOfProjectiles = 5;
    public float projectileSpeed;
    public GameObject BossProjectilePrefab;

    [Header("Private Variables")]
    private Vector2 startPoint;
    private const float radius = 1f;
    
    
    private float timeBtwShots;
    private float startTimeBtwShots;


   


    public void Start()
    {
        timeBtwShots = startTimeBtwShots;
        startTimeBtwShots = 2f;
        projectileSpeed = 2f;
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
    }

    private void SpawnProjectiles(int _numberOfProjectiles)
    {
        float angleStep = 360f / _numberOfProjectiles;
        float angle = 0f;

        for (int i = 0; i <= _numberOfProjectiles -1; i++)
        {
            angle += angleStep;

            float projectileDirXPosition = startPoint.x + Mathf.Sin((angle * Mathf.PI) / 180) * radius;
            float projectileDirYPosition = startPoint.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius;

            Vector2 projectileVector = new Vector2(projectileDirXPosition, projectileDirYPosition);
            Vector2 projectileMoveDirection = (projectileVector - startPoint).normalized * projectileSpeed;

            GameObject tmpObj = Instantiate(BossProjectilePrefab, startPoint, Quaternion.identity);
            tmpObj.GetComponent<SpriteRenderer>().enabled = true;
            tmpObj.GetComponent<BoxCollider2D>().enabled = true;
            tmpObj.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileMoveDirection.x,projectileMoveDirection.y);

            

        }
    }
}
