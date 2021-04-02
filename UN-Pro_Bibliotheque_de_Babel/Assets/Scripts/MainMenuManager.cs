using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class MainMenuManager : MonoBehaviour
{

    public GameObject optionButton;
    public GameObject firstButton;

    private void Awake()
    {

    }

    public void NouvellePartie()
    {
        SceneManager.LoadScene("FirstExposure");
    }

    public void QuitterJeu()
    {
        Application.Quit();
        Debug.Log("Quit Successful");
    }

    public void SetOptionsButton()
    {
        StartCoroutine(SetSelectedButton(optionButton));
    }

    public void SetMainButton()
    {
        StartCoroutine(SetSelectedButton(firstButton));
    }


    IEnumerator SetSelectedButton(GameObject button)
    {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(button);
    }
}