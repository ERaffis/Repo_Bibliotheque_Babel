using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemi2_AoEAttack : MonoBehaviour
{
    public GameObject AoePrefab;
    public float timebtwattacks;
    public float startTimeBtwAttacks;
    public Transform playerposition;

    
    void Start()
    {
        playerposition = GameObject.FindGameObjectWithTag("Player1").GetComponent<Transform>();
        startTimeBtwAttacks = Random.Range(3,6);
        timebtwattacks = startTimeBtwAttacks;
    }

    // Update is called once per frame
    void Update()
    {
        if (timebtwattacks <= 0)
        {

            timebtwattacks = startTimeBtwAttacks;
            SpawnZones();

        }
        else
        {
            timebtwattacks -= Time.deltaTime;

        }
    }

    public void SpawnZones()
    {
        GameObject tmpObj = Instantiate(AoePrefab, new Vector2(playerposition.position.x, playerposition.position.y), Quaternion.identity);
    }
}
