using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RuneManager : MonoBehaviour
{
    [Header("Equipped Bracelet")]
    public Bracelet equippedBracelet;

    [Header("Combo")]
    public bool isComboing;
    public int nmbPressed;
    public bool pressed0, pressed1, pressed2, pressed3;
    public List<Runes> orderRune = new List<Runes>();

    public float timeBetween;
    public float timeForChargeSound = 0.25f;

    private void Start()
    {
        isComboing = false;
        pressed0 = false;
        pressed1 = false;
        pressed2 = false;
        pressed3 = false;
        nmbPressed = 0;
    }
    private void Update()
    {
        equippedBracelet = Inventory.Instance.activeBracelet;

        timeBetween += Time.deltaTime;
        CheckCombo();
        ShootRune();
        
    }
    private void LateUpdate()
    {
        CheckOrder();
    }

    private void ShootRune()
    {
        if (!isComboing) SingleRune();
        if (isComboing) ComboRune();
    }

    private void CheckCombo()
    {
        if (PlayerScript.Instance.playerInputs.GetButtonDown("Combo"))
        {
            isComboing = true;
        }
        PlayerScript.Instance.animator.SetBool("isComboing", isComboing);

        timeForChargeSound -= Time.deltaTime;

        if (isComboing && timeForChargeSound <= 0)
        {
            timeForChargeSound = 1.25f;
            SoundManager.PlaySound(SoundManager.Sound.ComboCharge);
        }
    }

    private void SingleRune()
    {
        if (equippedBracelet != null)
        {
            if(equippedBracelet.name == "Mitrailleuse")
            {
                if(PlayerScript.Instance.playerInputs.GetButton("Combo") && timeBetween >= equippedBracelet.castSpeed)
                    if (equippedBracelet.activeRunes[0] != null)
                    {
                        equippedBracelet.ProjectileSolo(equippedBracelet.name, equippedBracelet.activeRunes[0]);
                        SoundManager.PlaySound(SoundManager.Sound.PlayerAttack);
                        timeBetween = 0;
                    }
            }
            else { 
                if (PlayerScript.Instance.playerInputs.GetButtonDown("Rune 1") && timeBetween >= equippedBracelet.castSpeed && equippedBracelet.activeRunes.Length >= 1)
                {
                    if (equippedBracelet.activeRunes[0] != null)
                    {
                        equippedBracelet.ProjectileSolo(equippedBracelet.name, equippedBracelet.activeRunes[0]);
                        SoundManager.PlaySound(SoundManager.Sound.PlayerAttack);
                        timeBetween = 0;
                    }
                }
                if (PlayerScript.Instance.playerInputs.GetButtonDown("Rune 2") && timeBetween >= equippedBracelet.castSpeed && equippedBracelet.activeRunes.Length >= 2)
                {
                    if (equippedBracelet.activeRunes[1] != null)
                    {
                        equippedBracelet.ProjectileSolo(equippedBracelet.name, equippedBracelet.activeRunes[1]);
                        SoundManager.PlaySound(SoundManager.Sound.PlayerAttack);
                        timeBetween = 0;
                    }
                }
                if (PlayerScript.Instance.playerInputs.GetButtonDown("Rune 3") && timeBetween >= equippedBracelet.castSpeed && equippedBracelet.activeRunes.Length >= 3)
                {
                    if (equippedBracelet.activeRunes[2] != null)
                    {
                        equippedBracelet.ProjectileSolo(equippedBracelet.name, equippedBracelet.activeRunes[2]);
                        SoundManager.PlaySound(SoundManager.Sound.PlayerAttack);
                        timeBetween = 0;
                    }
                }
                if (PlayerScript.Instance.playerInputs.GetButtonDown("Rune 4") && timeBetween >= equippedBracelet.castSpeed && equippedBracelet.activeRunes.Length >= 4)
                {
                    if (equippedBracelet.activeRunes[3] != null)
                    {
                        equippedBracelet.ProjectileSolo(equippedBracelet.name, equippedBracelet.activeRunes[3]);
                        SoundManager.PlaySound(SoundManager.Sound.PlayerAttack);
                        timeBetween = 0;
                    }
                }
            }


        }
    }

    private void CheckOrder()
    {
        if(uiManager.Instance.mainUI.enabled == true)
        {
            if (equippedBracelet)
            {
                foreach (var item in equippedBracelet.activeRunes)
                {
                    if (item)
                    {
                        if (item.order == nmbPressed + 1)
                        {
                            foreach (var item1 in uiManager.Instance.uiRunes)
                            {
                                if (item1)
                                {
                                    if (item1.GetComponent<Image>().sprite.name == item.name && item1.GetComponent<Image>().color == Color.white)
                                    {
                                        //Mettre ici effet desire pour quand rune ordre peut etre active
                                        item1.GetComponent<Outline>().enabled = true;
                                    }
                                }
                            }
                        }

                        if (item.order != nmbPressed + 1)
                        {   
                            
                            foreach (var item1 in uiManager.Instance.uiRunes)
                            {
                                if (item1.TryGetComponent(out Image b))
                                {
                                    if (item1.GetComponent<Image>().sprite.name == item.name)
                                    {
                                        //Mettre ici effet desire pour quand rune ordre est desactive
                                        item1.GetComponent<Outline>().enabled = false;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    private void ComboRune()
    {
        if (equippedBracelet != null)
        {
            if (equippedBracelet.name == "Mitrailleuse")
            {
                if (PlayerScript.Instance.playerInputs.GetButton("Combo") && timeBetween >= equippedBracelet.castSpeed)
                    if (equippedBracelet.activeRunes[0] != null)
                    {
                        equippedBracelet.ProjectileSolo(equippedBracelet.name, equippedBracelet.activeRunes[0]);
                        SoundManager.PlaySound(SoundManager.Sound.PlayerAttack);
                        timeBetween = 0;
                    }
            } else { 
                if (PlayerScript.Instance.playerInputs.GetButtonDown("Rune 1") && equippedBracelet.activeRunes.Length >= 1)
                {
                    if (equippedBracelet.activeRunes[0] != null && !pressed0 && nmbPressed < equippedBracelet.nmbRune)
                    {
                        

                        pressed0 = true;
                        orderRune.Add(equippedBracelet.activeRunes[0]);
                        Debug.Log(orderRune);
                        nmbPressed++;
                        timeBetween = 0;

                        if (uiManager.Instance.uiRunes.Length >= 1)
                            if (uiManager.Instance.uiRunes[0] != null)
                            {
                                uiManager.Instance.uiRunes[0].GetComponent<Image>().color = Color.gray;
                                uiManager.Instance.uiOrder[0].SetActive(true);

                                uiManager.Instance.uiOrder[0].GetComponent<TMP_Text>().text = nmbPressed.ToString();
                            }

                    }
                }
                if (PlayerScript.Instance.playerInputs.GetButtonDown("Rune 2") && equippedBracelet.activeRunes.Length >= 2)
                {
                    if (equippedBracelet.activeRunes[1] != null && !pressed1 && nmbPressed < equippedBracelet.nmbRune)
                    {
                       
                        pressed1 = true;
                        orderRune.Add(equippedBracelet.activeRunes[1]);
                        Debug.Log(orderRune);
                        timeBetween = 0;

                        nmbPressed++;

                        if (uiManager.Instance.uiRunes.Length >= 1)
                            if (uiManager.Instance.uiRunes[1] != null)
                            {
                                uiManager.Instance.uiRunes[1].GetComponent<Image>().color = Color.gray;
                                uiManager.Instance.uiOrder[1].SetActive(true);

                                uiManager.Instance.uiOrder[1].GetComponent<TMP_Text>().text = nmbPressed.ToString();
                            }
                    }
                }
                if (PlayerScript.Instance.playerInputs.GetButtonDown("Rune 3") && equippedBracelet.activeRunes.Length >= 3)
                {
                    if (equippedBracelet.activeRunes[2] != null && !pressed2 && nmbPressed < equippedBracelet.nmbRune)
                    {
                        
                        pressed2 = true;
                        orderRune.Add(equippedBracelet.activeRunes[2]);
                        Debug.Log(orderRune);
                        timeBetween = 0;

                        nmbPressed++;

                        if (uiManager.Instance.uiRunes.Length >= 1)
                            if (uiManager.Instance.uiRunes[2] != null)
                            {
                                uiManager.Instance.uiRunes[2].GetComponent<Image>().color = Color.gray;
                                uiManager.Instance.uiOrder[2].SetActive(true);
                                uiManager.Instance.uiOrder[2].GetComponent<TMP_Text>().text = nmbPressed.ToString();
                            }
                    }
                }
                if (PlayerScript.Instance.playerInputs.GetButtonDown("Rune 4") && equippedBracelet.activeRunes.Length >= 4)
                {
                    if (equippedBracelet.activeRunes[3] != null && !pressed3 && nmbPressed < equippedBracelet.nmbRune)
                    {   
                        if(uiManager.Instance.uiRunes.Length >= 4)
                            if (uiManager.Instance.uiRunes[3] != null)
                                uiManager.Instance.uiRunes[3].GetComponent<Image>().color = Color.gray;

                        pressed3 = true;
                        orderRune.Add(equippedBracelet.activeRunes[3]);
                        Debug.Log(orderRune);
                        timeBetween = 0;

                        nmbPressed++;
                    }
                }
            }
        }

        if (PlayerScript.Instance.playerInputs.GetButtonUp("Combo"))
            LaunchCombo();
    }

    private void LaunchCombo()
    {
        switch (nmbPressed)
        {
            case 1:
                equippedBracelet.ProjectileCombo(equippedBracelet.name, orderRune[0]);
                SoundManager.PlaySound(SoundManager.Sound.PlayerAttack);
                break;

            case 2:
                equippedBracelet.ProjectileCombo(equippedBracelet.name, orderRune[0], orderRune[1]);
                SoundManager.PlaySound(SoundManager.Sound.PlayerAttack);
                break;

            case 3:
                equippedBracelet.ProjectileCombo(equippedBracelet.name, orderRune[0], orderRune[1], orderRune[2]);
                SoundManager.PlaySound(SoundManager.Sound.PlayerAttack);
                break;

            case 4:
                equippedBracelet.ProjectileCombo(equippedBracelet.name, orderRune[0], orderRune[1], orderRune[2], orderRune[3]);
                SoundManager.PlaySound(SoundManager.Sound.PlayerAttack);
                break;

            default:
                break;
        }
        foreach (var item in uiManager.Instance.uiRunes)
        {
            item.GetComponent<Image>().color = Color.white;
        }
        foreach (var item in uiManager.Instance.uiOrder)
        {
            item.SetActive(false);
        }

        //Clear Stuff for combo
        nmbPressed = 0;
        orderRune.Clear();
        pressed0 = false;
        pressed1 = false;
        pressed2 = false;
        pressed3 = false;
        isComboing = false;
    }
}
