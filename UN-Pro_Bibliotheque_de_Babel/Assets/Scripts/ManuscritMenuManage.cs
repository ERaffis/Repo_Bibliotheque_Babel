using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManuscritMenuManage : MonoBehaviour
{
    public bool MenuIsActive;
    void Start()
    {
        MenuIsActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.activeSelf)
        {
            MenuIsActive = true;
            Time.timeScale = 0;
        }
    }

    public void CloseManuscritMenu()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
