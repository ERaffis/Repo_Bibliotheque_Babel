using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemi2_Biome1 : Entities
{
    public float stoppingDistance;

    private float timeBtwShots;
    public float startTimeBtwShots;

    public GameObject projectile;
    public Transform player1;

    

    void Start()
    {
        player1 = GameObject.FindGameObjectWithTag("Player1").transform;
        _GameHandler = GameObject.FindGameObjectWithTag("GameHandler").GetComponent<GameHandler>();
        moveSpeed = 2f;
        stoppingDistance = 2f;

        timeBtwShots = startTimeBtwShots;
        startTimeBtwShots = 2f;

        StartCoroutine(WaitToMoveStart());
    }


    void Update()
    {
        if(canMove)
        {
            if (Vector2.Distance(transform.position, player1.position) > stoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player1.position, moveSpeed * Time.deltaTime);
            }
            else if (Vector2.Distance(transform.position, player1.position) < stoppingDistance)
            {
                transform.position = this.transform.position;
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
        
    }


    
}
