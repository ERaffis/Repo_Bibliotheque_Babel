using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

public class FindConfiner : MonoBehaviour
{

    public CinemachineConfiner confiner;


    private void OnEnable()
    {
        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= SceneManager_sceneLoaded;
    }

    private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        confiner.m_BoundingShape2D = GameObject.FindGameObjectWithTag("Confiner").GetComponent<Collider2D>();
    }

}
