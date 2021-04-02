using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemySpawner : MonoBehaviour
{

    public GameObject[] spawnLocationArray;

    public GameObject[] ennemiesBiome1;
    //public GameObject[] ennemiesBiome2;
    //public GameObject[] ennemiesBiome3;

    public GameObject[] modifEnvironnement;
    private int envSpawned;


    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnnemies();
        SpawnEnvironnement();
    }

    void SpawnEnnemies()
    {
        GameHandler.Instance.roomCleared = false;
        GameHandler.Instance.nmbSpawned = 0;
        GameHandler.Instance.nmbRemaining = 0;
        GameHandler.Instance.nmbToSpawns =  2 * (int) GameHandler.Instance.gameDifficulty;

        for (int i = 0; i <= GameHandler.Instance.nmbToSpawns; i++)
        {
            int index = Random.Range(0, spawnLocationArray.Length);
            GameObject spawnLocation = spawnLocationArray[index];

            if (spawnLocation == null) i--;
            if (spawnLocation != null)
            {
                
                GameHandler.Instance.nmbSpawned++;

                if (Random.Range(0f, 1f) >= .5f)
                {
                    GameObject ennemy = Instantiate(ennemiesBiome1[0], spawnLocation.transform);
                    ennemy.transform.parent = null;
                }
                else
                {
                    GameObject ennemy = Instantiate(ennemiesBiome1[1], spawnLocation.transform);
                    ennemy.transform.parent = null;
                }
                Destroy(spawnLocation);  
            }

        }
        
    

        /*
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
                            GameObject ennemy = Instantiate(ennemiesBiome1[0], spawnLocation.transform);
                            ennemy.transform.parent = null;
                        }
                        else
                        {
                            GameObject ennemy = Instantiate(ennemiesBiome1[1], spawnLocation.transform);
                            ennemy.transform.parent = null;
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
                            GameObject ennemy = Instantiate(ennemiesBiome1[0], spawnLocation.transform);
                            ennemy.transform.parent = null;
                        }
                        else
                        {
                            GameObject ennemy = Instantiate(ennemiesBiome1[1], spawnLocation.transform);
                            ennemy.transform.parent = null;
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
                            GameObject ennemy = Instantiate(ennemiesBiome1[0], spawnLocation.transform);
                            ennemy.transform.parent = null;
                        }
                        else
                        {
                            GameObject ennemy = Instantiate(ennemiesBiome1[1], spawnLocation.transform);
                            ennemy.transform.parent = null;
                        }

                    }
                }
                break;

            default:
                Debug.LogWarning("Something went wrong with the spawns");
                break;
        }
        */

        GameHandler.Instance.nmbRemaining = GameHandler.Instance.nmbSpawned;
    }

    void SpawnEnvironnement()
    {
            
        for (int i = 0; i < 4; i++)
        {
            int index1 = Random.Range(0, spawnLocationArray.Length);
            GameObject spawnLocation = spawnLocationArray[index1];
            int index = Random.Range(0, 4);

            if (spawnLocation == null) i--;

            if (spawnLocation != null)
            {
                switch (index)
                {
                    case 0:
                        GameObject env = Instantiate(modifEnvironnement[0], spawnLocation.transform);
                        env.transform.parent = null;
                        Destroy(spawnLocation);
                        break;
                    case 1:
                        GameObject env1 = Instantiate(modifEnvironnement[1], spawnLocation.transform);
                        env1.transform.parent = null;
                        Destroy(spawnLocation);
                        break;
                    case 2:
                        GameObject env2 = Instantiate(modifEnvironnement[2], spawnLocation.transform);
                        env2.transform.parent = null;
                        Destroy(spawnLocation);
                        break;
                    case 3:
                        GameObject env3 = Instantiate(modifEnvironnement[3], spawnLocation.transform);
                        env3.transform.parent = null;
                        Destroy(spawnLocation);
                        break;
                    case 4:
                        GameObject env4 = Instantiate(modifEnvironnement[4], spawnLocation.transform);
                        env4.transform.parent = null;
                        Destroy(spawnLocation);

                        break;

                    default:
                        break;
                    }
                }
                
            }
        
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
