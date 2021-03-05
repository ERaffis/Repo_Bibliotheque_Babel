using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class Inventory : MonoBehaviour
{

    [Header("Player")]
    public PlayerScript player;

    public static Inventory instance;
    public GameObject inventoryCanvas;

    private bool menuState;

    public bool[] isFull;
    public GameObject[] slots;
    public GameObject[] equippedRunes;
    public GameObject activeRune;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this);
        }
        DontDestroyOnLoad(this);
    }
    // Start is called before the first frame update
    void Start()
    {
        menuState = false;
    }

    // Update is called once per frame
    void Update()
    {
        OpenCloseMenu();
    }


    void OpenCloseMenu()
    {
        if (player.playerInputs.GetButtonDown("Menu"))
        {

            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                player.playerInputs.controllers.maps.SetMapsEnabled(false, "In Game");
                player.playerInputs.controllers.maps.SetMapsEnabled(true, "In Menu");
            }
            else 
            {
                Time.timeScale = 1;
                player.playerInputs.controllers.maps.SetMapsEnabled(true, "In Game");
                player.playerInputs.controllers.maps.SetMapsEnabled(false, "In Menu");   
            }
            
            menuState = !menuState;
            inventoryCanvas.SetActive(menuState);
        }
    }
    
}
