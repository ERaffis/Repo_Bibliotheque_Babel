using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    //A REPARER
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

            foreach (GameObject item in GameObject.FindGameObjectsWithTag("Projectile_Ennemi"))
            {
                Destroy(item);
            }

            if (collision.transform.parent.gameObject.GetComponent<PlayerScript>().currentHealth > 20 )
            {
                collision.transform.parent.gameObject.GetComponent<PlayerScript>().SetPlayerHealth((int)(20 * Random.Range(0.1f, 0.9f)));
            }
            collision.transform.parent.transform.position = new Vector2(-50, -50);
            LevelManager.Instance.roomCounter--;
            RoomNumberManager.Instance.MinusLevelNumber();
            LevelManager.Instance.FadeToLevel();
            
        }
    }

    IEnumerator DisableCollider(Collider2D col)
    {
        col.enabled = false;
        yield return new WaitForEndOfFrame();
        col.enabled = true;
    }
}
