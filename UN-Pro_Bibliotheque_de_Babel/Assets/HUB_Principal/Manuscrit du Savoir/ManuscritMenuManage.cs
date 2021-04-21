using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ManuscritMenuManage : MonoBehaviour
{

    public Button Bracelet1unlockbutton;
    public Button Bracelet2unlockbutton;
    public Button Bracelet3unlockbutton;

    public Button MaxPV120button;
    public Button MaxPV140button;
    public Button MaxPV160button;

    public Button slowcast20button;
    public Button slowcast40button;
    public Button slowcast80button;

    public Button pageblanche1button;
    public Button pageblanche2button;

    public Button levelminimumrunebutton;

    public Button lifegainonkill1button;
    public Button lifegainonkill2button;
    public Button lifegainonkill3button;

    [Header("BoutonRetour")]
    [SerializeField] private GameObject returnButton;

    private int unlocklevel2;
    private int unlocklevel3;


    void Start()
    {

        Bracelet1unlockbutton.interactable = true;
        Bracelet2unlockbutton.interactable = false;
        Bracelet3unlockbutton.interactable = false;
        
        MaxPV120button.interactable = true;
        MaxPV140button.interactable = false;
        MaxPV160button.interactable = false;

        slowcast20button.interactable = true;
        slowcast40button.interactable = false;
        slowcast80button.interactable = false;

        pageblanche1button.interactable = true;
        pageblanche2button.interactable = false;

        levelminimumrunebutton.interactable = false;

        lifegainonkill1button.interactable = true;
        lifegainonkill2button.interactable = false;
        lifegainonkill3button.interactable = false;

        unlocklevel2 = 0;
        unlocklevel3 = 0;
    }

    
    void Update()
    {


        if(unlocklevel2 == 5)
        {
            Bracelet2unlockbutton.interactable = true;
            MaxPV140button.interactable = true;
            slowcast40button.interactable = true;
            pageblanche2button.interactable = true;
            lifegainonkill2button.interactable = true;
            PlayerScript.Instance.resurectCharge = true;
            
        }

        if(unlocklevel3 == 5)
        {
            Bracelet3unlockbutton.interactable = true;
            MaxPV160button.interactable = true;
            slowcast80button.interactable = true;
            levelminimumrunebutton.interactable = true;
            lifegainonkill3button.interactable = true;
        }
       
    }

    public void BraceletUnlock1()
    {
        StartCoroutine(SelectFirstButton());
        unlocklevel2++;
        Bracelet1unlockbutton.interactable = false;
        Bracelet1unlockbutton.GetComponent<Image>().color = Color.green;
    }

    public void BraceletUnlock2()
    {
        StartCoroutine(SelectFirstButton());
        unlocklevel3++;
        Bracelet2unlockbutton.interactable = false;
        Bracelet2unlockbutton.GetComponent<Image>().color = Color.green;
    }

    public void BraceletUnlock3()
    {
        StartCoroutine(SelectFirstButton());
        Bracelet3unlockbutton.interactable = false;
        Bracelet3unlockbutton.GetComponent<Image>().color = Color.green;
    }

    public void MaxPV120()
    {
        StartCoroutine(SelectFirstButton());
        if (PlayerScript.Instance.maxHealth == 100)
        {
            PlayerScript.Instance.SetMaxHealth(120); 
        }
        unlocklevel2++;
        MaxPV120button.interactable = false;
        MaxPV120button.GetComponent<Image>().color = Color.green;
    }

    public void MaxPV140()
    {
        StartCoroutine(SelectFirstButton());
        if (PlayerScript.Instance.maxHealth == 120)
        {
            PlayerScript.Instance.SetMaxHealth(140);
        }
        unlocklevel3++;
        MaxPV140button.interactable = false;
        MaxPV140button.GetComponent<Image>().color = Color.green;
    }

    public void MaxPV160()
    {
        StartCoroutine(SelectFirstButton());
        if (PlayerScript.Instance.maxHealth == 140)
        {
            PlayerScript.Instance.SetMaxHealth(160);
        }
        MaxPV160button.interactable = false;
        MaxPV160button.GetComponent<Image>().color = Color.green;
    }

    public void slowCast20()
    {
        StartCoroutine(SelectFirstButton());
        unlocklevel2++;
        slowcast20button.interactable = false;
        slowcast20button.GetComponent<Image>().color = Color.green;
    }
    public void slowCast40()
    {
        StartCoroutine(SelectFirstButton());
        unlocklevel3++;
        slowcast40button.interactable = false;
        slowcast40button.GetComponent<Image>().color = Color.green;
    }
    public void slowCast80()
    {
        StartCoroutine(SelectFirstButton());
        slowcast80button.interactable = false;
        slowcast80button.GetComponent<Image>().color = Color.green;
    }

    public void pageblanche1()
    {
        StartCoroutine(SelectFirstButton());
        unlocklevel2++;
        pageblanche1button.interactable = false;
        pageblanche1button.GetComponent<Image>().color = Color.green;
    }

    public void pageblanche2()
    {
        StartCoroutine(SelectFirstButton());
        unlocklevel3++;
        pageblanche2button.interactable = false;
        pageblanche2button.GetComponent<Image>().color = Color.green;
    }

    public void minimumlevelrune()
    {
        StartCoroutine(SelectFirstButton());
        levelminimumrunebutton.interactable = false;
        levelminimumrunebutton.GetComponent<Image>().color = Color.green;
    }

    public void lifegainonkill1()
    {
        StartCoroutine(SelectFirstButton());
        unlocklevel2++;
        lifegainonkill1button.interactable = false;
        lifegainonkill1button.GetComponent<Image>().color = Color.green;
    }

    public void lifegainonkill2()
    {
        StartCoroutine(SelectFirstButton());
        unlocklevel3++;
        lifegainonkill2button.interactable = false;
        lifegainonkill2button.GetComponent<Image>().color = Color.green;
    }

    public void lifegainonkill3()
    {
        StartCoroutine(SelectFirstButton());
        lifegainonkill3button.interactable = false;
        lifegainonkill3button.GetComponent<Image>().color = Color.green;
    }

    public void closemenu()
    {
        this.gameObject.SetActive(false);
    }

    IEnumerator SelectFirstButton()
    {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(returnButton);
    }
}
