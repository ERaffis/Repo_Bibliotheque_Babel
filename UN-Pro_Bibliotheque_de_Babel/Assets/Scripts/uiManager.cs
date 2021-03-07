using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class uiManager : MonoBehaviour
{
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
        roomInfo.text = _GameHandler.GetComponent<RoomNumberManager>().levelNumber + _GameHandler.GetComponent<RoomNumberManager>().roomNumber + "\n<size=16>" + _GameHandler.GetComponent<GameHandler>().biomeName;
    }
    public void SetRoomInfoHUB()
    {
        roomInfo.text = "Hub Principal";
    }

    public void HideUI()
    {
        mainUI.gameObject.SetActive(!mainUI.gameObject.activeSelf);
        underLayUI.gameObject.SetActive(!underLayUI.gameObject.activeSelf);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
