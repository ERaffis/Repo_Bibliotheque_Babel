using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Rewired;


public class Inventory : MonoBehaviour
{
    public static Inventory Instance { get; private set; }

    [Header("Player")]
    public PlayerScript player;

    [Header("Relations")]
    public GameObject _UIManager;

    
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

        _UIManager = GameObject.FindGameObjectWithTag("UIManager");
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


    void OpenCloseMenu()
    {

        if (PlayerScript.Instance.playerInputs.GetButtonDown("UIMenu"))
        {

            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                player.playerInputs.controllers.maps.SetMapsEnabled(false, "In Game");
                player.playerInputs.controllers.maps.SetMapsEnabled(true, "In Menu");

                StartCoroutine(SelectFirstButton());

            }
            else 
            {
                Time.timeScale = 1;
                player.playerInputs.controllers.maps.SetMapsEnabled(true, "In Game");
                player.playerInputs.controllers.maps.SetMapsEnabled(false, "In Menu");   
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
    
}
