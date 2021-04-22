using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemi2_AoEAttack : MonoBehaviour
{
    public GameObject AoePrefab;
    public float timebtwattacks;
    public float startTimeBtwAttacks;
    public Transform playerposition;

    public Animator anim;
    public Ennemi2_Biome1 ennemyCanMove;
    public bool isCasting;


    void Start()
    {
        playerposition = GameObject.FindGameObjectWithTag("Player1").GetComponent<Transform>();
        startTimeBtwAttacks = Random.Range(3,6);
        timebtwattacks = startTimeBtwAttacks;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.GetComponent<Entities>().isStuned == false)
        {
            if (timebtwattacks <= 0)
            {
                isCasting = true;
                timebtwattacks = startTimeBtwAttacks;
                StartCoroutine(SpawnZones());
            }
            else
            {
               
                timebtwattacks -= Time.deltaTime;
            }
        }

        if (isCasting == true)
        {
            ennemyCanMove.ennemyCanMove = false;
            anim.SetBool("isCasting", true);
        }

        if (isCasting == false)
        {
            ennemyCanMove.ennemyCanMove = true;
            anim.SetBool("isCasting", false);
        }
    }

    public IEnumerator SpawnZones()
    {
        isCasting = true;
        yield return new WaitForSeconds(1f);
        GameObject tmpObj = Instantiate(AoePrefab, new Vector2(playerposition.position.x, playerposition.position.y), Quaternion.identity);

        isCasting = false;
    }

   
}
