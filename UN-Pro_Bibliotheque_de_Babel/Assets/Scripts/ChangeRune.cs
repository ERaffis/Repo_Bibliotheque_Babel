using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRune : MonoBehaviour
{
    private Inventory inventory;
    public int i;

    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("InventoryManager").GetComponent<Inventory>();
    }

    public void ChangeThisRune()
    {
        inventory.activeRune = inventory.equippedRunes[i];
    }
}
