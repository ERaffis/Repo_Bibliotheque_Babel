using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRoomCollider : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player1")
        {
            if(GameHandler.Instance.roomCleared)
            {
                GameHandler.Instance.roomCleared = false;
                GameHandler.Instance.alreadySpawned = false;
                GameHandler.Instance.gameDifficulty += 0.1f;
                LevelManager.Instance.FadeToLevel();
            } else
            {
                Debug.LogWarning("Roomed Not Cleared");
            }
        }
    }
}
