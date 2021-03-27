using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using Rewired;


public class Inventory : MonoBehaviour
{
    public static Inventory Instance { get; private set; }
    
    public GameObject inventoryCanvas;

    private bool menuState;

    public bool[] isFull;
    public GameObject[] slots;


    public GameObject activeRune;


    public int activeIndex;
    public GameObject activeRuneUI;

    public bool isChangingRune;

    public GameObject openFirstButton;

    public int nmbPageVierge;
    public TextMeshProUGUI textPageVierge;
    public int nmbFragment;
    public TextMeshProUGUI textFragment;

    [Header("Active Bracelet Runes")]
    public GameObject[] equippedRunes;

    [Header("RuneBouton")]
    public Runes[] runes;
    public GameObject rune1, rune2, rune3, rune4;

    [Header("Bracelet")]
    public Bracelet activeBracelet;
    public GameObject bracelet1, bracelet2, bracelet3, bracelet4, bracelet5;
    public Bracelet[] bracelets;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        menuState = false;
        isChangingRune = false;


    }

    // Update is called once per frame
    void Update()
    {
        OpenCloseMenu();
    }

    public void AddPageVierge(int i)
    {
        nmbPageVierge += i;
        textPageVierge.SetText("x " + nmbPageVierge);
    }

    public void RemovePageVierge(int i)
    {
        nmbPageVierge -= i;
        textPageVierge.SetText("x " + nmbPageVierge);
    }

    public void AddFragment(int i)
    {
        nmbFragment += i;
        textFragment.SetText("x " + nmbFragment);
    }

    public void RemoveFragment(int i)
    {
        nmbFragment -= i;
        textFragment.SetText("x " + nmbFragment);
    }

    void OpenCloseMenu()
    {

        if (PlayerScript.Instance.playerInputs.GetButtonDown("UIMenu"))
        {

            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                PlayerScript.Instance.playerInputs.controllers.maps.SetMapsEnabled(false, "In Game");
                PlayerScript.Instance.playerInputs.controllers.maps.SetMapsEnabled(true, "In Menu");

                uiManager.Instance.mainUI.enabled = false;
                StartCoroutine(SelectFirstButton());

            }
            else 
            {
                Time.timeScale = 1;
                PlayerScript.Instance.playerInputs.controllers.maps.SetMapsEnabled(true, "In Game");
                PlayerScript.Instance.playerInputs.controllers.maps.SetMapsEnabled(false, "In Menu");
                uiManager.Instance.mainUI.enabled = true;

            }

            menuState = !menuState;
            inventoryCanvas.SetActive(menuState);
            TooltipSystem.Hide();
        }
    }

    IEnumerator SelectFirstButton()
    {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(openFirstButton);
    }

    public void ResetUI()
    {
        activeRune = null;
        isChangingRune = false;
        foreach (GameObject rune in equippedRunes)
        {
            rune.gameObject.GetComponent<Image>().sprite = rune.gameObject.GetComponent<RuneSlot>().unSelected;
        }
    }

    public void SelectRune(string name)
    {
        if (activeBracelet != null)
        {
            switch (name)
            {
                case "Embrasement":
                    for (int i = 0; i < activeBracelet.activeRunes.Length; i++)
                    {
                        if (activeBracelet.activeRunes[i] == null)
                        {
                            activeBracelet.activeRunes[i] = runes[0];
                            equippedRunes[i].GetComponent<Image>().sprite = rune1.GetComponent<Image>().sprite;
                            equippedRunes[i].GetComponent<Image>().color = rune1.GetComponent<Image>().color;
                            break;
                        }
                    }
                    break;

                case "Givre":
                    for (int i = 0; i < activeBracelet.activeRunes.Length; i++)
                    {
                        if (activeBracelet.activeRunes[i] == null)
                        {
                            activeBracelet.activeRunes[i] = runes[1];
                            equippedRunes[i].GetComponent<Image>().sprite = rune2.GetComponent<Image>().sprite;
                            equippedRunes[i].GetComponent<Image>().color = rune2.GetComponent<Image>().color;
                            break;
                        }
                    }
                    break;

                case "Amplification":
                    for (int i = 0; i < activeBracelet.activeRunes.Length; i++)
                    {
                        if (activeBracelet.activeRunes[i] == null)
                        {
                            activeBracelet.activeRunes[i] = runes[1];
                            equippedRunes[i].GetComponent<Image>().sprite = rune3.GetComponent<Image>().sprite;
                            equippedRunes[i].GetComponent<Image>().color = rune3.GetComponent<Image>().color;
                            break;
                        }
                    }
                    break;

                case "Explosion":
                    for (int i = 0; i < activeBracelet.activeRunes.Length; i++)
                    {
                        if (activeBracelet.activeRunes[i] == null)
                        {
                            activeBracelet.activeRunes[i] = runes[1];
                            equippedRunes[i].GetComponent<Image>().sprite = rune4.GetComponent<Image>().sprite;
                            equippedRunes[i].GetComponent<Image>().color = rune4.GetComponent<Image>().color;
                            break;
                        }
                    }
                    break;


                default:
                    break;
            }
        }
    }

    public void SelectBracelet(string name)
    {
        switch (name)
        {
            case "Simple":
                activeBracelet = bracelets[0];

                
                //Set the number of Runes available in the bracelet
                {
                    for (int i = 0; i < equippedRunes.Length; i++)
                    {
                        equippedRunes[i].SetActive(false);
                    }
                    for (int i = 0; i < activeBracelet.nmbRune; i++)
                    {
                        equippedRunes[i].SetActive(true);
                    }
                }
                

                //Change active bracelet to white
                bracelet1.GetComponent<Image>().color = Color.white;

                //Change inactive bracelet to gray
                { 
                bracelet2.GetComponent<Image>().color = Color.gray;
                bracelet3.GetComponent<Image>().color = Color.gray;
                bracelet4.GetComponent<Image>().color = Color.gray;
                bracelet5.GetComponent<Image>().color = Color.gray;
                }

                break;

            case "3 Projectiles":
                activeBracelet = bracelets[1];

                //Set the number of Runes available in the bracelet
                {
                    for (int i = 0; i < equippedRunes.Length; i++)
                    {
                        equippedRunes[i].SetActive(false);
                    }
                    for (int i = 0; i < activeBracelet.nmbRune; i++)
                    {
                        equippedRunes[i].SetActive(true);
                    }
                }

                //Change active bracelet to white
                bracelet2.GetComponent<Image>().color = Color.white;

                //Change inactive bracelet to gray
                {
                    bracelet1.GetComponent<Image>().color = Color.gray;
                bracelet3.GetComponent<Image>().color = Color.gray;
                bracelet4.GetComponent<Image>().color = Color.gray;
                bracelet5.GetComponent<Image>().color = Color.gray;
                }

                break;

            case "Mitrailleuse":
                activeBracelet = bracelets[2];

                //Set the number of Runes available in the bracelet
                {
                    for (int i = 0; i < equippedRunes.Length; i++)
                    {
                        equippedRunes[i].SetActive(false);
                    }
                    for (int i = 0; i < activeBracelet.nmbRune; i++)
                    {
                        equippedRunes[i].SetActive(true);
                    }
                }

                //Change active bracelet to white
                bracelet3.GetComponent<Image>().color = Color.white;

                //Change inactive bracelet to gray
                {
                    bracelet2.GetComponent<Image>().color = Color.gray;
                bracelet1.GetComponent<Image>().color = Color.gray;
                bracelet4.GetComponent<Image>().color = Color.gray;
                bracelet5.GetComponent<Image>().color = Color.gray;
                }

                break;

            case "Tete Chercheuse":
                activeBracelet = bracelets[3];

                //Set the number of Runes available in the bracelet
                {
                    for (int i = 0; i < equippedRunes.Length; i++)
                    {
                        equippedRunes[i].SetActive(false);
                    }
                    for (int i = 0; i < activeBracelet.nmbRune; i++)
                    {
                        equippedRunes[i].SetActive(true);
                    }
                }

                //Change active bracelet to white
                bracelet4.GetComponent<Image>().color = Color.white;

                //Change inactive bracelet to gray
                {
                    bracelet2.GetComponent<Image>().color = Color.gray;
                bracelet3.GetComponent<Image>().color = Color.gray;
                bracelet1.GetComponent<Image>().color = Color.gray;
                bracelet5.GetComponent<Image>().color = Color.gray;
                }

                break;

            case "Vitesse Rapide":
                activeBracelet = bracelets[4];

                //Set the number of Runes available in the bracelet
                {
                    for (int i = 0; i < equippedRunes.Length; i++)
                    {
                        equippedRunes[i].SetActive(false);
                    }
                    for (int i = 0; i < activeBracelet.nmbRune; i++)
                    {
                        equippedRunes[i].SetActive(true);
                    }
                }

                //Change active bracelet to white
                bracelet5.GetComponent<Image>().color = Color.white;

                //Change inactive bracelet to gray
                {
                    bracelet2.GetComponent<Image>().color = Color.gray;
                bracelet3.GetComponent<Image>().color = Color.gray;
                bracelet4.GetComponent<Image>().color = Color.gray;
                bracelet1.GetComponent<Image>().color = Color.gray;
                }

                break;

            default:
                Debug.LogWarning("Eat My Booty! Something went wrong");
                break;
        }
    }

    public void ActivateBracelet(string name)
    {
        switch (name)
        {
            case "Simple":
                bracelet1.GetComponent<Image>().enabled = true;
                bracelet1.GetComponent<Button>().enabled = true;
                break;

            case "3 Projectiles":
                bracelet2.GetComponent<Image>().enabled = true;
                bracelet2.GetComponent<Button>().enabled = true;
                break;

            case "Mitrailleuse":
                bracelet3.GetComponent<Image>().enabled = true;
                bracelet3.GetComponent<Button>().enabled = true;
                break;

            case "Tete Chercheuse":
                bracelet4.GetComponent<Image>().enabled = true;
                bracelet4.GetComponent<Button>().enabled = true;
                break;

            case "Vitesse Rapide":
                bracelet5.GetComponent<Image>().enabled = true;
                bracelet5.GetComponent<Button>().enabled = true;
                break;

            default:
                Debug.LogWarning("Eat My Booty Something went wrong");
                break;
        }
    }

    public void ClearBracelet()
    {
        for (int i = 0; i < activeBracelet.activeRunes.Length; i++)
        {
            activeBracelet.activeRunes[i] = null;
        }
    }
    
}
