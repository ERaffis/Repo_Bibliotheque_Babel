using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public float moveSpeed;
    public float latestDirectionChangeTime;
    public float directionChangeTime;
    public float charactervelocity;
    public Vector2 movementDirection;
    public Vector2 movementPerSecond;
    public bool canMove;



    void Start()
    {
        directionChangeTime = 3f;
        charactervelocity = 1f;
        latestDirectionChangeTime = 0f;
        canMove = true;
        calculateNewMovementVector();
    }

    public void calculateNewMovementVector()
    {
        //create a random direction vector with the magnitude of 1, later multiply it with the velocity of the enemy

        movementDirection = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));

        movementPerSecond = movementDirection * charactervelocity;
    }

    void Update()
    {
        //if the changeTime was reached, calculate a new movement vector
        if (Time.time - latestDirectionChangeTime > directionChangeTime)
        {
            latestDirectionChangeTime = Time.time;
            calculateNewMovementVector();
        }

        //move enemy
        if (canMove)
        {
            transform.position = new Vector2(transform.position.x + (movementPerSecond.x * Time.deltaTime), transform.position.y + (movementPerSecond.y * Time.deltaTime));
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
      canMove = false;
      yield return new WaitForSeconds(1);
      //calculateNewMovementVector();
      canMove = true;
    }
}
