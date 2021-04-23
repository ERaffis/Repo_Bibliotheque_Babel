using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AffichageBracelet : MonoBehaviour
{
    [SerializeField] private Image runeImage;

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
        if (Inventory.Instance.activeBracelet != null)
            runeImage.sprite = null;
    }

    private void Update()
    {
        if (Inventory.Instance.activeBracelet != null)
            runeImage.sprite = Inventory.Instance.activeBracelet.baseSprite;
    }
}
