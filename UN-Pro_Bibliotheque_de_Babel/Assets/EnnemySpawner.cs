using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemySpawner : MonoBehaviour
{
    [Header("Game Handler")]
    public GameHandler _GameHandler;

    public GameObject[] spawnLocationArray;

    public GameObject[] ennemiesBiome1;
    public GameObject[] ennemiesBiome2;
    public GameObject[] ennemiesBiome3;

    public float nmbToSpawns;
    public float nmbSpawned;

    private void Awake()
    {
        _GameHandler = GameObject.Find("GameHandler").GetComponent<GameHandler>();
    }

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnnemies();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) ResetSpawn();
    }

    void SpawnEnnemies()
    {
        nmbToSpawns =  5 * _GameHandler.gameDifficulty;

        // Spawn le nombre d'enemies en fonction de la difficulé et du biome. 
        switch (_GameHandler.lvlManager.currentBiome)
        {
            case 0:
                foreach (GameObject spawnLocation in spawnLocationArray)
                {
                    if(nmbSpawned <= nmbToSpawns)
                    {
                        nmbSpawned++;
                        
                        spawnLocation.GetComponent<SpriteRenderer>().enabled = true;

                        if (Random.Range(0f, 1f) >= .5f)
                        {
                            //Instantiate(ennemiesBiome1[0], spawnLocation.transform);
                            spawnLocation.GetComponent<SpriteRenderer>().color = Color.blue;
                        }
                        else
                        {
                            //Instantiate(ennemiesBiome1[1], spawnLocation.transform);
                            spawnLocation.GetComponent<SpriteRenderer>().color = Color.red;
                        }
                        
                    }
                }
                break;
            case 1:
                foreach (GameObject spawnLocation in spawnLocationArray)
                {
                    if (nmbSpawned <= nmbToSpawns)
                    {
                        nmbSpawned++;

                        spawnLocation.GetComponent<SpriteRenderer>().enabled = true;

                        if (Random.Range(0f, 1f) >= .5f)
                        {
                            //Instantiate(ennemiesBiome1[0], spawnLocation.transform);
                            spawnLocation.GetComponent<SpriteRenderer>().color = Color.blue;
                        }
                        else
                        {
                            //Instantiate(ennemiesBiome1[1], spawnLocation.transform);
                            spawnLocation.GetComponent<SpriteRenderer>().color = Color.red;
                        }

                    }
                }
                break;
            case 2:
                foreach (GameObject spawnLocation in spawnLocationArray)
                {
                    if (nmbSpawned <= nmbToSpawns)
                    {
                        nmbSpawned++;

                        spawnLocation.GetComponent<SpriteRenderer>().enabled = true;

                        if (Random.Range(0f, 1f) >= .5f)
                        {
                            //Instantiate(ennemiesBiome1[0], spawnLocation.transform);
                            spawnLocation.GetComponent<SpriteRenderer>().color = Color.blue;
                        }
                        else
                        {
                            //Instantiate(ennemiesBiome1[1], spawnLocation.transform);
                            spawnLocation.GetComponent<SpriteRenderer>().color = Color.red;
                        }

                    }
                }
                break;

            default:
                Debug.LogWarning("Something went wrong with the spawns");
                break;
        }

    }

    private void ResetSpawn()
    {
        foreach (GameObject item in spawnLocationArray)
        {
            nmbSpawned = 0f;
            item.GetComponent<SpriteRenderer>().color = Color.white;
            item.GetComponent<SpriteRenderer>().enabled = false;
            SpawnEnnemies();
        }
    }
}
