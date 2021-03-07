using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Embrasement : Runes
{

    public GameObject projectile;
    public Sprite projectileSprite;

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

        //Changement de couleur du projectile
        bullet.GetComponent<SpriteRenderer>().sprite = projectileSprite;

        //Ajout du script Embrassement sur le projectile pour le DOT
        bullet.AddComponent<Embrasement>();
        bullet.GetComponent<Embrasement>().numberOfTick = 3;

        //Ajout du collider sur le projectile
        bullet.AddComponent<BoxCollider2D>();
        bullet.GetComponent<BoxCollider2D>().isTrigger = true;
        bullet.GetComponent<BoxCollider2D>().size = new Vector2(1f, 1f);

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

        switch (rune2.name)
        {
            //Embrasement → Expulsion
            case "Expulsion":

                //Création du projetile
                GameObject firepoint1 = _GameHandler.GetComponent<GameHandler>().activeInstDir;
                GameObject bullet1 = Instantiate(projectile, firepoint1.transform);

                //Ajout du script Embrassement sur le projectile pour le DOT
                bullet1.AddComponent<Embrasement>();
                bullet1.GetComponent<Embrasement>().numberOfTick = 5;

                //Ajout du collider sur le projectile
                bullet1.AddComponent<BoxCollider2D>();
                bullet1.GetComponent<BoxCollider2D>().isTrigger = true;
                bullet1.GetComponent<BoxCollider2D>().usedByEffector = true;
                bullet1.GetComponent<BoxCollider2D>().size = new Vector2(2f, 2f);

                //Ajout du AreaEffector2D pour le knockback sur le projectile
                bullet1.AddComponent<AreaEffector2D>();
                bullet1.GetComponent<AreaEffector2D>().forceMagnitude = 10f;

                //Ajout de la force sur le projectile
                Rigidbody2D rb = bullet1.GetComponent<Rigidbody2D>();
                rb.AddForce(firepoint1.transform.right * projectileSpeed);
                Destroy(bullet1, 5f);

                break;

            //Embrasement → Empalement
            case "Empalement":

                //Création du projetile
                GameObject firepoint2 = _GameHandler.GetComponent<GameHandler>().activeInstDir;
                GameObject bullet2 = Instantiate(projectile, firepoint2.transform);


                //Ajout du script Embrassement sur le projectile pour le DOT
                bullet2.AddComponent<Embrasement>();
                bullet2.GetComponent<Embrasement>().numberOfTick = 5;

                //Ajout du collider sur le projectile
                bullet2.AddComponent<BoxCollider2D>();
                bullet2.GetComponent<BoxCollider2D>().isTrigger = true;
                bullet2.GetComponent<BoxCollider2D>().size = new Vector2(2f, 2f);

                //Ajout du script Empalement sur le projectile pour le root
                bullet2.AddComponent<Empalement>();

                //Ajout de la force sur le projectile
                Rigidbody2D rb2 = bullet2.GetComponent<Rigidbody2D>();
                rb2.AddForce(firepoint2.transform.right * projectileSpeed);
                Destroy(bullet2, 5f);

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
            //Embrasement → Expulsion
            case "Expulsion":

                switch (rune3.name)
                {
                    //Embrasement → Expulsion → Empalement
                    case "Empalement":

                        //Création du projetile
                        GameObject firepoint1 = _GameHandler.GetComponent<GameHandler>().activeInstDir;
                        GameObject bullet1 = Instantiate(projectile, firepoint1.transform);


                        //Ajout du script Embrassement sur le projectile pour le DOT
                        bullet1.AddComponent<Embrasement>();
                        bullet1.GetComponent<Embrasement>().numberOfTick = 5;

                        //Ajout du collider sur le projectile
                        bullet1.AddComponent<BoxCollider2D>();
                        bullet1.GetComponent<BoxCollider2D>().isTrigger = true;
                        bullet1.GetComponent<BoxCollider2D>().usedByEffector = true;
                        bullet1.GetComponent<BoxCollider2D>().size = new Vector2(2f, 2f);

                        //Ajout du AreaEffector2D pour le knockback sur le projectile
                        bullet1.AddComponent<AreaEffector2D>();
                        bullet1.GetComponent<AreaEffector2D>().forceMagnitude = 10f;

                        //Ajout du script Empalement sur le projectile pour le root
                        bullet1.AddComponent<Empalement>();

                        //Ajout de la force sur le projectile
                        Rigidbody2D rb = bullet1.GetComponent<Rigidbody2D>();
                        rb.AddForce(firepoint1.transform.right * projectileSpeed);
                        Destroy(bullet1, 5f);

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

                        //Création du projetile
                        GameObject firepoint1 = _GameHandler.GetComponent<GameHandler>().activeInstDir;
                        GameObject bullet1 = Instantiate(projectile, firepoint1.transform);


                        //Ajout du script Embrassement sur le projectile pour le DOT
                        bullet1.AddComponent<Embrasement>();
                        bullet1.GetComponent<Embrasement>().numberOfTick = 5;

                        //Ajout du collider sur le projectile
                        bullet1.AddComponent<BoxCollider2D>();
                        bullet1.GetComponent<BoxCollider2D>().isTrigger = true;
                        bullet1.GetComponent<BoxCollider2D>().usedByEffector = true;
                        bullet1.GetComponent<BoxCollider2D>().size = new Vector2(2f, 2f);

                        //Ajout du AreaEffector2D pour le knockback sur le projectile
                        bullet1.AddComponent<AreaEffector2D>();
                        bullet1.GetComponent<AreaEffector2D>().forceMagnitude = 10f;

                        //Ajout du script Empalement sur le projectile pour le root
                        bullet1.AddComponent<Empalement>();

                        //Ajout de la force sur le projectile
                        Rigidbody2D rb = bullet1.GetComponent<Rigidbody2D>();
                        rb.AddForce(firepoint1.transform.right * projectileSpeed);
                        Destroy(bullet1, 5f);

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

    //Collision pour le DOT
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            //Si la Rune touche un ennemi
            if (collision.gameObject.tag != "Player1")
            {
                collision.GetComponent<Entities>().currentHealth -= damage;
                if(collision.gameObject != null) StartCoroutine(DamageoverTime(collision.gameObject));
                this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    }

    //Dégâts sur l'ennemi
    public IEnumerator DamageoverTime(GameObject col)
    {
        if (col.GetComponent<Entities>().isTakingDamage == false)
        {
            col.GetComponent<Entities>().isTakingDamage = true;
            for (int i = 0; i <= numberOfTick; i++)
            {
                if (col)
                {
                    col.GetComponent<SpriteRenderer>().color = Color.red;
                    yield return new WaitForSeconds(.75f);
                    col.GetComponent<SpriteRenderer>().color = Color.white;
                    col.GetComponent<Entities>().currentHealth -= damage;
                    yield return new WaitForSeconds(0.1f);
                }
            }

            if(col) col.GetComponent<Entities>().isTakingDamage = false;
        }

        Destroy(this.gameObject);
    }
}
