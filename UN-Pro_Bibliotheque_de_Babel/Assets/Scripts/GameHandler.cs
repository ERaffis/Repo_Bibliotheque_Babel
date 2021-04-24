using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    public static GameHandler Instance { get; private set; }


    public GameObject[] instDir;
    public GameObject activeInstDir;

    public GameObject activeMoveDir;
    public GameObject[] moveDir;

    public bool alreadySpawned;

    public int gameDifficulty;
    public int startingDifficulty;
    public int nmbToSpawns;
    public int nmbSpawned;
    public int nmbRemaining;

    public bool roomCleared;
    public int nmbRooms;

    public string biomeName;

    [Header("Exit Gate")]
    public Animator grilleAnimator;

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

        gameDifficulty = 0;
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= SceneManager_sceneLoaded;

    }

    private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        if(arg0.name == "HUB_Principal")
        {
            nmbRemaining = 0;
            nmbToSpawns = 0;
            nmbSpawned = 0;
            nmbRooms = 0;
            Inventory.Instance.activeBracelet = null;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        alreadySpawned = false;
    }

    // Update is called once per frame
    void Update()
    {
        CheckForRoomClear();    
    }

    // Method to call when the player dies or reaches the outside
    public void RunEnded(bool var)
    {

        //Adds the total of runs
        PlayerScript.Instance.nmbRun++;

        // if the player reached the outside during the run
        if(var == true)
        {
            gameDifficulty += 1;
            startingDifficulty = gameDifficulty;
            LevelManager.Instance.ReturnToHubAfterWin();
        }

        if (var != true)
        {
            gameDifficulty = startingDifficulty;
            startingDifficulty = gameDifficulty;
            LevelManager.Instance.ReturnToHubAfterDeath();
        }

    }


    public void ChangeRuneDir(int i)
    {
        activeInstDir = instDir[i];
    }

    public void ChangeMoveDir(int i)
    {
        activeMoveDir = moveDir[i];
    }


    public void CheckForRoomClear()
    {
        if (GameObject.Find("GrilleSprite") != null)
        {
            grilleAnimator = GameObject.Find("GrilleSprite").GetComponent<Animator>();
        }
        if (SceneManager.GetActiveScene().name == "Hub_Principal" || SceneManager.GetActiveScene().name == "HUB_Secondaire" || SceneManager.GetActiveScene().name == "HUB_Didacticiel")
        {
            roomCleared = true;
        }
        else if (SceneManager.GetActiveScene().name == "Piece_Boss")
        {
            if (!GameObject.FindGameObjectWithTag("Boss"))
                roomCleared = true;
        }
        else if (nmbRemaining <= 0)
        {
            roomCleared = true;

            if (!alreadySpawned)
            {
                if (SceneManager.GetActiveScene().name != "HUB_Principal" && SceneManager.GetActiveScene().name != "HUB_Secondaire" && SceneManager.GetActiveScene().name != "HUB_Didacticiel")
                {
                    SpawnReward.Instance.SpawnItem(new Vector2(0, 5.25f), "Room");
                    alreadySpawned = true;
                    StartCoroutine(WaitToPoint());
                    StartCoroutine(OpenGate());
                }
            }
        }
    }

    private IEnumerator WaitToPoint()
    {
        yield return new WaitForSeconds(1);
        ArrowPointer.Instance.shouldPoint = true;
        
    }

    public IEnumerator OpenGate()
    {
        if (GameObject.Find("GrilleSprite") != null)
            grilleAnimator.Play("AppearAnimTop");
        yield return new WaitForSeconds(1);
        if (GameObject.Find("GrilleSprite") != null)
            grilleAnimator.Play("IdleOpen");
    }

}
