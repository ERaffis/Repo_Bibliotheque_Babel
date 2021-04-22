using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectionBracelet : MonoBehaviour
{
    [Header("Bracelet")]
    public Bracelet activeBracelet;
    public Bracelet[] bracelets;
    public SpriteRenderer[] braceletPanneauImage;
    public BoxCollider2D triggerArea;

    public bool isInRange;

    [SerializeField] private GameObject ps4Input;

    private void Awake()
    {
        isInRange = false;
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
    }

    private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        if (arg0.name == "HUB_Principal" && Inventory.Instance.activeBracelet != null)
        {    
            Inventory.Instance.ClearBracelet();
        }
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= SceneManager_sceneLoaded;
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
                /*foreach (var item in braceletPanneauImage)
                {
                    item.color = new Color(.25f,.25f,.25f);
                }
                braceletPanneauImage[0].color = Color.white;
                */
                

                break;

            case "3 Projectiles":
                Inventory.Instance.activeBracelet = bracelets[1];
                Inventory.Instance.ClearBracelet();

                //Change active bracelet to white
                /*foreach (var item in braceletPanneauImage)
                {
                    item.color = new Color(.25f, .25f, .25f);
                }
                braceletPanneauImage[1].color = Color.white;
                */
                break;

            case "Mitrailleuse":
                Inventory.Instance.activeBracelet = bracelets[2];
                Inventory.Instance.ClearBracelet();

                //Change active bracelet to white
                /*foreach (var item in braceletPanneauImage)
                {
                    item.color = new Color(.25f, .25f, .25f);
                }
                braceletPanneauImage[2].color = Color.white;
                */
                break;

            case "Tete Chercheuse":
                Inventory.Instance.activeBracelet = bracelets[3];
                Inventory.Instance.ClearBracelet();

                //Change active bracelet to white
                /*foreach (var item in braceletPanneauImage)
                {
                    item.color = new Color(.25f, .25f, .25f);
                }
                braceletPanneauImage[3].color = Color.white;
                */
                break;
           
            default:
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
                //braceletPanneauImage[0].enabled = true;
                triggerArea.enabled = true;
                break;

            case "3 Projectiles":
                //braceletPanneauImage[1].enabled = true;
                triggerArea.enabled = true;
                break;

            case "Mitrailleuse":
                //braceletPanneauImage[2].enabled = true;
                triggerArea.enabled = true;
                break;

            case "Tete Chercheuse":
                //braceletPanneauImage[3].enabled = true;
                triggerArea.enabled = true;
                break;

            default:
                Debug.LogError("No Bracelet Were Found");
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "HalfCollider")
        {
            isInRange = true;
            ps4Input.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "HalfCollider")
        {
            isInRange = false;
            ps4Input.SetActive(false);
        }
    }
}
