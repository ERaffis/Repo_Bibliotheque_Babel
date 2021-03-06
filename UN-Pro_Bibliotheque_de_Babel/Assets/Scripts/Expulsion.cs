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
        playerRb.AddForce( firepoint.transform.right * dashForce, ForceMode2D.Impulse);
        print("dash");

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

                break;

            //Expulsion → Empalement
            case "Empalement":

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


}
