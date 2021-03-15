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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
            SpawnItem(new Vector2(0, -1), "Ennemy_1"); 
    }


    public void SpawnItem(Vector2 pos, string tag = "")
    {
        Vector3 spawnLocation = new Vector3(pos.x, pos.y, 0);

        if (tag == "Ennemy")
        {
            if (Random.Range(0, 1) >= 80)
            {
                GameObject newPage = Instantiate(pageVierge, spawnLocation, Quaternion.Euler(0, 0, 0));

                for (int i = 0; i < (int)(Random.Range(0, 2)); i++)
                {
                    Instantiate(heart, newPage.transform);
                }
            }    
            
        }
        if (tag == "Boss_1")
        {
            GameObject newPage = Instantiate(pageVierge, spawnLocation, Quaternion.Euler(0, 0, 0));

            Instantiate(fragment, spawnLocation, Quaternion.Euler(0, 0, 0));

            for (int i = 0; i < (int)(Random.Range(2, 5)); i++)
            {
                Instantiate(heart, newPage.transform);
            }
        }

        if (tag == "Room")
        {
            GameObject newPage = Instantiate(pageVierge, spawnLocation, Quaternion.Euler(0, 0, 0));

            Instantiate(pageVierge, spawnLocation, Quaternion.Euler(0, 0, 0));

            for (int i = 0; i < (int)(Random.Range(1, 3)); i++)
            {
                Instantiate(heart, newPage.transform);
            }
        }
    }
}
