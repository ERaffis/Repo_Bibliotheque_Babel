using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }

    public Animator animator;

    private int levelToLoad;

    [Header("Level Generation Values")]
    public bool shouldBoss;
    public bool shouldHub;
    public float shouldExterior;
    string roomName;

    [Header("RoomBooleans")]
    private bool piece1, piece2, piece3, piece4, piece5, piece6;
    private int roomCounter;

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
            PlayerScript.Instance.SetMaxHealth(PlayerScript.Instance.maxHealth);
            piece1 = false;
            piece2 = false;
            piece3 = false;
            piece4 = false;
            piece5 = false;
            piece6 = false;
            roomCounter = 0;
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
            PlayerScript.Instance.SetMaxHealth(PlayerScript.Instance.maxHealth);
        }
        else
        {
            //uiManager.Instance.SetRoomInfo();
        }
    }

    // Generate a room name based on parameters
    public string GenerateRoom()
    {
        float spawnExterior = Random.Range(0f, 1f);

        if (spawnExterior * shouldExterior > 0.95f)
        {
            //numberManager.PlusRoomNumber();
            shouldBoss = false;
            shouldExterior = 0f;
            GameHandler.Instance.RunEnded(false);
            return "HUB_Principal";
        }

        if (roomCounter == 6)
        {
            roomCounter = 0;
            shouldBoss = true;

            RoomNumberManager.Instance.PlusRoomNumber();
            return "Hub_Secondaire" ;
        }
        else
        {
            if (shouldBoss)
            {
                RoomNumberManager.Instance.PlusLevelNumber();
                piece1 = false;
                piece2 = false;
                piece3 = false;
                piece4 = false;
                piece5 = false;
                piece6 = false;

                shouldBoss = false;
                shouldExterior += 0.2f;
                return "Piece_Boss";
            }
            else
            {
                int gen = Random.Range(1, 6);

                switch (gen)
                {
                    case 1 :
                        if(!piece1)
                        {
                            Debug.Log("Load Piece 1");
                            LoadPiece1();
                        } else return CheckBooleans();
                        break;

                    case 2:
                        if (!piece2)
                        {
                            Debug.Log("Load Piece 2");
                            LoadPiece2();
                        }
                        else return CheckBooleans();
                        break;

                    case 3:
                        if (!piece3)
                        {
                            Debug.Log("Load Piece 3");
                            LoadPiece3();
                        }
                        else return CheckBooleans();
                        break;

                    case 4:
                        if (!piece4)
                        {
                            Debug.Log("Load Piece 4");
                            LoadPiece4();
                        }
                        else return CheckBooleans();
                        break;

                    case 5:
                        if (!piece5)
                        {
                            Debug.Log("Load Piece 5");
                            LoadPiece5();
                        }
                        else return CheckBooleans();
                        break;

                    case 6:
                        if (!piece6)
                        {
                            Debug.Log("Load Piece 6");
                            LoadPiece6();
                        }
                        else return CheckBooleans();
                        break;

                    default: 
                        return CheckBooleans();
                        break;
                }
            } 
        }
    }

    string CheckBooleans()
    {
        Debug.Log("Had To Check Booleans");
        if (!piece1)
        {
            piece1 = true;
            RoomNumberManager.Instance.PlusRoomNumber();
            roomCounter++;
            return "Piece_1";
        }
        if (!piece2)
        {
            piece2 = true;
            RoomNumberManager.Instance.PlusRoomNumber();
            roomCounter++;
            return "Piece_2";
        }
        if (!piece3)
        {
            piece3 = true;
            RoomNumberManager.Instance.PlusRoomNumber();
            roomCounter++;
            return "Piece_3";
        }
        if (!piece4)
        {
            piece4 = true;
            RoomNumberManager.Instance.PlusRoomNumber();
            roomCounter++;
            return "Piece_4";
        }

        if (!piece5)
        {
            piece5 = true;
            RoomNumberManager.Instance.PlusRoomNumber();
            roomCounter++;
            return "Piece_5";
        }
            piece6 = true;
            RoomNumberManager.Instance.PlusRoomNumber();
            roomCounter++;
            return "Piece_6";
    }

    string LoadPiece1()
    {
        piece1 = true;
        RoomNumberManager.Instance.PlusRoomNumber();
        roomCounter++;
        return "Piece_1";
    }

    string LoadPiece2()
    {
        piece2 = true;
        RoomNumberManager.Instance.PlusRoomNumber();
        roomCounter++;
        return "Piece_2";
    }

    string LoadPiece3()
    {
        piece3 = true;
        RoomNumberManager.Instance.PlusRoomNumber();
        roomCounter++;
        return "Piece_3";
    }
    string LoadPiece4()
    {
        piece4 = true;
        RoomNumberManager.Instance.PlusRoomNumber();
        roomCounter++;
        return "Piece_4";
    }
    string LoadPiece5()
    {
        piece5 = true;
        RoomNumberManager.Instance.PlusRoomNumber();
        roomCounter++;
        return "Piece_5";
    }
    string LoadPiece6()
    {
        piece6 = true;
        RoomNumberManager.Instance.PlusRoomNumber();
        roomCounter++;
        return "Piece_6";
    }
}
