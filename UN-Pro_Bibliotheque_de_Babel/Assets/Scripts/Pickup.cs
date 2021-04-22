using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Pickup : MonoBehaviour
{
    [SerializeField] private GameObject[] runes;

    private void Start()
    {
        for (int i = 0; i < runes.Length; i++)
        {
            runes = GameObject.FindGameObjectsWithTag("Rune");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player1"))
        {
            switch (gameObject.tag)
            {
                case "Page_Vierge":
                    Inventory.Instance.AddPageVierge(1);
                    Destroy(gameObject);
                    break;

                case "Fragment":
                    Inventory.Instance.AddFragment(1);
                    Destroy(gameObject);
                    break;

                case "Hearth":
                    PlayerScript.Instance.PickedUpHeart();
                    Destroy(gameObject);
                    break;

                default:
                    break;
            }

            switch (gameObject.name)
            {
                case "Rune_Embrasement" :
                    Inventory.Instance.embrasementActive = true;
                    Inventory.Instance.rune1.GetComponent<Image>().color = Color.white;

                    foreach (var item in runes)
                    {
                        Destroy(item);
                    }
                    break;

                case "Rune_Embrasement(Clone)":
                    Inventory.Instance.embrasementActive = true;
                    Inventory.Instance.rune1.GetComponent<Image>().color = Color.white;

                    foreach (var item in runes)
                    {
                        Destroy(item);
                    }
                    break;

                case "Rune_Givre":
                    Inventory.Instance.givreActive = true;
                    Inventory.Instance.rune2.GetComponent<Image>().color = Color.white;

                    foreach (var item in runes)
                    {
                        Destroy(item);
                    }
                    break;

                case "Rune_Givre(Clone)":
                    Inventory.Instance.givreActive = true;
                    Inventory.Instance.rune2.GetComponent<Image>().color = Color.white;

                    foreach (var item in runes)
                    {
                        Destroy(item);
                    }
                    break;


                case "Rune_Amplification":
                    Inventory.Instance.amplificationActive = true;
                    Inventory.Instance.rune3.GetComponent<Image>().color = Color.white;

                    foreach (var item in runes)
                    {
                        Destroy(item);
                    }
                    break;

                case "Rune_Amplification(Clone)":
                    Inventory.Instance.amplificationActive = true;
                    Inventory.Instance.rune3.GetComponent<Image>().color = Color.white;

                    foreach (var item in runes)
                    {
                        Destroy(item);
                    }
                    break;


                default:
                    break;
            }
        }
    }
}
