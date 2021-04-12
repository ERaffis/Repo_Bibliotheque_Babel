using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemi3_Movement : Entities
{
    public float charactervelocity;
    public float latestDirectionChangeTime;
    public float directionChangeTime;
    public Vector2 movementDirection;
    public Vector2 movementPerSecond;
    public bool ennemyCanMove;

   
    void Start()
    {
        _GameHandler = GameObject.FindGameObjectWithTag("GameHandler").GetComponent<GameHandler>();
        ennemyCanMove = true;
        directionChangeTime = 3f;
        charactervelocity = 1f;
        latestDirectionChangeTime = 0f;
    }

    public void calculateNewMovementVector()
    {
        movementDirection = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));

        movementPerSecond = movementDirection * charactervelocity;
    }

    void Update()
    {
        if (!isStuned)
        {
            if (Time.time - latestDirectionChangeTime > directionChangeTime)
            {
                latestDirectionChangeTime = Time.time;
                calculateNewMovementVector();
            }

            if (ennemyCanMove)
            {
                transform.position = new Vector2(transform.position.x + (movementPerSecond.x * Time.deltaTime), transform.position.y + (movementPerSecond.y * Time.deltaTime));
            }
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
