using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyRune : MonoBehaviour
{
    private Inventory inventory;
    public Slot slot;
    public RuneSlot runeSlot;

    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("InventoryManager").GetComponent<Inventory>();
        slot = GetComponentInParent<Slot>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetRune()
    {
        if(inventory.activeRune != null)
        {
            runeSlot = inventory.activeRune.GetComponent<RuneSlot>();
            runeSlot.DropItem();

            Instantiate(inventory.slots[slot.i].transform.GetChild(0), inventory.activeRune.transform, false);
            inventory.ResetUI();
        }
    }
}
