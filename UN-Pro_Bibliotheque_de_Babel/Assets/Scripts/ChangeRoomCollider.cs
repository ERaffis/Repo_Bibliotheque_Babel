using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRoomCollider : MonoBehaviour
{
    public LevelManager lvlManager;

    public bool roomCleared;

    // Start is called before the first frame update
    void Start()
    {
        roomCleared = false;
    }
    // Update is called once per frame
    void Update()
    {
        CheckForRoomClear();
    }

    public void CheckForRoomClear()
    {
        if (lvlManager.playerScript._GameHandler.nmbRemaining <= 0) roomCleared = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "ExitTrigger")
        {
            if(roomCleared)
            {
                roomCleared = false;
                lvlManager.FadeToLevel();
            } else
            {
                Debug.LogWarning("Roomed Not Cleared");
            }
        }
    }
}
