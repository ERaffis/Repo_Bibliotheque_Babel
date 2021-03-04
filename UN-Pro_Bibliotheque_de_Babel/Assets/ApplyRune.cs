using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyRune : MonoBehaviour
{
    private Inventory inventory;
    public Slot slot;

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
        Instantiate(inventory.slots[slot.i], inventory.activeRune.transform, false);
    }
}
