using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AffichageRune : MonoBehaviour
{
    [SerializeField] private int index;
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
        if (Inventory.Instance.equippedRunes.Length >= index)
            runeImage.sprite = null;
    }

    private void Update()
    {
        if(Inventory.Instance.equippedRunes.Length >= index)
            runeImage.sprite = Inventory.Instance.equippedRunes[index].GetComponent<Image>().sprite;
    }
}
