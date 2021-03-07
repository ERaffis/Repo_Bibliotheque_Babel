using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expulsion : Runes
{


    public float dashForce = 1000;
    public float dashDuration = 0.1f;
    public float dashCooldown = 3.5f;

    // Start is called before the first frame update
    void Start()
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

        //Dash du joueur
        GameObject firepoint = _GameHandler.GetComponent<GameHandler>().activeInstDir;
        playerRb.AddForce(new Vector2(1000f * firepoint.transform.localPosition.x, 1000f * firepoint.transform.localPosition.y));

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
            //Expulsion → Embrasement

            case "Embrasement":

                //Création collider autour du joueur
                GameObject player1 = GameObject.Find("Player_1");
                player1.AddComponent<Expulsion>();
                player1.AddComponent<CircleCollider2D>();
                player1.GetComponent<CircleCollider2D>().isTrigger = true;
                player1.GetComponent<CircleCollider2D>().radius = (1.3f);

                //Ajout du script Embrassement sur le projectile pour le DOT
                player1.AddComponent<Embrasement>();
                player1.GetComponent<Embrasement>().numberOfTick = 3;

                player1.GetComponent<Expulsion>().StartCoroutine(DestroyCollider(player1));

                //StartCoroutine(DestroyCollider(player1));

                //Dash du joueur
                GameObject firepoint1 = _GameHandler.GetComponent<GameHandler>().activeInstDir;
                playerRb.AddForce(firepoint1.transform.right * dashForce, ForceMode2D.Impulse);

                break;

            //Expulsion → Empalement
            case "Empalement":

                //Création collider autour du joueur
                GameObject player2 = GameObject.Find("Player_1");
                player2.AddComponent<Expulsion>();
                player2.AddComponent<CircleCollider2D>();
                player2.GetComponent<CircleCollider2D>().isTrigger = true;
                player2.GetComponent<CircleCollider2D>().radius = (1.3f);

                //Ajout du script Empalement sur le projectile pour le root
                player2.AddComponent<Empalement>();

                //Dash du joueur
                GameObject firepoint2 = _GameHandler.GetComponent<GameHandler>().activeInstDir;
                playerRb.AddForce(firepoint2.transform.right * dashForce, ForceMode2D.Impulse);

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
            //Expulsion → Embrasement
            case "Embrasement":

                switch (rune3.name)
                {
                    //Expulsion → Embrasement → Empalement
                    case "Empalement":

                        //Création collider autour du joueur
                        GameObject player1 = GameObject.Find("Player_1");
                        player1.AddComponent<Expulsion>();
                        player1.AddComponent<CircleCollider2D>();
                        player1.GetComponent<CircleCollider2D>().isTrigger = true;
                        player1.GetComponent<CircleCollider2D>().radius = (1.3f);


                        //Ajout du script Embrassement sur le projectile pour le DOT
                        player1.AddComponent<Embrasement>();
                        player1.GetComponent<Embrasement>().numberOfTick = 3;


                        //Ajout du script Empalement sur le projectile pour le root
                        player1.AddComponent<Empalement>();

                        player1.GetComponent<Expulsion>().StartCoroutine(DestroyCollider(player1));

                        //Dash du joueur
                        GameObject firepoint1 = _GameHandler.GetComponent<GameHandler>().activeInstDir;
                        playerRb.AddForce(firepoint1.transform.right * dashForce, ForceMode2D.Impulse);

                        break;

                    default:
                        break;
                }

                break;

            //Expulsion → Empalement
            case "Empalement":

                switch (rune3.name)
                {
                    //Expulsion → Empalement → Embrasement 
                    case "Embrassement":

                        //Création collider autour du joueur
                        GameObject player1 = GameObject.Find("Player_1");
                        player1.AddComponent<Expulsion>();
                        player1.AddComponent<CircleCollider2D>();
                        player1.GetComponent<CircleCollider2D>().isTrigger = true;
                        player1.GetComponent<CircleCollider2D>().radius = (1.3f);


                        //Ajout du script Embrassement sur le projectile pour le DOT
                        player1.AddComponent<Embrasement>();
                        player1.GetComponent<Embrasement>().numberOfTick = 3;


                        //Ajout du script Empalement sur le projectile pour le root
                        player1.AddComponent<Empalement>();

                        player1.GetComponent<Expulsion>().StartCoroutine(DestroyCollider(player1));

                        //Dash du joueur
                        GameObject firepoint1 = _GameHandler.GetComponent<GameHandler>().activeInstDir;
                        playerRb.AddForce(firepoint1.transform.right * dashForce, ForceMode2D.Impulse);

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

    public IEnumerator DestroyCollider(GameObject player)
    {
        yield return new WaitForSeconds(0.1f);

        if (player.TryGetComponent(out CircleCollider2D a))
        {
            Destroy(player.GetComponent<CircleCollider2D>());
        }
        if (player.TryGetComponent(out Embrasement b))
        {
            Destroy(player.GetComponent<Embrasement>());
        }
        if (player.TryGetComponent(out Empalement c))
        {
            Destroy(player.GetComponent<Empalement>());
        }
        if (player.TryGetComponent(out Expulsion d))
        {
            Destroy(player.GetComponent<Expulsion>());
        }

    }

}
