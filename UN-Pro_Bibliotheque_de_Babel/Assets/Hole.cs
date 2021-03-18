using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerScript a))
        {
            collision.GetComponent<PlayerScript>().SetPlayerHealth(12);
            RoomNumberManager.Instance.MinusLevelNumber();
            LevelManager.Instance.shouldBiome = 200;
            LevelManager.Instance.shouldBoss = 0;
            LevelManager.Instance.shouldExterior = 0;
            LevelManager.Instance.shouldHub = 0;
            LevelManager.Instance.FadeToLevel();

        }
    }
}
