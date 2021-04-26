using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossAoEAttack : MonoBehaviour
{
    public GameObject BossAoEPrefab;
    public float timebtwattacks;
    public float startTimeBtwAttacks;
    public int   zonequantity;

    public Vector2 cellsize;
    public GameObject grid;
    public float width;
    public float height;

    public Animator animator;
    public bool isCasting;
    public BossMovement bossCanMove;

    void Start()
    {
        startTimeBtwAttacks = 10f;
        timebtwattacks = startTimeBtwAttacks;
        zonequantity = 10;
        cellsize = grid.GetComponent<Grid>().cellSize;
        width =  .65f * cellsize.x;
        height = .75f * cellsize.y;
        animator = GetComponent<Animator>();
        
        
    }

    
    void Update()
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

        if (isCasting == true)
        {
            bossCanMove.canMove = false;
            animator.SetBool("IsCasting", true);
        }

        if (isCasting == false)
        {
            bossCanMove.canMove = true;
            animator.SetBool("IsCasting", false);
        }
    }

    public IEnumerator SpawnZones()
    {
        
        yield return new WaitForSeconds(1f);
        float angleStep = 360f / zonequantity;
        float angle = Random.Range(0.0f, 360f);

        for (int i = 0; i <= zonequantity - 1; i++)
        {
           
            angle += angleStep;
            if (angle >= 360f) angle -= 360f;

            //Sassurer que les dimmensions fonctionne pour la piece
            float zoneXposition =  Mathf.Sin((angle * Mathf.PI) / 180) * Random.Range(3.0f, width);
            float zoneYposition =  Mathf.Cos((angle * Mathf.PI) / 180) * Random.Range(3.0f, height);

            GameObject tmpObj = Instantiate(BossAoEPrefab, new Vector2(zoneXposition,zoneYposition), Quaternion.identity);



        }

        isCasting = false;
    }

    
}
