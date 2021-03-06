using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public Animator animator;

    [Header("Class Relations")]
    public RoomNumberManager numberManager;
    public PlayerScript playerScript;

    private int levelToLoad;

    [Header("Level Generation Values")]
    public float shouldBiome;
    public float shouldBoss;
    public float shouldHub;
    public int currentBiome;
    public float shouldExterior;
    string roomName;

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

    public void FadeToLevel(int levelIndex)
    {
        StartCoroutine(playerScript.BlockMove());
        StartCoroutine(numberManager.WriteNumber(numberManager.levelNumber + numberManager.roomNumber));
        animator.SetTrigger("FadeOut");
        levelToLoad = levelIndex;
    }

    public void FadeToLevel()
    {
        roomName = GenerateRoom();

        if (roomName == "HUB_Principal")
        {
            animator.SetTrigger("FadeOut");
        } else
        {
            //StartCoroutine(playerScript.BlockMove());
            StartCoroutine(numberManager.WriteNumber(numberManager.levelNumber + numberManager.roomNumber));
            animator.SetTrigger("FadeOut");
        }

        
    }


    public void OnFadeComplete()
    {
        
        SceneManager.LoadScene(roomName);
        StartCoroutine(playerScript.SetSpawn());
    }

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
            return "HUB_Principal";
        }

        if (spawnHub * shouldHub > 0.95f)
        {
            numberManager.PlusRoomNumber();
            shouldHub = 0f;
            shouldBoss = 0f;
            shouldBiome = 100f;
            return "Hub_Secondaire" ;
        }
        else
        {
            ChangeBiome();

            switch (currentBiome)
            {
                case 0:
                    if (Random.Range(0.01f, 1f) * shouldBoss > 0.95f)
                    {
                        numberManager.PlusLevelNumber();
                        shouldHub = 100f;
                        shouldBoss = 0f;
                        shouldExterior += 0.2f;
                        return "Boss_Biome_1";
                    }
                    else
                    {
                        numberManager.PlusRoomNumber();
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
                        numberManager.PlusLevelNumber();
                        shouldHub = 100f;
                        shouldBoss = 0f;
                        shouldExterior += 0.2f;
                        return "Boss_Biome_2";
                    }
                    else
                    {
                        numberManager.PlusRoomNumber();
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
                        numberManager.PlusLevelNumber();
                        shouldHub = 100f;
                        shouldBoss = 0f;
                        shouldExterior += 0.2f;
                        return "Boss_Biome_3";
                    }
                    else
                    {
                        numberManager.PlusRoomNumber();
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

    public void ChangeBiome()
    {
        if (Random.Range(0.01f, 1f) * shouldBiome > 0.8f)
        {
            switch (currentBiome)
            {
                case 0:
                    print("1");
                    shouldBiome = 0;
                    if (Random.Range(0f, 1f) > 0.5f) currentBiome = 1;
                    else currentBiome = 2;
                    break;

                case 1:
                    print("2");
                    shouldBiome = 0;
                    if (Random.Range(0f, 1f) > 0.5f) currentBiome = 2;
                    else currentBiome = 0;
                    break;

                case 2:
                    print("3");
                    shouldBiome = 0;
                    if (Random.Range(0f, 1f) > 0.5f) currentBiome = 0;
                    else currentBiome = 1;
                    break;

            }
        }
    }
}
