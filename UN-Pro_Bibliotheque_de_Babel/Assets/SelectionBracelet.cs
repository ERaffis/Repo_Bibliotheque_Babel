using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionBracelet : MonoBehaviour
{
    [Header("Bracelet")]
    public Bracelet activeBracelet;
    public Bracelet[] bracelets;
    public SpriteRenderer[] braceletPanneauImage;
    public BoxCollider2D triggerArea;

    public bool isInRange;

    private void Awake()
    {
        isInRange = false;
    }
    private void Update()
    {
        if (PlayerScript.Instance.playerInputs.GetButtonDown("Interact") && isInRange)
        {
            Debug.Log("selected bracelet " + name);
            SelectBracelet(name);
        }
    }
    public void SelectBracelet(string name)
    {
        switch (name)
        {
            case "Simple":
                Inventory.Instance.activeBracelet = bracelets[0];
                Inventory.Instance.ClearBracelet();
                //Change active bracelet to white
                foreach (var item in braceletPanneauImage)
                {
                    item.color = new Color(.25f,.25f,.25f);
                }
                braceletPanneauImage[0].color = Color.white;

                

                break;

            case "3 Projectiles":
                Inventory.Instance.activeBracelet = bracelets[1];
                Inventory.Instance.ClearBracelet();

                //Change active bracelet to white
                foreach (var item in braceletPanneauImage)
                {
                    item.color = new Color(.25f, .25f, .25f);
                }
                braceletPanneauImage[1].color = Color.white;

                break;

            case "Mitrailleuse":
                Inventory.Instance.activeBracelet = bracelets[2];
                Inventory.Instance.ClearBracelet();

                //Change active bracelet to white
                foreach (var item in braceletPanneauImage)
                {
                    item.color = new Color(.25f, .25f, .25f);
                }
                braceletPanneauImage[2].color = Color.white;

                break;

            case "Tete Chercheuse":
                Inventory.Instance.activeBracelet = bracelets[3];
                Inventory.Instance.ClearBracelet();

                //Change active bracelet to white
                foreach (var item in braceletPanneauImage)
                {
                    item.color = new Color(.25f, .25f, .25f);
                }
                braceletPanneauImage[3].color = Color.white;

                break;

            case "Vitesse Rapide":
                Inventory.Instance.activeBracelet = bracelets[4];
                Inventory.Instance.ClearBracelet();

                //Change active bracelet to white
                foreach (var item in braceletPanneauImage)
                {
                    item.color = new Color(.25f, .25f, .25f);
                }
                braceletPanneauImage[4].color = Color.white;

                break;

            default:
                Debug.LogWarning("Eat My Booty! Something went wrong");
                break;
        }
        foreach (var item in uiManager.Instance.uiRunes)
        {
            item.SetActive(false);
        }
        for (int i = 0; i < Inventory.Instance.activeBracelet.nmbRune; i++)
        {
            uiManager.Instance.uiRunes[i].SetActive(true);
        }
    }

    public void ActivateBracelet(string name)
    {
        switch (name)
        {
            case "Simple":
                braceletPanneauImage[0].enabled = true;
                triggerArea.enabled = true;
                break;

            case "3 Projectiles":
                braceletPanneauImage[1].enabled = true;
                triggerArea.enabled = true;
                break;

            case "Mitrailleuse":
                braceletPanneauImage[2].enabled = true;
                triggerArea.enabled = true;
                break;

            case "Tete Chercheuse":
                braceletPanneauImage[3].enabled = true;
                triggerArea.enabled = true;
                break;

            case "Vitesse Rapide":
                braceletPanneauImage[4].enabled = true;
                triggerArea.enabled = true;
                break;

            default:
                Debug.LogWarning("Eat My Booty Something went wrong");
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "HalfCollider")
        {
            isInRange = true;
            Debug.Log("Pressed Right Trigger to select bracelet");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "HalfCollider")
        {
            isInRange = false;
            Debug.Log("Out of range");
        }
    }
}
