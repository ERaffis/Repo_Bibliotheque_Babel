using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public GameObject _Cameras;
    public GameObject eventSystem;
    public GameObject player1;

    public GameObject[] instDir;
    public GameObject activeInstDir;

    [Header("Managers")]
    public GameObject lvlManager;
    public GameObject uiManager;

    public int gameDifficulty;
    public int nmbToSpawns;
    public int nmbSpawned;
    public int nmbRemaining;

    public bool roomCleared;

    public string biomeName;

    private void Awake()
    {
        SoundManager.Initialize();
        if(_Cameras == null)
        {
            _Cameras = GameObject.Find("_Camera");
            DontDestroyOnLoad(_Cameras);
        }

        if (eventSystem == null)
        {
            eventSystem = GameObject.Find("Rewired Event System");
            DontDestroyOnLoad(eventSystem);
        }
        if (player1 == null)
        {
            player1 = GameObject.Find("Player_1"); 
            DontDestroyOnLoad(player1);
        }
            
        if (lvlManager == null)
        {
            lvlManager = GameObject.FindGameObjectWithTag("LevelManager");
            DontDestroyOnLoad(lvlManager);
        }
        if (uiManager == null)
        {
            uiManager = GameObject.FindGameObjectWithTag("UIManager");
            DontDestroyOnLoad(uiManager);
        }


        //List of objects not to destroy when switching scene
        DontDestroyOnLoad(this);
        gameDifficulty = 1;
    }
    // Start is called before the first frame update
    void Start()
    {
        print(gameDifficulty);

        activeInstDir.GetComponent<SpriteRenderer>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G)) RunEnded(true);
        if (Input.GetKeyDown(KeyCode.H)) RunEnded(false);
        CheckForRoomClear();    
    }

    // Method to call when the player dies or reaches the outside
    public void RunEnded(bool var)
    {
        nmbRemaining = 0;
        nmbToSpawns = 0;
        nmbSpawned = 0;

        //Adds the total of runs
        player1.GetComponent<PlayerScript>().nmbRun++;
        // print(player1.GetComponent<PlayerScript>().nmbRun);

        // if the player reached the outside during the run
        if(var == true)
        {
            gameDifficulty += 2;
            player1.GetComponent<PlayerScript>().SetMaxHealth(64);
            //lvlManager.FadeToLevel("HUB_Principal");
            // print(gameDifficulty);
        }
        // if the player died during the run
        if (var != true)
        {
            gameDifficulty += 1;
            player1.GetComponent<PlayerScript>().SetMaxHealth(64);
            lvlManager.GetComponent<LevelManager>().ReturnToHubAfterDeath();
            // print(gameDifficulty);
        }
    }


    public void ChangeRuneDir(int i)
    {
        activeInstDir.GetComponent<SpriteRenderer>().enabled = false;
        activeInstDir = instDir[i];
        activeInstDir.GetComponent<SpriteRenderer>().enabled = true;
    }


    public void CheckForRoomClear()
    {
        if (nmbRemaining <= 0) roomCleared = true;
    }

    
}
