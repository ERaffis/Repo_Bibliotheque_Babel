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

    public string biomeName;

    private void Awake()
    {
        SoundManager.Initialize();
        _Cameras = GameObject.Find("_Camera");
        eventSystem = GameObject.Find("Rewired Event System");
        player1 = GameObject.Find("Player_1");
        lvlManager = GameObject.FindGameObjectWithTag("LevelManager");
        uiManager = GameObject.FindGameObjectWithTag("UIManager");


        //List of objects not to destroy when switching scene
        DontDestroyOnLoad(this);
        DontDestroyOnLoad(_Cameras);
        DontDestroyOnLoad(eventSystem);
        DontDestroyOnLoad(player1);
        DontDestroyOnLoad(lvlManager);
        DontDestroyOnLoad(uiManager);

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
    }

    // Method to call when the player dies or reaches the outside
    public void RunEnded(bool var)
    {
        //Adds the total of runs
        player1.GetComponent<PlayerScript>().nmbRun++;
        // print(player1.GetComponent<PlayerScript>().nmbRun);

        // if the player reached the outside during the run
        if(var == true)
        {
            gameDifficulty += 1;
            //lvlManager.FadeToLevel("HUB_Principal");
            // print(gameDifficulty);
        }
        // if the player died during the run
        if (var != true)
        {
            gameDifficulty += 2;
            lvlManager.GetComponent<LevelManager>().FadeToLevel("HUB_Principal");
            // print(gameDifficulty);
        }
    }


    public void ChangeRuneDir(int i)
    {
        activeInstDir.GetComponent<SpriteRenderer>().enabled = false;
        activeInstDir = instDir[i];
        activeInstDir.GetComponent<SpriteRenderer>().enabled = true;
    }
}
