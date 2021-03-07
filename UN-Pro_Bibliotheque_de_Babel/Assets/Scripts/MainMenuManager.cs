using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuManager : MonoBehaviour
{
    public void NouvellePartie()
    {
        SceneManager.LoadScene("HUB_Principal Start");
    }

    public void QuitterJeu()
    {
        Application.Quit();
        Debug.Log("Quit Successful");
    }
}