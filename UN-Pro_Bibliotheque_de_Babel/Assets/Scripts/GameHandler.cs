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
    public LevelManager lvlManager;
    public uiManager uiManager;

    public float gameDifficulty;
    public int nmbToSpawns;
    public int nmbSpawned;
    public int nmbRemaining;


    private void Awake()
    {
        SoundManager.Initialize();
        _Cameras = GameObject.Find("_Camera");
        eventSystem = GameObject.Find("EventSystem");
        player1 = GameObject.Find("Player_1");


        //List of objects not to destroy when switching scene
        DontDestroyOnLoad(this);
        DontDestroyOnLoad(_Cameras);
        DontDestroyOnLoad(eventSystem);
        DontDestroyOnLoad(player1);

        gameDifficulty = 0.25f;
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
            gameDifficulty *= 1.25f;
            //lvlManager.FadeToLevel("HUB_Principal");
            // print(gameDifficulty);
        }
        // if the player died during the run
        if (var != true)
        {
            gameDifficulty *= 1.15f;
            lvlManager.FadeToLevel("HUB_Principal");
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
