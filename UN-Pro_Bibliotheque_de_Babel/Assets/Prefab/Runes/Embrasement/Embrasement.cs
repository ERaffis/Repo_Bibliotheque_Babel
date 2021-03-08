using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Embrasement : Runes
{

    public GameObject projectile;

    public int numberOfTick;
    public int projectileSpeed;
    public int dotDamage;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        damage = 5;
        dotDamage = 2;
        projectileSpeed = 75;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Rune utilisée seule
    public void RuneMaitresse()
    {
        if(_GameHandler == null)
        {
            _GameHandler = GameObject.FindGameObjectWithTag("GameHandler").GetComponent<GameHandler>();
            playerScript = GameObject.FindGameObjectWithTag("Player1").GetComponent<PlayerScript>();
            playerRb = GameObject.FindGameObjectWithTag("Player1").GetComponent<Rigidbody2D>();
        }

        //Création du projetile
        GameObject firepoint = _GameHandler.activeInstDir;
        GameObject bullet = Instantiate(projectile, firepoint.transform);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();


        bullet.GetComponent<Embrasement_Projectile>().dotDamage = dotDamage;
        bullet.GetComponent<Embrasement_Projectile>().damage = damage;
        bullet.GetComponent<Embrasement_Projectile>().numberOfTick = numberOfTick;

        //Ajout de la force sur le projectile
        rb.AddForce(firepoint.transform.right * projectileSpeed);

        Destroy(bullet, 5f);
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

        //Création du projetile
        GameObject firepoint = _GameHandler.GetComponent<GameHandler>().activeInstDir;
        GameObject bullet = Instantiate(projectile, firepoint.transform);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();


        switch (rune2.name)
        {
            //Embrasement → Expulsion
            case "Expulsion":


                //Ajout du script Embrassement sur le projectile pour le DOT
                bullet.GetComponent<Embrasement_Projectile>().dotDamage = dotDamage;
                bullet.GetComponent<Embrasement_Projectile>().damage = damage;
                bullet.GetComponent<Embrasement_Projectile>().numberOfTick = numberOfTick;

                //Ajout du AreaEffector2D pour le knockback sur le projectile
                bullet.GetComponent<AreaEffector2D>().enabled = true;

                //Ajout de la force sur le projectile
                rb.AddForce(firepoint.transform.right * projectileSpeed);
                Destroy(bullet, 5f);

                break;

            //Embrasement → Empalement
            case "Empalement":

                //Ajout du script Embrassement sur le projectile pour le DOT
                bullet.GetComponent<Embrasement_Projectile>().dotDamage = dotDamage;
                bullet.GetComponent<Embrasement_Projectile>().damage = damage;
                bullet.GetComponent<Embrasement_Projectile>().numberOfTick = numberOfTick;

                //Ajout du script Empalement sur le projectile pour le root
                bullet.AddComponent<Empalement_Support>();
                bullet.GetComponent<Empalement_Support>().rootTime = 1f;

                //Ajout de la force sur le projectile
                rb.AddForce(firepoint.transform.right * projectileSpeed);
                Destroy(bullet, 5f);

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

        //Création du projetile
        GameObject firepoint = _GameHandler.GetComponent<GameHandler>().activeInstDir;
        GameObject bullet = Instantiate(projectile, firepoint.transform);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();


        switch (rune2.name)
        {
            //Embrasement → Expulsion
            case "Expulsion":

                switch (rune3.name)
                {
                    //Embrasement → Expulsion → Empalement
                    case "Empalement":

                        //Ajout du script Embrassement sur le projectile pour le DOT
                        bullet.GetComponent<Embrasement_Projectile>().dotDamage = dotDamage;
                        bullet.GetComponent<Embrasement_Projectile>().damage = damage;
                        bullet.GetComponent<Embrasement_Projectile>().numberOfTick = numberOfTick;

                        //Ajout du AreaEffector2D pour le knockback sur le projectile
                        bullet.GetComponent<AreaEffector2D>().enabled = true;

                        //Ajout du script Empalement sur le projectile pour le root
                        bullet.AddComponent<Empalement_Support>();
                        bullet.GetComponent<Empalement_Support>().rootTime = 1f;

                        //Ajout de la force sur le projectile
                        rb.AddForce(firepoint.transform.right * projectileSpeed);
                        Destroy(bullet, 5f);

                        break;

                    default:
                        break;
                }

                break;

            //Embrasement → Empalement 
            case "Empalement":

                switch (rune3.name)
                {
                    //Embrasement → Empalement → Expulsion
                    case "Expulsion":

                        //Ajout du script Embrassement sur le projectile pour le DOT
                        bullet.GetComponent<Embrasement_Projectile>().dotDamage = dotDamage;
                        bullet.GetComponent<Embrasement_Projectile>().damage = damage;
                        bullet.GetComponent<Embrasement_Projectile>().numberOfTick = numberOfTick;


                        //Ajout du AreaEffector2D pour le knockback sur le projectile
                        bullet.GetComponent<AreaEffector2D>().enabled = true;

                        //Ajout du script Empalement sur le projectile pour le root
                        bullet.AddComponent<Empalement_Support>();
                        bullet.GetComponent<Empalement_Support>().rootTime = 1f;

                        //Ajout de la force sur le projectile
                        rb.AddForce(firepoint.transform.right * projectileSpeed);
                        Destroy(bullet, 5f);

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
