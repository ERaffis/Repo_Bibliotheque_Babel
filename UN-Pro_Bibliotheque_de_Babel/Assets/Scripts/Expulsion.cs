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

        playerScript.gameObject.AddComponent<Expulsion>();

        //Dash du joueur
        GameObject firepoint = _GameHandler.GetComponent<GameHandler>().activeInstDir;
        playerScript.gameObject.GetComponent<Expulsion>().StartCoroutine(Dash(firepoint));
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
                playerScript.gameObject.AddComponent<Expulsion>();
                playerScript.gameObject.AddComponent<CircleCollider2D>();
                playerScript.gameObject.GetComponent<CircleCollider2D>().isTrigger = true;
                playerScript.gameObject.GetComponent<CircleCollider2D>().radius = (1.3f);

                //Ajout du script Embrassement sur le projectile pour le DOT
                playerScript.gameObject.AddComponent<Embrasement>();
                playerScript.gameObject.GetComponent<Embrasement>().numberOfTick = 3;

                //Dash du joueur
                GameObject firepoint1 = _GameHandler.GetComponent<GameHandler>().activeInstDir;
                playerScript.gameObject.GetComponent<Expulsion>().StartCoroutine(Dash(firepoint1));



                break;

            //Expulsion → Empalement
            case "Empalement":

                //Création collider autour du joueur
                playerScript.gameObject.gameObject.AddComponent<Expulsion>();
                playerScript.gameObject.AddComponent<CircleCollider2D>();
                playerScript.gameObject.GetComponent<CircleCollider2D>().isTrigger = true;
                playerScript.gameObject.GetComponent<CircleCollider2D>().radius = (1.3f);

                //Ajout du script Empalement sur le projectile pour le root
                playerScript.gameObject.AddComponent<Empalement>();

                //Dash du joueur
                GameObject firepoint2 = _GameHandler.GetComponent<GameHandler>().activeInstDir;
                playerScript.gameObject.GetComponent<Expulsion>().StartCoroutine(Dash(firepoint2));


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
                        playerScript.gameObject.AddComponent<Expulsion>();
                        playerScript.gameObject.AddComponent<CircleCollider2D>();
                        playerScript.gameObject.GetComponent<CircleCollider2D>().isTrigger = true;
                        playerScript.gameObject.GetComponent<CircleCollider2D>().radius = (1.3f);


                        //Ajout du script Embrassement sur le projectile pour le DOT
                        playerScript.gameObject.AddComponent<Embrasement>();
                        playerScript.gameObject.GetComponent<Embrasement>().numberOfTick = 3;


                        //Ajout du script Empalement sur le projectile pour le root
                        playerScript.gameObject.AddComponent<Empalement>();

                        //Dash du joueur
                        GameObject firepoint1 = _GameHandler.GetComponent<GameHandler>().activeInstDir;
                        playerScript.gameObject.GetComponent<Expulsion>().StartCoroutine(Dash(firepoint1));


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
                        playerScript.gameObject.AddComponent<Expulsion>();
                        playerScript.gameObject.AddComponent<CircleCollider2D>();
                        playerScript.gameObject.GetComponent<CircleCollider2D>().isTrigger = true;
                        playerScript.gameObject.GetComponent<CircleCollider2D>().radius = (1.3f);


                        //Ajout du script Embrassement sur le projectile pour le DOT
                        playerScript.gameObject.AddComponent<Embrasement>();
                        playerScript.gameObject.GetComponent<Embrasement>().numberOfTick = 3;


                        //Ajout du script Empalement sur le projectile pour le root
                        playerScript.gameObject.AddComponent<Empalement>();

                        //Dash du joueur
                        GameObject firepoint1 = _GameHandler.GetComponent<GameHandler>().activeInstDir;
                        playerScript.gameObject.GetComponent<Expulsion>().StartCoroutine(Dash(firepoint1));


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

    public void DestroyCollider()
    {
        
        if (playerScript.TryGetComponent(out CircleCollider2D a))
        {
            Destroy(playerScript.GetComponent<CircleCollider2D>());
        }
        if (playerScript.TryGetComponent(out Embrasement b))
        {
            Destroy(playerScript.GetComponent<Embrasement>());
        }
        if (playerScript.TryGetComponent(out Empalement c))
        {
            Destroy(playerScript.GetComponent<Empalement>());
        }
        if (playerScript.TryGetComponent(out Expulsion d))
        {
            Destroy(playerScript.GetComponent<Expulsion>());
        }

    }

    public IEnumerator Dash(GameObject dir)
    {
        playerScript.gameObject.GetComponent<SpriteRenderer>().color = Color.gray;
        playerScript.gameObject.layer = 11;
        playerScript.isImmune = true;

        yield return new WaitForSeconds(0.1f);

        playerRb.AddForce(new Vector2(Mathf.Lerp(dir.transform.localPosition.x, dashForce * dir.transform.localPosition.x,0.15f), Mathf.Lerp(dir.transform.localPosition.y, dashForce * dir.transform.localPosition.y, 0.15f)));

        yield return new WaitForSeconds(0.25f);

        playerScript.isImmune = false;
        playerScript.gameObject.layer = 7;
        playerScript.gameObject.GetComponent<SpriteRenderer>().color = Color.white;

        playerScript.gameObject.GetComponent<Expulsion>().DestroyCollider();

    }

}
