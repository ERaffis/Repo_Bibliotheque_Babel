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
    public GameObject[] equippedRunes;
    public GameObject activeRune;
    public int activeIndex;
    public GameObject activeRuneUI;

    public bool isChangingRune;

    public GameObject openFirstButton;

    public int nmbPageVierge;
    public TextMeshProUGUI textPageVierge;
    public int nmbFragment;
    public TextMeshProUGUI textFragment;

    [Header("Bracelet")]
    public Bracelet activeBracelet;
    public Button bracelet1, bracelet2, bracelet3, bracelet4, bracelet5;

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

    public void SelectBracelet()
    {

    }

    public void ClearBracelet()
    {
        for (int i = 0; i < activeBracelet.activeRunes.Length; i++)
        {
            activeBracelet.activeRunes[i] = null;
        }
    }
    
}
