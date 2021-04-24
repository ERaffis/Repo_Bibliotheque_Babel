using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeRoomCollider : MonoBehaviour
{

    private void Awake()
    {
    }

    private void Start()
    {
        GameHandler.Instance.roomCleared = false;
        GameHandler.Instance.alreadySpawned = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "HalfCollider")
        {

            if(SceneManager.GetActiveScene().name == "HUB_Principal" || SceneManager.GetActiveScene().name == "HUB_Secondaire" || SceneManager.GetActiveScene().name == "HUB_Didacticiel")
            {
                LevelManager.Instance.FadeToLevel();
                GameHandler.Instance.nmbRooms++;
                collision.transform.position = new Vector2(0, -10);
            } else if(GameHandler.Instance.roomCleared)
            {
                LevelManager.Instance.FadeToLevel();
                GameHandler.Instance.nmbRooms++;
                collision.transform.position = new Vector2(0, -10);
            } else
            {
                Debug.LogWarning("Roomed Not Cleared");
            }
        }
    }
}
