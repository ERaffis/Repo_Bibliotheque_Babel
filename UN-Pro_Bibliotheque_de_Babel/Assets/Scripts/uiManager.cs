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

        roomInfo.text = _GameHandler.GetComponent<RoomNumberManager>().levelNumber + _GameHandler.GetComponent<RoomNumberManager>().roomNumber + "\n<size=16>" + _GameHandler.GetComponent<GameHandler>().biomeName;
    }

    private void Update()
    {
        SetHealth();
    }

    public void SetMaxHealth()
    {
        hb.maxValue = player1.GetComponent<PlayerScript>().health;
        hb.value = player1.GetComponent<PlayerScript>().health;
    }

    public void SetHealth()
    {
        hb.value = player1.GetComponent<PlayerScript>().health;
    }


    public IEnumerator UpdateDash(float duration)
    {
        dashIcon.color = new Color(dashIcon.color.r, dashIcon.color.g, dashIcon.color.b, 0);
        float alpha = dashIcon.color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / duration)
        {
            Color newColor = new Color(dashIcon.color.r, dashIcon.color.g, dashIcon.color.b, Mathf.Lerp(alpha, 1, t));
            dashIcon.color = newColor;
            yield return null;
        }
    }
}
