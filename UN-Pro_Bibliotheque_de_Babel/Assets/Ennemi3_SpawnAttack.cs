using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemi3_SpawnAttack : MonoBehaviour
{
    public GameObject Ennemi3TowerPrefab;
    public float timebtwattacks;
    public float startTimeBtwAttacks;
    public int zonequantity;
    public Vector2 cellsize;
    public GameObject grid;
    public float width;
    public float height;

    public Animator animator;
    public bool isCasting;

    public int maxTowerSpawned;



    void Start()
    {
        startTimeBtwAttacks = 5f;
        timebtwattacks = startTimeBtwAttacks;
        zonequantity = 1;
        cellsize = grid.GetComponent<Grid>().cellSize;
        width = .65f * cellsize.x;
        height = .75f * cellsize.y;
        animator = GetComponent<Animator>();
        isCasting = false;

        maxTowerSpawned = 0;

    }


    void Update()
    {
        if (timebtwattacks <= 0 && maxTowerSpawned <= 3)
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
            animator.SetBool("IsCasting", true);
        }

        if (isCasting == false)
        {
            animator.SetBool("IsCasting", false);
        }
    }

    public IEnumerator SpawnZones()
    {
        maxTowerSpawned++;
        yield return new WaitForSeconds(0.75f);
        float angleStep = 360f / zonequantity;
        float angle = Random.Range(0.0f, 360f);

        for (int i = 0; i <= zonequantity - 1; i++)
        {

            angle += angleStep;
            if (angle >= 360f) angle -= 360f;

            //Sassurer que les dimmensions fonctionne pour la piece
            float zoneXposition = Mathf.Sin((angle * Mathf.PI) / 180) * Random.Range(3.0f, width);
            float zoneYposition = Mathf.Cos((angle * Mathf.PI) / 180) * Random.Range(3.0f, height);

            GameObject tmpObj = Instantiate(Ennemi3TowerPrefab, new Vector2(zoneXposition, zoneYposition), Quaternion.identity);
            tmpObj.GetComponent<TowerPrefab>().ennemi3maxtower = this;

            int colliders = Physics2D.OverlapCollider(tmpObj.GetComponent<Collider2D>(), new ContactFilter2D(), new List<Collider2D>());
            if (colliders != 0)
            {
                Destroy(tmpObj);
                StartCoroutine(SpawnZones());
            }

        }



    }

    public void Waitforanim()
    {
        isCasting = false;
    }
}
