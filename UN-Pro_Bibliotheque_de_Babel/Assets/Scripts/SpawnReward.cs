 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
                GameObject newPage = Instantiate(pageVierge, new Vector2(pos.x-0.5f,pos.y), Quaternion.Euler(0, 0, 0));
                newPage.transform.parent = null;
            }

            if (Random.Range(0f, 1f) >= 0.9f)
            {
                GameObject newPage = Instantiate(healthPot, new Vector2(pos.x + 0.5f, pos.y), Quaternion.Euler(0, 0, 0));
                newPage.transform.parent = null;

            }

        }
        if (tag == "Boss1")
        {

            for (int i = 0; i < (Random.Range(2, 5)); i++)
            {
                GameObject newfragment = Instantiate(fragment, new Vector3(-2 + i, 6.5f), Quaternion.Euler(0, 0, 0));
                newfragment.transform.parent = null;

            }
        }

        if (tag == "Room")
        {
            if(SceneManager.GetActiveScene().name != "HUB_Didacticiel" || SceneManager.GetActiveScene().name != "HUB_Principal" || SceneManager.GetActiveScene().name != "HUB_Secondaire")
            {
                GameObject newfragment = Instantiate(fragment, new Vector3(0, 6.5f), Quaternion.Euler(0, 0, 0));
                newfragment.transform.parent = null;
            }
        }
    }
}
