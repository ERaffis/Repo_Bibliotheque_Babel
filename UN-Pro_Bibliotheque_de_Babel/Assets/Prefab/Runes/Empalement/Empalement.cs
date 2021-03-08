using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Empalement : Runes
{
    [Header("Projectile")]
    public GameObject projectile;

    [Header("Attributs")]
    public float rootTime;
    public int projectileSpeed;



    void Start()
    {

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

        //Création du projetile
        GameObject firepoint = _GameHandler.activeInstDir;
        GameObject bullet = Instantiate(projectile, firepoint.transform);

        bullet.GetComponent<Empalement_Projectile>().rootTime = rootTime;

        //Ajout de la force sur le projectile
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firepoint.transform.right * projectileSpeed);
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

        GameObject firepoint = _GameHandler.activeInstDir;
        GameObject bullet = Instantiate(projectile, firepoint.transform);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        bullet.GetComponent<Empalement_Projectile>().rootTime = rootTime;

        switch (rune2.name)
        {
            //Empalement → Embrasement
            case "Embrasement":

                bullet.AddComponent<Embrasement_Support>();
                bullet.GetComponent<Embrasement_Support>().damage = 6;
                bullet.GetComponent<Embrasement_Support>().dotDamage = 1;
                bullet.GetComponent<Embrasement_Support>().numberOfTick = 3;

                rb.AddForce(firepoint.transform.right * projectileSpeed);

                break;

            //Empalement → Expulsion
            case "Expulsion":

                bullet.GetComponent<AreaEffector2D>().enabled = true;

                rb.AddForce(firepoint.transform.right * projectileSpeed);
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

        GameObject firepoint = _GameHandler.activeInstDir;
        GameObject bullet = Instantiate(projectile, firepoint.transform);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        switch (rune2.name)
        {
            //Empalement → Embrasement
            case "Embrasement":

                switch (rune3.name)
                {
                    //Empalement → Embrasement → Expulsion
                    case "Expulsion":

                        bullet.GetComponent<Empalement_Projectile>().rootTime = rootTime;

                        bullet.AddComponent<Embrasement_Support>();
                        bullet.GetComponent<Embrasement_Support>().damage = 6;
                        bullet.GetComponent<Embrasement_Support>().dotDamage = 1;
                        bullet.GetComponent<Embrasement_Support>().numberOfTick = 3;

                        bullet.GetComponent<AreaEffector2D>().enabled = true;
                        
                        rb.AddForce(firepoint.transform.right * projectileSpeed);
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
                    case "Embrasement":

                        bullet.GetComponent<Empalement_Projectile>().rootTime = rootTime;

                        bullet.AddComponent<Embrasement_Support>();
                        bullet.GetComponent<Embrasement_Support>().damage = 6;
                        bullet.GetComponent<Embrasement_Support>().dotDamage = 1;
                        bullet.GetComponent<Embrasement_Support>().numberOfTick = 3;

                        //Ajout du AreaEffector2D pour le knockback sur le projectile
                        bullet.GetComponent<AreaEffector2D>().enabled = true;

                        //Ajout de la force sur le projectile
                        rb.AddForce(firepoint.transform.right * projectileSpeed);
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
