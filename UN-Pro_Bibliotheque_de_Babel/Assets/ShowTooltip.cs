using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShowTooltip : MonoBehaviour, ISelectHandler
{
    public GameObject[] tooltipsEmbrasement;
    public GameObject[] tooltipsGivre;
    public GameObject[] tooltipsAmplification;



    public void OnSelect(BaseEventData eventData)
    {
        switch (gameObject.name)
        {
            case "EmbrasementButton":
                foreach (var item in tooltipsGivre)
                {
                    item.SetActive(false);
                }
                foreach (var item in tooltipsAmplification)
                {
                    item.SetActive(false);
                }
                foreach (var item in tooltipsEmbrasement)
                {
                    item.SetActive(true);
                }
                break;

            case "GivreButton":
                foreach (var item in tooltipsEmbrasement)
                {
                    item.SetActive(false);
                }
                foreach (var item in tooltipsAmplification)
                {
                    item.SetActive(false);
                }
                foreach (var item in tooltipsGivre)
                {
                    item.SetActive(true);
                }
                break;

            case "AmplificationButton":
                foreach (var item in tooltipsGivre)
                {
                    item.SetActive(false);
                }
                foreach (var item in tooltipsEmbrasement)
                {
                    item.SetActive(false);
                }
                foreach (var item in tooltipsAmplification)
                {
                    item.SetActive(true);
                }
                break;

            default:
                break;
        }
    }
}
