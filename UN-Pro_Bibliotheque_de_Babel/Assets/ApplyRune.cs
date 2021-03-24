using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ApplyRune : MonoBehaviour
{
    public Slot slot;
    public RuneSlot runeSlot;
    public GameObject rune;

    // Start is called before the first frame update
    void Start()
    {
        slot = GetComponentInParent<Slot>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetRune()
    {
        if (Inventory.Instance.activeRune != null)
        {
            runeSlot = Inventory.Instance.activeRune.GetComponent<RuneSlot>();
            runeSlot.DropItem();

            Instantiate(Inventory.Instance.slots[slot.i].transform.GetChild(0), Inventory.Instance.activeRune.transform, false);
            /*
            foreach (GameObject item in inventory._UIManager.GetComponent<uiManager>().runeManager.GetComponent<RuneCasting>().equippedRune)
            {
                if (item.name == rune.name)
                {
                    Destroy(item);

                }
            }
            */
            //uiManager.Instance.runeManager.GetComponent<RuneCasting>().equippedRune[Inventory.Instance.activeIndex] = rune;
            print("Set Rune : " + Inventory.Instance.activeIndex + " to " + rune.name);

            Inventory.Instance.activeRuneUI.GetComponent<Image>().enabled = true;
            Inventory.Instance.activeRuneUI.GetComponent<Image>().sprite = this.GetComponent<Image>().sprite;
            Inventory.Instance.ResetUI();
        }
    }
}
