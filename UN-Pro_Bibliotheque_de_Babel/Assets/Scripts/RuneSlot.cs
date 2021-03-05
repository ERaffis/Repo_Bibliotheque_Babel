using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RuneSlot : MonoBehaviour
{

    private Inventory inventory;
    public int i;

    public Sprite unSelected, selected;
    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("UIManager").GetComponent<Inventory>();
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

    public void ChangeThisRune()
    {
        if(inventory.isChangingRune == false)
        {
            this.gameObject.GetComponent<Image>().sprite = selected;

            inventory.activeRune = inventory.equippedRunes[i];
            
            inventory.isChangingRune = true;
        }
        
    }


}
