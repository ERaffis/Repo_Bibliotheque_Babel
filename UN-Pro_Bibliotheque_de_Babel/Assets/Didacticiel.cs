using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Didacticiel : MonoBehaviour
{
    [Header("Manuscrit")]
    public GameObject objectManuscrit;
    public GameObject manuscritPopUp;
    public bool instantiateManuscrit;

    [Header("Counters")]
    public int i;
    public int y;
    public int w;
    public int a;

    [Header("Bracelet")]
    public GameObject braceletTrigger;
    public bool shouldTriggerBracelet;

    [Header("Popups")]
    public GameObject openInventory;
    public GameObject equipRune;
    public GameObject howToCombo;
    public GameObject howToDash;
    public GameObject pratiqueGolem;
    public GameObject ordreCombo;
    public GameObject fragment;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Inventory.Instance.givreActive && Inventory.Instance.embrasementActive && Inventory.Instance.amplificationActive)
        {
            shouldTriggerBracelet = true;
        }
        ActivateBracelet();
        ActivateManuscrit();

        if (PlayerScript.Instance.playerInputs.GetButtonDown("UIMenu"))
        {   
            DesactiverPopUpInventaire();
            if (w == 1)
            {
                equipRune.SetActive(false);
            }
            if (w == 0)
            {
                equipRune.SetActive(true);
                w++;
            } 
        }

        
        if(a == 5)
        {
            howToCombo.SetActive(false);
            pratiqueGolem.SetActive(true);

        }

        if (a == 10)
        {
            pratiqueGolem.SetActive(false);
            ordreCombo.SetActive(true);
            a++;
        }

        if (a == 15)
        {
            ordreCombo.SetActive(false);
            howToDash.SetActive(true);
            a++;
        }
    }

    public void ActivateBracelet()
    {
        if (shouldTriggerBracelet && y == 0)
            braceletTrigger.SetActive(true);
    }

    public void ActivateManuscrit()
    {
        if (instantiateManuscrit)
            objectManuscrit.SetActive(true);
    }

    public void DesactiverPopUpInventaire()
    {
        openInventory.SetActive(false);
    }
}
