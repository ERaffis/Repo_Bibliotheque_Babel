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

                int colliders = Physics2D.OverlapCollider(newPage.GetComponent<Collider2D>(), new ContactFilter2D(), new List<Collider2D>());

                if (colliders != 0)
                {
                    SpawnItem(new Vector2(newPage.transform.position.x + Random.Range(-1,1), newPage.transform.position.y + Random.Range(-1, 1)), "Ennemy");
                    Destroy(newPage);
                }
            }

            if (Random.Range(0f, 1f) >= 0.9f)
            {
                GameObject newPage = Instantiate(healthPot, new Vector2(pos.x + 0.5f, pos.y), Quaternion.Euler(0, 0, 0));
                newPage.transform.parent = null;

            }

        }
        if (tag == "Boss")
        {

            for (int i = 0; i < (Random.Range(2, 5)); i++)
            {
                GameObject newfragment = Instantiate(fragment, new Vector3(-2 + i, 6.5f), Quaternion.Euler(0, 0, 0));
                newfragment.transform.parent = null;

                int colliders = Physics2D.OverlapCollider(newfragment.GetComponent<Collider2D>(), new ContactFilter2D(), new List<Collider2D>());

                if (colliders != 0)
                {
                    SpawnItem(new Vector2(newfragment.transform.position.x + Random.Range(-1, 1), newfragment.transform.position.y + Random.Range(-1, 1)), "Boss");
                    Destroy(newfragment);
                }
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
