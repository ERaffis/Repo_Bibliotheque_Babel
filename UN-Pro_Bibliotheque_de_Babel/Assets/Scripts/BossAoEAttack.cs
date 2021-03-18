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
    
    void Start()
    {
        startTimeBtwAttacks = 10f;
        timebtwattacks = startTimeBtwAttacks;
        zonequantity = 5;
        cellsize = grid.GetComponent<GridLayoutGroup>().cellSize;
        width =  7 * cellsize.x;
        height = 8 * cellsize.y;
    }

    
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
        float angleStep = 360f / zonequantity;
        float angle = Random.Range(0.0f, 360f);

        for (int i = 0; i <= zonequantity - 1; i++)
        {
           
            angle += angleStep;
            if (angle >= 360f) angle -= 360f;

            float zoneXposition =  Mathf.Sin((angle * Mathf.PI) / 180) * Random.Range(3.0f, width);
            float zoneYposition =  Mathf.Cos((angle * Mathf.PI) / 180) * Random.Range(3.0f, height);

            GameObject tmpObj = Instantiate(BossAoEPrefab, new Vector2(zoneXposition,zoneYposition), Quaternion.identity);



        }

    }
}
