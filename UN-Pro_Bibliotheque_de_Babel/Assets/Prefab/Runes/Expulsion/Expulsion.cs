using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expulsion : Runes
{

    public GameObject forceFieldPrefab;
    public GameObject forceFieldClone;
    public bool canDash;

    public float dashForce;
    public float dashDuration;
    public float dashCooldown;

    // Start is called before the first frame update
    void Start()
    {
        canDash = true;
        dashForce = 1000;
        dashDuration = 0.1f;
        dashCooldown = 3.5f;
    }

    public void AddForceField(string name)
    {
        switch (name)
        {
            case "Embrasement":
                print("exp + emb");

                forceFieldClone = Instantiate(forceFieldPrefab, playerScript.gameObject.transform) as GameObject;

                forceFieldClone.GetComponent<Dash>().playerScript = playerScript;
                forceFieldClone.GetComponent<Dash>().playerRb = playerRb;
                forceFieldClone.GetComponent<Dash>().firepoint = _GameHandler.GetComponent<GameHandler>().activeInstDir;

                forceFieldClone.GetComponent<Dash>().dashForce = dashForce;
                forceFieldClone.GetComponent<Dash>().dashDuration = dashDuration;
                forceFieldClone.GetComponent<Dash>().dashCooldown = dashCooldown;

                //Ajout du script Embrassement sur le projectile pour le DOT
                forceFieldClone.AddComponent<Embrasement_Support>();
                forceFieldClone.GetComponent<Embrasement_Support>().numberOfTick = 3;

                break;

            case "Empalement":
                print("exp + emp");

                forceFieldClone = Instantiate(forceFieldPrefab, playerScript.gameObject.transform) as GameObject;

                forceFieldClone.GetComponent<Dash>().playerScript = playerScript;
                forceFieldClone.GetComponent<Dash>().playerRb = playerRb;
                forceFieldClone.GetComponent<Dash>().firepoint = _GameHandler.GetComponent<GameHandler>().activeInstDir;

                forceFieldClone.GetComponent<Dash>().dashForce = dashForce;
                forceFieldClone.GetComponent<Dash>().dashDuration = dashDuration;
                forceFieldClone.GetComponent<Dash>().dashCooldown = dashCooldown;

                forceFieldClone.AddComponent<Empalement_Support>();
                forceFieldClone.GetComponent<Empalement_Support>().rootTime = 1f;

                break;

            case "Embrasement+Empalement":
                print("exp + emb + emp");

                forceFieldClone = Instantiate(forceFieldPrefab, playerScript.gameObject.transform) as GameObject;

                forceFieldClone.GetComponent<Dash>().playerScript = playerScript;
                forceFieldClone.GetComponent<Dash>().playerRb = playerRb;
                forceFieldClone.GetComponent<Dash>().firepoint = _GameHandler.GetComponent<GameHandler>().activeInstDir;

                forceFieldClone.GetComponent<Dash>().dashForce = dashForce;
                forceFieldClone.GetComponent<Dash>().dashDuration = dashDuration;
                forceFieldClone.GetComponent<Dash>().dashCooldown = dashCooldown;

                //Ajout du script Embrassement sur le projectile pour le DOT
                forceFieldClone.AddComponent<Embrasement_Support>();
                forceFieldClone.GetComponent<Embrasement_Support>().numberOfTick = 3;

                forceFieldClone.AddComponent<Empalement_Support>();
                forceFieldClone.GetComponent<Empalement_Support>().rootTime = 1f;

                break;

            case "Empalement+Embrasement":
                print("exp + emp + emb");

                forceFieldClone = Instantiate(forceFieldPrefab, playerScript.gameObject.transform) as GameObject;

                forceFieldClone.GetComponent<Dash>().playerScript = playerScript;
                forceFieldClone.GetComponent<Dash>().playerRb = playerRb;
                forceFieldClone.GetComponent<Dash>().firepoint = _GameHandler.GetComponent<GameHandler>().activeInstDir;

                forceFieldClone.GetComponent<Dash>().dashForce = dashForce;
                forceFieldClone.GetComponent<Dash>().dashDuration = dashDuration;
                forceFieldClone.GetComponent<Dash>().dashCooldown = dashCooldown;

                //Ajout du script Embrassement sur le projectile pour le DOT
                forceFieldClone.AddComponent<Embrasement_Support>();
                forceFieldClone.GetComponent<Embrasement_Support>().numberOfTick = 3;

                forceFieldClone.AddComponent<Empalement_Support>();
                forceFieldClone.GetComponent<Empalement_Support>().rootTime = 1f;

                break;

            default:
                print("exp");

                forceFieldClone = Instantiate(forceFieldPrefab, playerScript.gameObject.transform) as GameObject;

                forceFieldClone.GetComponent<Dash>().playerScript = playerScript;
                forceFieldClone.GetComponent<Dash>().playerRb = playerRb;
                forceFieldClone.GetComponent<Dash>().firepoint = _GameHandler.GetComponent<GameHandler>().activeInstDir;

                forceFieldClone.GetComponent<Dash>().dashForce = dashForce;
                forceFieldClone.GetComponent<Dash>().dashDuration = dashDuration;
                forceFieldClone.GetComponent<Dash>().dashCooldown = dashCooldown;

                break;
        }
        
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

        if(canDash)
        {
            AddForceField(null);
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

        if(playerScript.gameObject.transform.childCount <=1)
        {
            AddForceField(rune2.name);
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

        if (playerScript.gameObject.transform.childCount <= 1)
        {
            AddForceField(rune2.name + "+" + rune3.name);
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

        if (canDash) 
        {

        }

    }
}
