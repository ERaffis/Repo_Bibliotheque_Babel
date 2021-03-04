using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneSlot : MonoBehaviour
{

    private Inventory inventory;
    public int i;
    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("InventoryManager").GetComponent<Inventory>();
    }


    private void Update()
    {
       
    }
    public void DropItem()
    {
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }

    
}
