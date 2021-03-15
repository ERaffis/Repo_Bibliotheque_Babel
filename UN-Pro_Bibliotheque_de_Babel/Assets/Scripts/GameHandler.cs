using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public static GameHandler Instance { get; private set; }


    public GameObject[] instDir;
    public GameObject activeInstDir;

    public GameObject activeMoveDir;
    public GameObject[] moveDir;



    public int gameDifficulty;
    public int nmbToSpawns;
    public int nmbSpawned;
    public int nmbRemaining;

    public bool roomCleared;

    public string biomeName;

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

        SoundManager.Initialize();

        gameDifficulty = 1;
    }
    // Start is called before the first frame update
    void Start()
    {
        activeInstDir.GetComponent<SpriteRenderer>().enabled = true;
        activeMoveDir.GetComponent<SpriteRenderer>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        CheckForRoomClear();    
    }

    // Method to call when the player dies or reaches the outside
    public void RunEnded(bool var)
    {
        nmbRemaining = 0;
        nmbToSpawns = 0;
        nmbSpawned = 0;

        //Adds the total of runs
        PlayerScript.Instance.nmbRun++;

        // if the player reached the outside during the run
        if(var == true)
        {
            gameDifficulty += 2;
            LevelManager.Instance.ReturnToHubAfterWin();
        }

        if (var != true)
        {
            gameDifficulty += 1;
            LevelManager.Instance.ReturnToHubAfterDeath();
        }
    }


    public void ChangeRuneDir(int i)
    {
        activeInstDir.GetComponent<SpriteRenderer>().enabled = false;
        activeInstDir = instDir[i];
        activeInstDir.GetComponent<SpriteRenderer>().enabled = true;
    }

    public void ChangeMoveDir(int i)
    {
        activeMoveDir.GetComponent<SpriteRenderer>().enabled = false;
        activeMoveDir = moveDir[i];
        activeMoveDir.GetComponent<SpriteRenderer>().enabled = true;
    }


    public void CheckForRoomClear()
    {
        if (nmbRemaining <= 0)
        {
            roomCleared = true;
            SpawnReward.Instance.SpawnItem(new Vector2(0, 0.5f), "Room");
        }
    }   
}
