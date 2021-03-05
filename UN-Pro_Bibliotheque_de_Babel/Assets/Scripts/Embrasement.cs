using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Embrasement : Runes
{

    public GameHandler firepointGameHandler;
    public GameObject projectile;

    public int numberOfTick;



    // Start is called before the first frame update
    void Start()
    {
        damage = 10;
        knockback = 0.1f;
        projectileSpeed = 150;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RuneMaitresse()
    {
        GameObject firepoint = firepointGameHandler.GetComponent<GameHandler>().activeInstDir;
        GameObject bullet = Instantiate(projectile, firepoint.transform);
        bullet.GetComponent<SpriteRenderer>().color = Color.yellow;

        bullet.AddComponent<Embrasement>();
        bullet.GetComponent<Embrasement>().numberOfTick = 5;

        bullet.AddComponent<BoxCollider2D>();
        bullet.GetComponent<BoxCollider2D>().size = new Vector2(1f, 1f);

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firepoint.transform.right * projectileSpeed);
        //Destroy(bullet, 5f);

        print("Embrasement");
    }

    //Rune en combo avec 1 rune support
    public void RuneMaitresse(GameObject rune2)
    {
        switch (rune2.name)
        {
            case "Expulsion":

                GameObject firepoint1 = firepointGameHandler.GetComponent<GameHandler>().activeInstDir;
                GameObject bullet1 = Instantiate(projectile, firepoint1.transform);
                bullet1.GetComponent<SpriteRenderer>().color = Color.yellow + Color.red;

                bullet1.AddComponent<Embrasement>();
                bullet1.GetComponent<Embrasement>().numberOfTick = 5;

                bullet1.AddComponent<BoxCollider2D>();
                bullet1.GetComponent<BoxCollider2D>().isTrigger = true;
                bullet1.GetComponent<BoxCollider2D>().usedByEffector = true;
                bullet1.GetComponent<BoxCollider2D>().size = new Vector2(2f, 2f);

                bullet1.AddComponent<AreaEffector2D>();
                bullet1.GetComponent<AreaEffector2D>().forceMagnitude = 10f;

                

                Rigidbody2D rb = bullet1.GetComponent<Rigidbody2D>();
                rb.AddForce(firepoint1.transform.right * projectileSpeed);
                Destroy(bullet1, 5f);

                print("Embrasement | Expulsion");
                break;

            case "Empalement":

                GameObject firepoint2 = firepointGameHandler.GetComponent<GameHandler>().activeInstDir;
                GameObject bullet2 = Instantiate(projectile, firepoint2.transform);
                bullet2.GetComponent<SpriteRenderer>().color = Color.yellow + Color.blue;

                bullet2.AddComponent<Embrasement>();
                bullet2.GetComponent<Embrasement>().numberOfTick = 5;

                bullet2.AddComponent<BoxCollider2D>();
                bullet2.GetComponent<BoxCollider2D>().isTrigger = true;
                bullet2.GetComponent<BoxCollider2D>().size = new Vector2(2f, 2f);

                bullet2.AddComponent<Empalement>();

                Rigidbody2D rb2 = bullet2.GetComponent<Rigidbody2D>();
                rb2.AddForce(firepoint2.transform.right * projectileSpeed);
                Destroy(bullet2, 5f);

                print("Embrasement | Empalement");
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
            case "Expulsion":

                switch (rune3.name)
                {
                    case "Empalement":
                        print("Embrasement | Expulsion | Empalement");

                        GameObject firepoint1 = firepointGameHandler.GetComponent<GameHandler>().activeInstDir;
                        GameObject bullet1 = Instantiate(projectile, firepoint1.transform);
                        bullet1.GetComponent<SpriteRenderer>().color = Color.yellow + Color.red + Color.blue;

                        bullet1.AddComponent<Embrasement>();
                        bullet1.GetComponent<Embrasement>().numberOfTick = 5;

                        bullet1.AddComponent<BoxCollider2D>();
                        bullet1.GetComponent<BoxCollider2D>().isTrigger = true;
                        bullet1.GetComponent<BoxCollider2D>().usedByEffector = true;
                        bullet1.GetComponent<BoxCollider2D>().size = new Vector2(2f, 2f);

                        bullet1.AddComponent<AreaEffector2D>();
                        bullet1.GetComponent<AreaEffector2D>().forceMagnitude = 10f;

                        bullet1.AddComponent<Empalement>();


                        Rigidbody2D rb = bullet1.GetComponent<Rigidbody2D>();
                        rb.AddForce(firepoint1.transform.right * projectileSpeed);
                        Destroy(bullet1, 5f);

                        break;

                    default:
                        break;
                }

                break;

            case "Empalement":

                switch (rune3.name)
                {
                    case "Expulsion":
                        print("Embrasement | Empalement | Expulsion");

                        GameObject firepoint1 = firepointGameHandler.GetComponent<GameHandler>().activeInstDir;
                        GameObject bullet1 = Instantiate(projectile, firepoint1.transform);
                        bullet1.GetComponent<SpriteRenderer>().color = Color.yellow + Color.red + Color.blue;

                        bullet1.AddComponent<Embrasement>();
                        bullet1.GetComponent<Embrasement>().numberOfTick = 5;

                        bullet1.AddComponent<BoxCollider2D>();
                        bullet1.GetComponent<BoxCollider2D>().isTrigger = true;
                        bullet1.GetComponent<BoxCollider2D>().usedByEffector = true;
                        bullet1.GetComponent<BoxCollider2D>().size = new Vector2(2f, 2f);

                        bullet1.AddComponent<AreaEffector2D>();
                        bullet1.GetComponent<AreaEffector2D>().forceMagnitude = 10f;

                        bullet1.AddComponent<Empalement>();


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

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            if (collision.gameObject.tag != "Player1")
            {
                this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                StartCoroutine(DamageoverTime(collision.gameObject));
            }
        }
    }

    public IEnumerator DamageoverTime(GameObject col)
    {
        for (int i = 0; i <= numberOfTick; i++)
        {
            col.GetComponent<Entities>().health -= damage;
            col.GetComponent<SpriteRenderer>().color = Color.red;
            print("Damaged Ennemy" + i);
            yield return new WaitForSeconds(.75f);
            col.GetComponent<SpriteRenderer>().color = Color.white;
            yield return new WaitForSeconds(0.1f);
        }

        Destroy(this.gameObject);
    }
}
