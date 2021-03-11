using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockCursor : MonoBehaviour
{
    public bool cursorState;
    public Image buttonImage;
    public Sprite notLocked, locked;

    // Start is called before the first frame update
    void Start()
    {
        cursorState = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeCursorState()
    {
        if (cursorState == true)
        {
            Cursor.lockState = CursorLockMode.Locked;
            buttonImage.sprite = locked;
            //MainMenuManager.Instance.SetMainButton();
            cursorState = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            buttonImage.sprite = notLocked;
            //MainMenuManager.Instance.SetMainButton();
            cursorState = true;
        }

    }
}
