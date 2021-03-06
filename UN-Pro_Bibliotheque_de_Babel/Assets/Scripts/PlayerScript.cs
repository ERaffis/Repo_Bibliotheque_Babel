using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class PlayerScript : Entities
{


    [Header("Rewired Attributes")]
    [SerializeField] private int playerID = 0;
    public Player playerInputs;

    [Header("Run Counter")]
    public int nmbRun;



    // Start is called before the first frame update
    void Start()
    {
        playerInputs = ReInput.players.GetPlayer(playerID);
    }

    // Update is called once per frame
    void Update()
    {
        print(currentHealth);
        if(currentHealth <= 0)
        {
            PlayerDied();
        }
    }

    public IEnumerator SetSpawn()
    {
        yield return new WaitForSeconds(.1f);
        GameObject spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint");
        this.transform.position = spawnPoint.transform.position;
    }

    public IEnumerator BlockMove()
    {
        rb.velocity = Vector2.zero;
        canMove = false;
        yield return new WaitForSeconds(5f);
        canMove = true;
    }

    public void PlayerDied()
    {
        Destroy(GameObject.FindGameObjectWithTag("Spawner"));
        SetStartHealth();
        _GameHandler.RunEnded(false);
    }
}
