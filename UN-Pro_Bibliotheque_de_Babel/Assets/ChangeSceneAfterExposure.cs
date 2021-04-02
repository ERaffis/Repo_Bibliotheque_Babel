using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneAfterExposure : MonoBehaviour
{    
    public void LoadHub()
    {
        SceneManager.LoadScene("HUB_Principal");
    }
}
