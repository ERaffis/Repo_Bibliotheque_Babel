using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }

    public Animator animator;

    private int levelToLoad;

    [Header("Level Generation Values")]
    public float shouldBiome;
    public float shouldBoss;
    public float shouldHub;
    public int currentBiome;
    public float shouldExterior;
    string roomName;

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
        Debug.Log("Scene " + arg0.name + " loaded");
        if (arg0.name == "HUB_Principal")
        {
            uiManager.Instance.SetRoomInfoHUB();
            PlayerScript.Instance.SetMaxHealth(64);
        }
    }

    private void Start()
    {
        currentBiome = 0;
        shouldExterior = 0f;
        roomName = "Piece_Biome_1";
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Delete)) FadeToLevel();
    }

    public void ReturnToHubAfterDeath()
    {
        this.roomName = "HUB_Principal";

        StartCoroutine(PlayerScript.Instance.BlockMove());
        StartCoroutine(RoomNumberManager.Instance.WriteTrial("" + PlayerScript.Instance.nmbRun));
        animator.SetTrigger("FadeOut");
        uiManager.Instance.ChangeUiState();
    }

    public void ReturnToHubAfterWin()
    {
        this.roomName = "HUB_Principal";

        StartCoroutine(PlayerScript.Instance.BlockMove());
        StartCoroutine(RoomNumberManager.Instance.WriteTrial("" + PlayerScript.Instance.nmbRun));
        animator.SetTrigger("FadeOut");
        uiManager.Instance.ChangeUiState();
    }

    // Change scene with random generation -- GenerateRoom()
    public void FadeToLevel()
    {
        this.roomName = GenerateRoom();

        switch (roomName)
        {
            case "HUB_Principal":
                StartCoroutine(PlayerScript.Instance.BlockMove());

                GameHandler.Instance.RunEnded(true);
                animator.SetTrigger("FadeOut");

                uiManager.Instance.ChangeUiState();

                break;
            default:
                StartCoroutine(PlayerScript.Instance.BlockMove());
                StartCoroutine(RoomNumberManager.Instance.WriteNumber());
                animator.SetTrigger("FadeOut");

                uiManager.Instance.ChangeUiState();
                break;
        }
    }

    // Change scene with name
    public void FadeToLevel(string roomName)
    {
        this.roomName = roomName;

        switch (roomName)
        {
            case "HUB_Principal":
                StartCoroutine(PlayerScript.Instance.BlockMove());

                GameHandler.Instance.RunEnded(true);
                animator.SetTrigger("FadeOut");

                uiManager.Instance.ChangeUiState();

                break;
            default:
                StartCoroutine(PlayerScript.Instance.BlockMove());
                StartCoroutine(RoomNumberManager.Instance.WriteNumber());
                animator.SetTrigger("FadeOut");

                uiManager.Instance.ChangeUiState();
                break;
        }
    }

    // Change scene with build index
    public void FadeToLevel(int levelIndex)
    {
        this.roomName = SceneManager.GetSceneByBuildIndex(levelIndex).name;

        switch (roomName)
        {
            case "HUB_Principal":
                StartCoroutine(PlayerScript.Instance.BlockMove());

                GameHandler.Instance.RunEnded(true);
                animator.SetTrigger("FadeOut");

                uiManager.Instance.ChangeUiState();

                break;
            default:
                StartCoroutine(PlayerScript.Instance.BlockMove());
                StartCoroutine(RoomNumberManager.Instance.WriteNumber());
                animator.SetTrigger("FadeOut");

                uiManager.Instance.ChangeUiState();
                break;
        }
    }

    // Changes the scene when the fade is complete
    public void OnFadeComplete()
    {
        
        SceneManager.LoadScene(roomName);
        StartCoroutine(PlayerScript.Instance.SetSpawn());
        uiManager.Instance.ChangeUiState();

        if (roomName == "HUB_Principal")
        {
            //uiManager.Instance.SetRoomInfoHUB();
            PlayerScript.Instance.SetMaxHealth(64);
        }
        else
        {
            //uiManager.Instance.SetRoomInfo();
        }
    }

    // Generate a room name based on parameters
    public string GenerateRoom()
    {
        float spawnHub = Random.Range(0f, 1f);

        float spawnExterior = Random.Range(0f, 1f);

        if (spawnExterior * shouldExterior > 0.95f)
        {
            //numberManager.PlusRoomNumber();
            shouldHub = 0f;
            shouldBoss = 0f;
            shouldBiome = 0f;
            shouldExterior = 0f;
            GameHandler.Instance.RunEnded(false);
            return "HUB_Principal";
        }

        if (spawnHub * shouldHub > 0.95f)
        {
            RoomNumberManager.Instance.PlusRoomNumber();
            shouldHub = 0f;
            shouldBoss = 0f;
            shouldBiome = 100f;
            return "Hub_Secondaire" ;
        }
        else
        {
            //ChangeBiome();

            switch (currentBiome)
            {
                case 0:
                    if (Random.Range(0.01f, 1f) * shouldBoss > 0.95f)
                    {
                        RoomNumberManager.Instance.PlusLevelNumber();
                        shouldHub = 100f;
                        shouldBoss = 0f;
                        shouldExterior += 0.2f;
                        return "Boss_Biome_1";
                    }
                    else
                    {
                        RoomNumberManager.Instance.PlusRoomNumber();
                        shouldHub += 0.05f;
                        shouldBoss += 0.075f;
                        shouldBiome += 0.05f;
                        if (Random.Range(0.01f, 1f) > 0.1f)
                        {
                            return "Piece_Biome_1";
                        }
                        else
                        {
                            return "Puzzle_Biome_1";
                        }
                        
                    }
                case 1:
                    if (Random.Range(0.01f, 1f) * shouldBoss > 0.95f)
                    {
                        RoomNumberManager.Instance.PlusLevelNumber();
                        shouldHub = 100f;
                        shouldBoss = 0f;
                        shouldExterior += 0.2f;
                        return "Boss_Biome_2";
                    }
                    else
                    {
                        RoomNumberManager.Instance.PlusRoomNumber();
                        shouldHub += 0.05f;
                        shouldBoss += 0.075f;
                        shouldBiome += 0.05f;
                        if (Random.Range(0.01f, 1f) > 0.1f)
                        {
                            return "Piece_Biome_2";
                        }
                        else
                        {
                            return "Puzzle_Biome_2";
                        }
                    }
                case 2:
                    if (Random.Range(0.01f, 1f) * shouldBoss > 0.95f )
                    {
                        RoomNumberManager.Instance.PlusLevelNumber();
                        shouldHub = 100f;
                        shouldBoss = 0f;
                        shouldExterior += 0.2f;
                        return "Boss_Biome_3";
                    }
                    else
                    {
                        RoomNumberManager.Instance.PlusRoomNumber();
                        shouldHub += 0.05f;
                        shouldBoss += 0.075f;
                        shouldBiome += 0.05f;
                        if (Random.Range(0.01f, 1f) > 0.1f)
                        {
                            return "Piece_Biome_3";
                        }
                        else
                        {
                            return "Puzzle_Biome_3";
                        }
                    }
            }
        }
        Debug.LogError("No Rooms Returned");
        return null;  
    }

    // Changes the current biome for the next room
    public void ChangeBiome()
    {
        if (Random.Range(0.01f, 1f) * shouldBiome > 0.8f)
        {
            switch (currentBiome)
            {
                case 0:
                    print("1");
                    shouldBiome = 0;
                    if (Random.Range(0f, 1f) > 0.5f)
                    {
                        currentBiome = 1;
                        GameHandler.Instance.biomeName = "L'Incendie";
                    }
                    else
                    {
                        currentBiome = 2;
                        GameHandler.Instance.biomeName = "La Ruine";
                    }
                    break;

                case 1:
                    print("2");
                    shouldBiome = 0;
                    if (Random.Range(0f, 1f) > 0.5f)
                    {
                        currentBiome = 2;
                        GameHandler.Instance.biomeName = "La Ruine";
                    }
                    else 
                    {
                        currentBiome = 0;
                        GameHandler.Instance.biomeName = "La Preservation";
                    }
                    
                    break;

                case 2:
                    print("3");
                    shouldBiome = 0;
                    if (Random.Range(0f, 1f) > 0.5f)
                    {
                        currentBiome = 0;
                        GameHandler.Instance.biomeName = "La Preservation";
                    }
                    else
                    {
                        currentBiome = 1;
                        GameHandler.Instance.biomeName = "L'Incendie";
                    }
                    break;

            }
        }
    }
}
