using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ApplyRune : MonoBehaviour
{
    private Inventory inventory;
    public Slot slot;
    public RuneSlot runeSlot;
    public GameObject rune;

    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("UIManager").GetComponent<Inventory>();
        slot = GetComponentInParent<Slot>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetRune()
    {
        if (inventory.activeRune != null)
        {
            runeSlot = inventory.activeRune.GetComponent<RuneSlot>();
            runeSlot.DropItem();

            Instantiate(inventory.slots[slot.i].transform.GetChild(0), inventory.activeRune.transform, false);

            foreach (GameObject item in inventory._UIManager.GetComponent<uiManager>().runeManager.GetComponent<RuneCasting>().equippedRune)
            {
                if (item.name == rune.name)
                {
                    Destroy(item);

                }
            }
            inventory._UIManager.GetComponent<uiManager>().runeManager.GetComponent<RuneCasting>().equippedRune[inventory.activeIndex] = rune;
            print("Set Rune : " + inventory.activeIndex + " to " + rune.name);

            inventory.activeRuneUI.GetComponent<Image>().enabled = true;
            inventory.activeRuneUI.GetComponent<Image>().sprite = this.GetComponent<Image>().sprite;
            inventory.ResetUI();
        }
    }
}
