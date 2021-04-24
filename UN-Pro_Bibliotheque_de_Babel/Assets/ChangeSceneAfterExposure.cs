using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ChangeSceneAfterExposure : MonoBehaviour
{
    [SerializeField] private GameObject button;
    private void Awake()
    {
        StartCoroutine(SetSelectedButton(button));
    }
    public void LoadHub()
    {
        SceneManager.LoadScene("HUB_Didacticiel");
    }

    IEnumerator SetSelectedButton(GameObject button)
    {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(button);
    }
}
