using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnReward : MonoBehaviour
{
    public static SpawnReward Instance { get; private set; }

    public GameObject pageVierge;
    public GameObject fragment;

    public GameObject healthPot;


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

        if (tag == "Ennemy")
        {
            if (Random.Range(0f, 1f) >= 0.75f)
            {
                GameObject newPage = Instantiate(pageVierge, pos, Quaternion.Euler(0, 0, 0));
                newPage.transform.parent = null;
            }

            if (Random.Range(0f, 1f) >= 0.9f)
            {
                GameObject newPage = Instantiate(healthPot, pos, Quaternion.Euler(0, 0, 0));
                newPage.transform.parent = null;

            }

        }
        if (tag == "Boss1")
        {

            for (int i = 0; i < (Random.Range(2, 5)); i++)
            {
                GameObject newPage = Instantiate(fragment, new Vector3(0, 6.5f), Quaternion.Euler(0, 0, 0));
                newPage.transform.parent = null;

            }
        }

        if (tag == "Room")
        {
            GameObject newPage = Instantiate(pageVierge, new Vector3(0,6.5f), Quaternion.Euler(0, 0, 0));
            newPage.transform.parent = null;

        }
    }
}
