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
                StartCoroutine(SpawnZone());
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
    }

    private IEnumerator SpawnZone()
    {
        GetComponent<Ennemi2_Biome1>().ennemyCanMove = false;
        GetComponent<Ennemi2_Biome1>().animator.SetBool("isCasting", true);
        timebtwattacks = startTimeBtwAttacks;


        yield return new WaitForSeconds(0.5f);

        GetComponent<Ennemi2_Biome1>().animator.SetBool("isCasting", false);
        GetComponent<Ennemi2_Biome1>().ennemyCanMove = true;
        GameObject tmpObj = Instantiate(AoePrefab, new Vector2(playerposition.position.x + Random.Range(-0.5f,0.5f), playerposition.position.y + Random.Range(-0.5f, 0.5f)), Quaternion.identity);

    }
}
