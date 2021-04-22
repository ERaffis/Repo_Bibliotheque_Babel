using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("HalfCollider"))
        {
            foreach (GameObject item in GameObject.FindGameObjectsWithTag("Ennemy"))
            {
                Destroy(item);
            }

            foreach (GameObject item in GameObject.FindGameObjectsWithTag("Projectile"))
            {
                Destroy(item);
            }

            collision.transform.parent.GetComponent<PlayerScript>().SetPlayerHealth(12);
            RoomNumberManager.Instance.MinusLevelNumber();
            LevelManager.Instance.FadeToLevel();

        }
    }
}
