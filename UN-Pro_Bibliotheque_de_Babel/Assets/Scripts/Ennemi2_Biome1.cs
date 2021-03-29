using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemi2_Biome1 : Entities
{
    public float charactervelocity;
    public float latestDirectionChangeTime;
    public float directionChangeTime;
    public Vector2 movementDirection;
    public Vector2 movementPerSecond;
    public bool ennemyCanMove;

    private float timeBtwShots;
    public float startTimeBtwShots;

    public GameObject projectile;
    

    

    void Start()
    {
        _GameHandler = GameObject.FindGameObjectWithTag("GameHandler").GetComponent<GameHandler>();
        ennemyCanMove = true;
        directionChangeTime = 3f;
        charactervelocity = 1f;
        latestDirectionChangeTime = 0f;


        timeBtwShots = startTimeBtwShots;
        startTimeBtwShots = 2f;

       
        calculateNewMovementVector();
    }


    public void calculateNewMovementVector()
    {
        movementDirection = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));

        movementPerSecond = movementDirection * charactervelocity;
    }

    void Update()
    {
        if(Time.time - latestDirectionChangeTime > directionChangeTime)
        {
            latestDirectionChangeTime = Time.time;
            calculateNewMovementVector();
        }

        if (ennemyCanMove)
        {
            transform.position = new Vector2(transform.position.x + (movementPerSecond.x * Time.deltaTime), transform.position.y + (movementPerSecond.y * Time.deltaTime));
        }


        if (timeBtwShots <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            movementDirection = new Vector2(movementDirection.x * -1, movementDirection.y * -1);
            movementPerSecond = movementDirection * charactervelocity;
            StartCoroutine(WaitWhenCollision());
        }
    }

    public IEnumerator WaitWhenCollision()
    {
        ennemyCanMove = false;
        yield return new WaitForSeconds(1);
        ennemyCanMove = true;
    }
}
