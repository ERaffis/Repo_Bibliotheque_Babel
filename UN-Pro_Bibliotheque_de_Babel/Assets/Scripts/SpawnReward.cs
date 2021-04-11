using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnReward : MonoBehaviour
{
    public static SpawnReward Instance { get; private set; }

    public GameObject pageVierge;
    public GameObject fragment;

    public GameObject heart;


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

    public void SpawnItem(Vector2 pos, string tag = "")
    {
        Vector3 spawnLocation = new Vector3(pos.x, pos.y, 0);

        if (tag == "Ennemy")
        {
            if (Random.Range(0, 1) >= 0.85f)
            {
                GameObject newPage = Instantiate(pageVierge, spawnLocation, Quaternion.Euler(0, 0, 0));
            }    
            
        }
        if (tag == "Boss_1")
        {
            GameObject newPage = Instantiate(pageVierge, spawnLocation, Quaternion.Euler(0, 0, 0));

            /*for (int i = 0; i < (int)(Random.Range(2, 5)); i++)
            {
                Instantiate(heart, newPage.transform);
            }*/
        }

        if (tag == "Room")
        {
            GameObject newPage = Instantiate(pageVierge, spawnLocation, Quaternion.Euler(0, 0, 0));
        }
    }
}
