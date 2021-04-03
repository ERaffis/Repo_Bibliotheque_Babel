using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class PlayerScript : Entities
{

    public static PlayerScript Instance { get; private set; }

    [Header("Rewired Attributes")]
    [SerializeField] private int playerID = 0;
    public Player playerInputs;

    [Header("Run Counter")]
    public int nmbRun;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        playerInputs = ReInput.players.GetPlayer(playerID);
        SetStartHealth();

        isImmune = false;
    }

    // Update is called once per frame
    void Update()
    {
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
        canMove = false;
        yield return new WaitForSeconds(5f);
        canMove = true;
    }

    public void ChangeMoveState()
    {
        canMove = !canMove;
    }


    public void PlayerDied()
    {
        foreach (GameObject item in GameObject.FindGameObjectsWithTag("Projectile"))
        {
            Destroy(item);
        }

        foreach (GameObject item in GameObject.FindGameObjectsWithTag("Ennemy"))
        {
            Destroy(item);
        }

        SetStartHealth();
        GameHandler.Instance.RunEnded(false);
    }
    public void PickedUpHeart()
    {
        currentHealth += 8;
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
    }
}
