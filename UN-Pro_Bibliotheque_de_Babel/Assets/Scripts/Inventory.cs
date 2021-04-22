using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using Rewired;
using UnityEngine.SceneManagement;


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
    public Sprite runeOutline; 

    [Header("RuneBouton")]
    public Runes[] runes;
    public GameObject rune1, rune2, rune3, rune4;

    public bool embrasementActive, givreActive, amplificationActive;

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
        embrasementActive = false;
        givreActive = false;
        amplificationActive = false;
    }

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
        Debug.Log("Scene " + arg0.name + " loaded");
        if (arg0.name == "HUB_Principal")
        {
            FullClearBracelet();
            rune1.GetComponent<Image>().color = Color.grey;
            embrasementActive = false;
            rune2.GetComponent<Image>().color = Color.grey;
            givreActive = false;
            rune3.GetComponent<Image>().color = Color.grey;
            amplificationActive = false;
        }
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
                StartCoroutine(SetSelectedButton(rune1));

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
        }
    }

    IEnumerator SetSelectedButton(GameObject button)
    {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(button);
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
                    if(embrasementActive)
                    { 
                        bool nullFound = false;
                        for (int i = 0; i < activeBracelet.activeRunes.Length; i++)
                        {
                            if (activeBracelet.activeRunes[i] == null)
                            {
                                nullFound = true;
                                break;
                            }
                        }
                        if (!nullFound) ClearBracelet();

                        for (int i = 0; i < activeBracelet.activeRunes.Length; i++)
                        {
                            if (activeBracelet.activeRunes[i] == runes[0])
                                break;

                            if (activeBracelet.activeRunes[i] == null)
                            {
                                activeBracelet.activeRunes[i] = runes[0];
                                equippedRunes[i].GetComponent<Image>().sprite = rune1.GetComponent<Image>().sprite;
                                equippedRunes[i].GetComponent<Image>().color = rune1.GetComponent<Image>().color;
                                break;
                            }
                        }
                    }
                    break;

                case "Givre":
                    if (givreActive)
                    {
                        bool nullFound1 = false;
                        for (int i = 0; i < activeBracelet.activeRunes.Length; i++)
                        {
                            if (activeBracelet.activeRunes[i] == null)
                            {
                                nullFound1 = true;
                                break;
                            }
                        }
                        if (!nullFound1) ClearBracelet();

                        for (int i = 0; i < activeBracelet.activeRunes.Length; i++)
                        {
                            if (activeBracelet.activeRunes[i] == runes[1])
                                break;

                            if (activeBracelet.activeRunes[i] == null)
                            {
                                activeBracelet.activeRunes[i] = runes[1];
                                equippedRunes[i].GetComponent<Image>().sprite = rune2.GetComponent<Image>().sprite;
                                equippedRunes[i].GetComponent<Image>().color = rune2.GetComponent<Image>().color;
                                break;
                            }
                        }
                    }
                    break;

                case "Amplification":
                    if (amplificationActive)
                    {
                        bool nullFound2 = false;
                        for (int i = 0; i < activeBracelet.activeRunes.Length; i++)
                        {
                            if (activeBracelet.activeRunes[i] == null)
                            {
                                nullFound2 = true;
                                break;
                            }
                        }
                        if (!nullFound2) ClearBracelet();

                        for (int i = 0; i < activeBracelet.activeRunes.Length; i++)
                        {
                            if (activeBracelet.activeRunes[i] == runes[2])
                                break;

                            if (activeBracelet.activeRunes[i] == null)
                            {
                                activeBracelet.activeRunes[i] = runes[2];
                                equippedRunes[i].GetComponent<Image>().sprite = rune3.GetComponent<Image>().sprite;
                                equippedRunes[i].GetComponent<Image>().color = rune3.GetComponent<Image>().color;
                                break;
                            }
                        }
                    }
                    break;

                case "Explosion":

                    bool nullFound3 = false;
                    for (int i = 0; i < activeBracelet.activeRunes.Length; i++)
                    {
                        if (activeBracelet.activeRunes[i] == null)
                        {
                            nullFound3 = true;
                            break;
                        }
                    }
                    if (!nullFound3) ClearBracelet();

                    for (int i = 0; i < activeBracelet.activeRunes.Length; i++)
                    {
                        if (activeBracelet.activeRunes[i] == runes[3])
                            break;

                        if (activeBracelet.activeRunes[i] == null)
                        {
                            activeBracelet.activeRunes[i] = runes[3];
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
                //Debug.LogWarning("Eat My Booty Something went wrong");
                break;
        }
    }

    public void ClearBracelet()
    {
        if(activeBracelet != null)
        { 
            for (int i = 0; i < activeBracelet.activeRunes.Length; i++)
            {
                activeBracelet.activeRunes[i] = null;
            }
        

            //Set the number of Runes available in the bracelet
            
                for (int i = 0; i < equippedRunes.Length; i++)
                {
                    equippedRunes[i].SetActive(false);
                }
                for (int i = 0; i < activeBracelet.nmbRune; i++)
                {
                    equippedRunes[i].SetActive(true);
                    equippedRunes[i].GetComponent<Image>().sprite = runeOutline;
                    equippedRunes[i].GetComponent<Image>().color = Color.white;
                }
            
        }
    }

    public void FullClearBracelet()
    {
        foreach (var item in equippedRunes)
        {
            Debug.Log(item.name + " Inactive");
            item.SetActive(false);
        }

        if (activeBracelet != null)
        {
            for (int i = 0; i < activeBracelet.activeRunes.Length; i++)
            {
                activeBracelet.activeRunes[i] = null;
            }
            activeBracelet = null;

            
        }
    }
    
}
