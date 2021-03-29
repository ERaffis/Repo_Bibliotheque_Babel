using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AoePrefabEnnemi1 : MonoBehaviour
{
    public int damage;
    public float activetime;

    private GameObject player;

   
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player1");
        damage = 20;
        activetime = 2f;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player1"))
        {
            if (!player.GetComponent<PlayerScript>().isImmune)
            {
                player.GetComponent<PlayerScript>().SetPlayerHealth(damage);
            }
        }
    }

    void Update()
    {
        if(activetime >0 && gameObject.activeInHierarchy)
        {
            activetime -= Time.time;
        }
        else if (activetime <= 0 && gameObject.activeInHierarchy)
        {
            Destroy(gameObject);
        }
    }

  
}
