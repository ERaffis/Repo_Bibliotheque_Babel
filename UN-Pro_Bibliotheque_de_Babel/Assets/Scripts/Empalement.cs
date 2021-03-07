using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Empalement : Runes
{

    private int rootTime;
    // Start is called before the first frame update
    void Start()
    {
        rootTime = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Rune utilisée seule
    public void RuneMaitresse()
    {
        if (_GameHandler == null)
        {
            _GameHandler = GameObject.FindGameObjectWithTag("GameHandler").GetComponent<GameHandler>();
            playerScript = GameObject.FindGameObjectWithTag("Player1").GetComponent<PlayerScript>();
            playerRb = GameObject.FindGameObjectWithTag("Player1").GetComponent<Rigidbody2D>();
        }
    }

    //Rune en combo avec 1 rune support
    public void RuneMaitresse(GameObject rune2)
    {
        if (_GameHandler == null)
        {
            _GameHandler = GameObject.FindGameObjectWithTag("GameHandler").GetComponent<GameHandler>();
            playerScript = GameObject.FindGameObjectWithTag("Player1").GetComponent<PlayerScript>();
            playerRb = GameObject.FindGameObjectWithTag("Player1").GetComponent<Rigidbody2D>();
        }

        switch (rune2.name)
        {
            //Empalement → Embrasement
            case "Embrasement":

                break;

            //Empalement → Expulsion
            case "Expuslion":

                break;

            default:
                break;
        }
    }

    //Rune en combo avec 2 rune support
    public void RuneMaitresse(GameObject rune2, GameObject rune3)
    {
        if (_GameHandler == null)
        {
            _GameHandler = GameObject.FindGameObjectWithTag("GameHandler").GetComponent<GameHandler>();
            playerScript = GameObject.FindGameObjectWithTag("Player1").GetComponent<PlayerScript>();
            playerRb = GameObject.FindGameObjectWithTag("Player1").GetComponent<Rigidbody2D>();
        }

        switch (rune2.name)
        {
            //Empalement → Embrasement
            case "Embrasement":

                switch (rune3.name)
                {
                    //Empalement → Embrasement → Expulsion
                    case "Expulsion":

                        break;

                    default:
                        break;
                }

                break;

            //Empalement → Expulsion
            case "Expulsion":

                switch (rune3.name)
                {
                    //Empalement → Expulsion → Embrasement 
                    case "Embrassement":

                        break;

                    default:
                        break;
                }
                break;

            default:
                break;
        }
    }

    //Rune en combo avec 3 rune support
    public void RuneMaitresse(GameObject rune2, GameObject rune3, GameObject rune4)
    {
        if (_GameHandler == null)
        {
            _GameHandler = GameObject.FindGameObjectWithTag("GameHandler").GetComponent<GameHandler>();
            playerScript = GameObject.FindGameObjectWithTag("Player1").GetComponent<PlayerScript>();
            playerRb = GameObject.FindGameObjectWithTag("Player1").GetComponent<Rigidbody2D>();
        }
    }

    //Gestion collision
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            //Si la Rune touche un ennemi
            if (collision.gameObject.tag != "Player1")
            {
                StartCoroutine(RootEnemy(collision.gameObject));                
            }
        }
    }

    private IEnumerator RootEnemy(GameObject enemy)
    {
        enemy.GetComponent<SpriteRenderer>().color = Color.green;

        if (enemy.TryGetComponent(out Ennemi2_Biome1 a))
        {
            enemy.GetComponent<Ennemi2_Biome1>().canMove = false;
            yield return new WaitForSeconds(rootTime);
            enemy.GetComponent<Ennemi2_Biome1>().canMove = true;

        } else if (enemy.TryGetComponent(out Entities b))
        {
            enemy.GetComponent<Entities>().canMove = false;
            yield return new WaitForSeconds(rootTime);
            enemy.GetComponent<Entities>().canMove = true;
        }
        enemy.GetComponent<SpriteRenderer>().color = Color.white;

    }
}
