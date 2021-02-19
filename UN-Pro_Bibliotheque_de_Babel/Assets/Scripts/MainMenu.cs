using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuManager : MonoBehaviour
{
    private void NouvellePartie()
    {
        SceneManager.LoadScene("SampleScene");
    }

    private void QuitterJeu()
    {
        Application.Quit();
    }
}