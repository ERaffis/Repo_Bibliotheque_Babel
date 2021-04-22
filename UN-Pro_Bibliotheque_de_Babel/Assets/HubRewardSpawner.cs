using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubRewardSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    [Header("Embrasement")]
    public GameObject embrasementLVL1, embrasementLVL2, embrasementLVL3;

    [Header("Givre")]
    public GameObject givreLVL1, givreLVL2, givreLVL3;

    [Header("Amplification")]
    public GameObject amplificationLVL1, amplificationLVL2, amplificationLVL3;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(embrasementLVL1, spawnPoints[0]);
        Instantiate(givreLVL1, spawnPoints[1]);
        Instantiate(amplificationLVL1, spawnPoints[2]);
    }
}
