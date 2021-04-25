using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Didacticiel : MonoBehaviour
{
    [Header("Manuscrit")]
    public GameObject objectManuscrit;
    public GameObject manuscritPopUp;
    public bool instantiateManuscrit;

    [Header("DirectionPoint")]
    public Vector3 pointRunesDir;
    public Vector3 braceletDir;
    public Vector3 golemDir;
    public Vector3 fragmentDir;
    public Vector3 manuscritDir;
    public Vector3 exitDir;

    [Header("Counters")]
    public int i;
    public int y;
    public int w;
    public int a;
    public int b;

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

        ArrowPointer.Instance.targetPosition = pointRunesDir;
        ArrowPointer.Instance.shouldPoint = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Inventory.Instance.givreActive && Inventory.Instance.embrasementActive && Inventory.Instance.amplificationActive)
        {
            shouldTriggerBracelet = true;
        }
        ActivateBracelet();
        if(b == 0)
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
                ArrowPointer.Instance.targetPosition = golemDir;
                ArrowPointer.Instance.shouldPoint = true;
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
        { 
            braceletTrigger.SetActive(true);
            ArrowPointer.Instance.targetPosition = braceletDir;
        }
    }

    public void ActivateManuscrit()
    {
        if (instantiateManuscrit && b == 0)
        {     
            objectManuscrit.SetActive(true);
            manuscritPopUp.SetActive(true);
            b++;
        }
    }

    public void DesactiverPopUpInventaire()
    {
        openInventory.SetActive(false);
    }
}