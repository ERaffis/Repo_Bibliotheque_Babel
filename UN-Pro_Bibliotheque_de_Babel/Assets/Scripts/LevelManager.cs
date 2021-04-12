using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }

    public Animator animator;

    private int levelToLoad;

    [Header("Level Generation Values")]
    public float shouldBoss;
    public float shouldHub;
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
            shouldExterior = 0f;
            GameHandler.Instance.RunEnded(false);
            return "HUB_Principal";
        }

        if (spawnHub * shouldHub > 0.95f)
        {
            RoomNumberManager.Instance.PlusRoomNumber();
            shouldHub = 0f;
            shouldBoss = 0f;
            return "Hub_Secondaire" ;
        }
        else
        {

            if (Random.Range(0.01f, 1f) * shouldBoss > 0.95f)
            {
                RoomNumberManager.Instance.PlusLevelNumber();
                shouldHub = 100f;
                shouldBoss = 0f;
                shouldExterior += 0.2f;
                return "Piece_Boss";
            }
            else
            {
                int gen = Random.Range(1, 7);
                RoomNumberManager.Instance.PlusRoomNumber();
                shouldHub += 0.1f;
                shouldBoss += 0.125f;
                if (gen == 1)
                {
                    return "Piece_1";
                }
                else if (gen == 2)
                {
                    return "Piece_2";
                }
                else if (gen == 3)
                {
                    return "Piece_3";
                }
                else if (gen == 4)
                {
                    return "Piece_4";
                }
                else if (gen == 5)
                {
                    return "Piece_5";
                }
                else if (gen == 6)
                {
                    return "Piece_6";
                }
                else if (gen == 7)
                {
                    return "Piece_7";
                }
                else if (gen == 8)
                {
                    return "Piece_8";
                }
                else if (gen == 9)
                {
                    return "Piece_9";
                }
                else if (gen == 10)
                {
                    return "Piece_10";
                }
                return null;
            }
        }
    }
}
