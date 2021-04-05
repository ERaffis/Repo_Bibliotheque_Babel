using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class uiManager : MonoBehaviour
{

    public static uiManager Instance { get; private set; }

    [Header("Player")]
    public GameObject player1;

    [Header("Components")]
    public GameObject _GameHandler;
    public Canvas mainUI;
    public TMP_Text roomInfo;
    public Image dashIcon;

    public GameObject[] uiRunes;
    

    [Header("Relations")]
    public GameObject runeManager;

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

        player1 = GameObject.FindGameObjectWithTag("Player1");
 
        mainUI = GameObject.FindGameObjectWithTag("MainUI").GetComponent<Canvas>();
        _GameHandler = GameObject.FindGameObjectWithTag("GameHandler");
        runeManager = GameObject.FindGameObjectWithTag("RuneManager");
        foreach (var item in uiRunes)
        {
            item.SetActive(false); 
        }
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
        if (arg0.name == "HUB_Principal")
        {
            SetRoomInfoHUB();
        }
        else
        {
            SetRoomInfo();
        }
    }


    private void Start()
    {
        SetRoomInfoHUB();
    }

    private void Update()
    {

    }

    public void SetRoomInfo()
    {
        roomInfo.text = RoomNumberManager.Instance.levelNumber.ToString() + "." + RoomNumberManager.Instance.roomNumber + "\n<size=16>" + GameHandler.Instance.biomeName;
    }

    public void SetRoomInfoHUB()
    {
        roomInfo.text = "Hub Principal";
    }

    public void ChangeUiState()
    {
        mainUI.gameObject.SetActive(!mainUI.gameObject.activeSelf);
    }

    public void HideUI(GameObject canvas, bool state)
    {
        canvas.SetActive(state);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
