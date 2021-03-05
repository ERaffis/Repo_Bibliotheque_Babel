using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

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
    public Slider hb;

    private void Awake()
    {
        player1 = GameObject.FindGameObjectWithTag("Player1");
        hb = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<Slider>();
        mainUI = GameObject.FindGameObjectWithTag("MainUI").GetComponent<Canvas>();
        _GameHandler = GameObject.FindGameObjectWithTag("GameHandler");
    }

    private void Start()
    {
        SetMaxHealth();
        SetRoomInfo();
    }

    private void Update()
    {
        SetHealth();
    }

    public void SetMaxHealth()
    {
        hb.maxValue = player1.GetComponent<PlayerScript>().maxHealth;
        hb.value = player1.GetComponent<PlayerScript>().currentHealth;
    }

    public void SetHealth()
    {
        hb.value = player1.GetComponent<PlayerScript>().currentHealth;
    }

    public void SetRoomInfo()
    {
        roomInfo.text = _GameHandler.GetComponent<RoomNumberManager>().levelNumber + _GameHandler.GetComponent<RoomNumberManager>().roomNumber + "\n<size=16>" + _GameHandler.GetComponent<GameHandler>().biomeName;
    }

    public void HideUI()
    {
        mainUI.gameObject.SetActive(!mainUI.gameObject.activeSelf);
        underLayUI.gameObject.SetActive(!underLayUI.gameObject.activeSelf);
    }

}
