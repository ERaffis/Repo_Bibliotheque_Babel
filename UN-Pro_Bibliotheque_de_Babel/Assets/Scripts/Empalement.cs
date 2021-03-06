using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Empalement : Runes
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    

    //Rune utilisée seule
    public void RuneMaitresse()
    {


        GameObject firepoint = _GameHandler.activeInstDir;
        
        RaycastHit2D hit = Physics2D.Raycast(transform.position, firepoint.transform.position,10f);       
        //if (hit.collider.gameObject.layer == 6)
        if (hit)
        {
            print("Cool");
        }

    }

    //Rune en combo avec 1 rune support
    public void RuneMaitresse(GameObject rune2)
    {
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

    }

    //Gestion collision
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            //Si la Rune touche un ennemi
            if (collision.gameObject.tag != "Player1")
            {
                collision.gameObject.transform.localScale = new Vector3(2, 2, 2);
                
            }
        }
    }
}
