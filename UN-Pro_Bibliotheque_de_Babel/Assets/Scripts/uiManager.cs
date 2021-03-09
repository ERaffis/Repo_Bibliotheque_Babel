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
    public Canvas underLayUI;
    public TMP_Text roomInfo;
    public Image dashIcon;
    

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
    }

    private void Start()
    {
        SetRoomInfo();
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
        underLayUI.gameObject.SetActive(!underLayUI.gameObject.activeSelf);
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
