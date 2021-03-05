using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expulsion : Runes
{


    public float dashForce = 10;
    public float dashDuration = 0.1f;
    public float dashCooldown = 3.5f;
    public PlayerMovement playerMovement;
    public Rigidbody2D rb;
    public GameHandler firepointGameHandler;

    // Start is called before the first frame update
    void Start()
    {
        damage = 100;
        knockback = 1;
        attackTimer = 0.3f;
     
    }

    //Rune en solo
    public void RuneMaitresse()
    {
        GameObject firepoint = firepointGameHandler.GetComponent<GameHandler>().activeInstDir;

        playerScript.rb.AddForce( firepoint.transform.right * dashForce, ForceMode2D.Impulse);

        print("Expulsion");
    }

    //Rune en combo avec 1 rune support
    public void RuneMaitresse(GameObject rune2)
    {
        switch (rune2.name)
        {
            case "Embrasement":

                print("Expulsion | Embrasement");
                break;

            case "Empalement":

                print("Expulsion | Empalement");
                break;

            default:
                break;
        }
    }

    //Rune en combo avec 2 rune support
    public void RuneMaitresse(GameObject rune2, GameObject rune3)
    {
        switch (rune2.name)
        {
            case "Embrasement":

                switch (rune3.name)
                {
                    case "Empalement":
                        print("Expulsion | Embrasement | Empalement");

                        break;

                    default:
                        break;
                }

                break;

            case "Empalement":

                switch (rune3.name)
                {
                    case "Embrassement":
                        print("Expulsion | Empalement | Embrassement");

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

    }


}
