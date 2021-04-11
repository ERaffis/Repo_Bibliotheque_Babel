using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemySpawner : MonoBehaviour
{
    public GameObject[] ennemiesBiome1;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnnemies();
    }

    void SpawnEnnemies()
    {
        GameHandler.Instance.roomCleared = false;
        GameHandler.Instance.nmbSpawned = 0;
        GameHandler.Instance.nmbRemaining = 0;
        GameHandler.Instance.nmbToSpawns =  GameHandler.Instance.nmbRooms + GameHandler.Instance.gameDifficulty;
        int i = 0;

        foreach (var item in ennemiesBiome1)
        {
            item.SetActive(false);
        }
        foreach (var item in ennemiesBiome1)
        {
            if (i <= GameHandler.Instance.nmbToSpawns)
            {
                item.SetActive(false);
                i++;
            }
        }

        GameHandler.Instance.nmbRemaining = GameHandler.Instance.nmbSpawned;
    }

}
