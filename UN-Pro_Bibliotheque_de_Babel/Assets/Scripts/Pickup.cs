using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player1"))
        {
            switch (this.gameObject.tag)
            {
                case "Page_Vierge":
                    Inventory.Instance.AddPageVierge(1);
                    break;

                case "Fragment":
                    Inventory.Instance.AddFragment(1);
                    break;

                case "Hearth":
                    PlayerScript.Instance.PickedUpHeart();
                    break;

                default:
                    break;
            }

            Destroy(this.gameObject);

            /*
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if(inventory.isFull[i] == false)
                {
                    // ADD ITEM
                    inventory.isFull[i] = true;
                    Instantiate(itemButton, inventory.slots[i].transform, false);
                    Destroy(this.gameObject);
                    break;
                }
            }
            */
        }
    }
}
