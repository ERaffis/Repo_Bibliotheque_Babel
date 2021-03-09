using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemySpawner : MonoBehaviour
{

    public GameObject[] spawnLocationArray;

    public GameObject[] ennemiesBiome1;
    public GameObject[] ennemiesBiome2;
    public GameObject[] ennemiesBiome3;


    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnnemies();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnEnnemies()
    {
        GameHandler.Instance.roomCleared = false;
        GameHandler.Instance.nmbSpawned = 0;
        GameHandler.Instance.nmbRemaining = 0;
        GameHandler.Instance.nmbToSpawns =  2 * (int) GameHandler.Instance.gameDifficulty;

        // Spawn le nombre d'enemies en fonction de la difficulé et du biome. 
        switch (LevelManager.Instance.currentBiome)
        {
            case 0:
                foreach (GameObject spawnLocation in spawnLocationArray)
                {
                    if(GameHandler.Instance.nmbSpawned <= GameHandler.Instance.nmbToSpawns)
                    {
                        GameHandler.Instance.nmbSpawned++;
                        

                        if (Random.Range(0f, 1f) >= .5f)
                        {
                            Instantiate(ennemiesBiome1[0], spawnLocation.transform);
                        }
                        else
                        {
                            Instantiate(ennemiesBiome1[1], spawnLocation.transform);
                        }
                        
                    }
                }
                break;
            case 1:
                foreach (GameObject spawnLocation in spawnLocationArray)
                {
                    if (GameHandler.Instance.nmbSpawned <= GameHandler.Instance.nmbToSpawns)
                    {
                        GameHandler.Instance.nmbSpawned++;


                        if (Random.Range(0f, 1f) >= .5f)
                        {
                            Instantiate(ennemiesBiome1[0], spawnLocation.transform);
                        }
                        else
                        {
                            Instantiate(ennemiesBiome1[1], spawnLocation.transform);
                        }

                    }
                }
                break;
            case 2:
                foreach (GameObject spawnLocation in spawnLocationArray)
                {
                    if (GameHandler.Instance.nmbSpawned <= GameHandler.Instance.nmbToSpawns)
                    {
                        GameHandler.Instance.nmbSpawned++;


                        if (Random.Range(0f, 1f) >= .5f)
                        {
                            Instantiate(ennemiesBiome1[0], spawnLocation.transform);
                        }
                        else
                        {
                            Instantiate(ennemiesBiome1[1], spawnLocation.transform);
                        }

                    }
                }
                break;

            default:
                Debug.LogWarning("Something went wrong with the spawns");
                break;
        }

        GameHandler.Instance.nmbRemaining = GameHandler.Instance.nmbSpawned;
    }

    private void ResetSpawn()
    {
        foreach (GameObject item in spawnLocationArray)
        {
            GameHandler.Instance.nmbSpawned = 0;
            item.GetComponent<SpriteRenderer>().color = Color.white;
            item.GetComponent<SpriteRenderer>().enabled = false;
            SpawnEnnemies();
        }
    }
}
