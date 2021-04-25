using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ManuscritMenuManage : MonoBehaviour
{
    [Header("Buttons")]
    public Button[] arrayButtonLVL1, arrayButtonLVL2, arrayButtonLVL3;

    [Header("Bouton Retour")]
    [SerializeField] private GameObject returnButton;

    [Header("Gate pour Bracelets")]
    [SerializeField] private GameObject braceletGate1, braceletGate2, braceletGate3;

    [Header("Already Pressed")]
    private List<string> alreadyPressedButtons = new List<string>();

    [Header("Unlocked Conditions")]
    private bool hasUnlockedLVL1, hasUnlockedLVL2;
    private int unlocklevel2;
    private int unlocklevel3;

    [Header("Prix des Upgrades")]
    public int prix_Bracelet_1;
    public int prix_Bracelet_2;
    public int prix_Bracelet_3;
    public int prix_Pv_120;
    public int prix_Pv_140;
    public int prix_Pv_160;
    public int prix_Slow_20;
    public int prix_Slow_40;
    public int prix_Slow_80;
    public int prix_Page_1;
    public int prix_Page_2;
    public int prix_Niveau_Rune;
    public int prix_Lifesteal_1;
    public int prix_Lifesteal_2;
    public int prix_Lifesteal_3;


    void Start()
    {
        hasUnlockedLVL1 = false;
        hasUnlockedLVL2 = false;

        unlocklevel2 = 0;
        unlocklevel3 = 0;

        foreach (var item in arrayButtonLVL2)
        {
            item.interactable = false;
        }
        foreach (var item in arrayButtonLVL3)
        {
            item.interactable = false;
        }
    }

    
    void Update()
    {


        if(unlocklevel2 == 5 && !hasUnlockedLVL1)
        {
            foreach (var item in arrayButtonLVL2)
            {
                item.interactable = true;
            }
            PlayerScript.Instance.resurectCharge = true;
            hasUnlockedLVL1 = true;
        }

        if(unlocklevel3 == 5 && !hasUnlockedLVL2)
        {
            foreach (var item in arrayButtonLVL3)
            {
                item.interactable = true;
            }
            hasUnlockedLVL2 = true;
        }
       
    }

    public void ButtonPressed(string buttonName)
    {
        foreach (var item in alreadyPressedButtons)
        {
            if (buttonName == item)
                buttonName = "Already Pressed";
        }

        switch (buttonName)
        {
            case "Bracelet_1":
                if (Inventory.Instance.nmbFragment >= prix_Bracelet_1)
                {
                    Inventory.Instance.RemoveFragment(prix_Bracelet_1);

                    StartCoroutine(SelectFirstButton());
                    unlocklevel2++;
                    alreadyPressedButtons.Add(buttonName);
                    arrayButtonLVL1[0].gameObject.GetComponent<Image>().color = new Color(0.5f,0.5f, 0.5f, 0.45f);
                    if (braceletGate1) Destroy(braceletGate1);
                }
                break;

            case "Bracelet_2":
                if (Inventory.Instance.nmbFragment >= prix_Bracelet_2)
                {
                    Inventory.Instance.RemoveFragment(prix_Bracelet_2);

                    StartCoroutine(SelectFirstButton());
                    unlocklevel3++;
                    alreadyPressedButtons.Add(buttonName);
                    arrayButtonLVL2[0].gameObject.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 0.45f);
                    if (braceletGate2) Destroy(braceletGate2);
                }
                
                break;

            case "Bracelet_3":
                if (Inventory.Instance.nmbFragment >= prix_Bracelet_3)
                {
                    Inventory.Instance.RemoveFragment(prix_Bracelet_3);

                    StartCoroutine(SelectFirstButton());
                    alreadyPressedButtons.Add(buttonName);
                    arrayButtonLVL3[0].gameObject.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 0.45f);
                    if (braceletGate3) Destroy(braceletGate3);
                }
                
                break;

            case "PV_120":
                if (Inventory.Instance.nmbFragment >= prix_Pv_120)
                {
                    Inventory.Instance.RemoveFragment(prix_Pv_120);

                    StartCoroutine(SelectFirstButton());
                    unlocklevel2++;
                    arrayButtonLVL1[1].gameObject.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 0.45f);

                    if (PlayerScript.Instance.maxHealth == 100)
                    {
                        PlayerScript.Instance.SetMaxHealth(120);
                    }

                    alreadyPressedButtons.Add(buttonName);
                }
                
                break;

            case "PV_140":
                if (Inventory.Instance.nmbFragment >= prix_Pv_140)
                {
                    Inventory.Instance.RemoveFragment(prix_Pv_140);

                    StartCoroutine(SelectFirstButton());
                    unlocklevel3++;
                    arrayButtonLVL2[1].gameObject.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 0.45f);

                    if (PlayerScript.Instance.maxHealth == 120)
                    {
                        PlayerScript.Instance.SetMaxHealth(140);
                    }

                    alreadyPressedButtons.Add(buttonName);
                }

                
                break;

            case "PV_160":
                if (Inventory.Instance.nmbFragment >= prix_Pv_160)
                {
                    Inventory.Instance.RemoveFragment(prix_Pv_160);

                    StartCoroutine(SelectFirstButton());
                    arrayButtonLVL3[1].gameObject.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 0.45f);

                    if (PlayerScript.Instance.maxHealth == 140)
                    {
                        PlayerScript.Instance.SetMaxHealth(160);
                    }

                    alreadyPressedButtons.Add(buttonName);
                }

                
                break;

            case "Slow_20":
                if (Inventory.Instance.nmbFragment >= prix_Slow_20)
                {
                    Inventory.Instance.RemoveFragment(prix_Slow_20);
                    PlayerScript.Instance.gameObject.GetComponent<PlayerMovement>().pourcent20 = true;
                    PlayerScript.Instance.gameObject.GetComponent<PlayerMovement>().comboModifier = 0.8f;
                    StartCoroutine(SelectFirstButton());
                    unlocklevel2++;
                    arrayButtonLVL1[2].gameObject.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 0.45f);

                    alreadyPressedButtons.Add(buttonName);
                }

                
                break;

            case "Slow_40":
                if (Inventory.Instance.nmbFragment >= prix_Slow_40)
                {
                    Inventory.Instance.RemoveFragment(prix_Slow_40);
                    PlayerScript.Instance.gameObject.GetComponent<PlayerMovement>().pourcent40 = true;
                    PlayerScript.Instance.gameObject.GetComponent<PlayerMovement>().comboModifier = 0.6f;
                    StartCoroutine(SelectFirstButton());
                    unlocklevel3++;
                    arrayButtonLVL2[2].gameObject.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 0.45f);

                    alreadyPressedButtons.Add(buttonName);
                }
                
                break;

            case "Slow_80":
                if (Inventory.Instance.nmbFragment >= prix_Slow_80)
                {
                    Inventory.Instance.RemoveFragment(prix_Slow_80);
                    PlayerScript.Instance.gameObject.GetComponent<PlayerMovement>().pourcent80 = true;
                    PlayerScript.Instance.gameObject.GetComponent<PlayerMovement>().comboModifier = 0.2f;
                    StartCoroutine(SelectFirstButton());
                    arrayButtonLVL3[2].gameObject.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 0.45f);

                    alreadyPressedButtons.Add(buttonName);
                }
                
                break;

            case "Page_1":
                if (Inventory.Instance.nmbFragment >= prix_Page_1)
                {
                    Inventory.Instance.RemoveFragment(prix_Page_1);
                    Inventory.Instance.SetPageVierge(1);
                    Inventory.Instance.page1 = true;

                    StartCoroutine(SelectFirstButton());
                    unlocklevel2++;
                    arrayButtonLVL1[3].gameObject.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 0.45f);

                    alreadyPressedButtons.Add(buttonName);
                }
                
                break;

            case "Page_2":
                if (Inventory.Instance.nmbFragment >= prix_Page_2)
                {
                    Inventory.Instance.RemoveFragment(prix_Page_2);
                    Inventory.Instance.SetPageVierge(2);
                    Inventory.Instance.page2 = true;

                    StartCoroutine(SelectFirstButton());
                    unlocklevel3++;
                    arrayButtonLVL2[3].gameObject.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 0.45f);

                    alreadyPressedButtons.Add(buttonName);
                }
                
                break;

            case "Niveau_Rune":
                if (Inventory.Instance.nmbFragment >= prix_Niveau_Rune)
                {
                    Inventory.Instance.RemoveFragment(prix_Niveau_Rune);
                    Inventory.Instance.upgradeRune = true;
                    Inventory.Instance.runes[0].lvlRune = 2;
                    Inventory.Instance.runes[1].lvlRune = 2;
                    Inventory.Instance.runes[2].lvlRune = 2;
                    StartCoroutine(SelectFirstButton());
                    arrayButtonLVL3[3].gameObject.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 0.45f);

                    alreadyPressedButtons.Add(buttonName);
                }
               
                break;

            case "Lifesteal_1":
                if (Inventory.Instance.nmbFragment >= prix_Lifesteal_1)
                {
                    Inventory.Instance.RemoveFragment(prix_Lifesteal_1);
                    PlayerScript.Instance.lifeStealLvl1 = true;
                    StartCoroutine(SelectFirstButton());
                    unlocklevel2++;
                    arrayButtonLVL1[4].gameObject.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 0.45f);

                    alreadyPressedButtons.Add(buttonName);
                }
                
                break;

            case "Lifesteal_2":
                if (Inventory.Instance.nmbFragment >= prix_Lifesteal_2)
                {
                    Inventory.Instance.RemoveFragment(prix_Lifesteal_2);
                    PlayerScript.Instance.lifeStealLvl2 = true;

                    StartCoroutine(SelectFirstButton());
                    unlocklevel3++;
                    arrayButtonLVL2[4].gameObject.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 0.45f);

                    alreadyPressedButtons.Add(buttonName);
                }
                
                break;

            case "Lifesteal_3":
                if (Inventory.Instance.nmbFragment >= prix_Lifesteal_3)
                {
                    Inventory.Instance.RemoveFragment(prix_Lifesteal_3);
                    PlayerScript.Instance.lifeStealLvl3 = true;

                    StartCoroutine(SelectFirstButton());
                    arrayButtonLVL3[4].gameObject.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 0.45f);

                    alreadyPressedButtons.Add(buttonName);
                }
                
                break;

            case "Already Pressed":
                break;

            default:
                break;
        }
    }

    public void Closemenu()
    {
        gameObject.SetActive(false);
    }

    IEnumerator SelectFirstButton()
    {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(returnButton);
    }
}
