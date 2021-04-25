using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubRewardSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    [Header("Embrasement")]
    public GameObject embrasement;

    [Header("Givre")]
    public GameObject givre;

    [Header("Amplification")]
    public GameObject amplification;

    // Start is called before the first frame update
    void Start()
    {
        if (Inventory.Instance.runes[0].lvlRune != 3)
        {
            GameObject tmp1 = Instantiate(embrasement, spawnPoints[0]);
        }
        if (Inventory.Instance.runes[1].lvlRune != 3)
        {
            Instantiate(givre, spawnPoints[1]);
        }
        if (Inventory.Instance.runes[2].lvlRune != 3)
        {
            Instantiate(amplification, spawnPoints[2]);
        }
    }
}
