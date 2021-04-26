using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


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
        if (collision.CompareTag("HalfCollider"))
        {
            switch (gameObject.tag) 
            {
                case "Page_Vierge":
                    Inventory.Instance.AddPageVierge(1);
                    SoundManager.PlaySound(SoundManager.Sound.ItemPickedUp, transform.position);

                    Destroy(gameObject);
                    break;

                case "Fragment":
                    Inventory.Instance.AddFragment(1);
                    SoundManager.PlaySound(SoundManager.Sound.ItemPickedUp, transform.position);

                    Destroy(gameObject);
                    if (SceneManager.GetActiveScene().name == "HUB_Didacticiel")
                    {
                        GameObject.Find("ScriptDidacticiel").GetComponent<Didacticiel>().howToDash.SetActive(false);
                        GameObject.Find("ScriptDidacticiel").GetComponent<Didacticiel>().fragment.SetActive(true);
                        GameObject.Find("ScriptDidacticiel").GetComponent<Didacticiel>().manuscritPopUp.SetActive(true);
                        GameObject.Find("ScriptDidacticiel").GetComponent<Didacticiel>().instantiateManuscrit = true;
                        ArrowPointer.Instance.targetPosition = GameObject.Find("ScriptDidacticiel").GetComponent<Didacticiel>().exitDir;
                    }
                    break;

                case "Hearth":
                    PlayerScript.Instance.PickedUpHeart();
                    SoundManager.PlaySound(SoundManager.Sound.ItemPickedUp, transform.position);

                    Destroy(gameObject);
                    break;

                default:
                    break;
            }

            switch (gameObject.name)
            {
                case "Rune_Embrasement" :
                    if (!Inventory.Instance.embrasementActive)
                    {
                        Inventory.Instance.embrasementActive = true;
                        Inventory.Instance.rune1.GetComponent<Image>().color = Color.white;
                    } else
                    {
                        Inventory.Instance.runes[0].lvlRune++;

                    }
                    SoundManager.PlaySound(SoundManager.Sound.ItemPickedUp, transform.position);

                    Destroy(gameObject);

                    break;

                case "Rune_Embrasement(Clone)":
                    
                    if(Inventory.Instance.nmbPageVierge > 5)
                    {
                        Inventory.Instance.runes[0].lvlRune++;
                        SoundManager.PlaySound(SoundManager.Sound.ItemPickedUp, transform.position);


                        Destroy(gameObject);
                    }
                            
                    
                    
                    break;

                case "Rune_Givre":
                    if (!Inventory.Instance.givreActive)
                    {
                        Inventory.Instance.givreActive = true;
                        Inventory.Instance.rune2.GetComponent<Image>().color = Color.white;
                    }
                    else
                    {
                        Inventory.Instance.runes[1].lvlRune++;
                    }
                    SoundManager.PlaySound(SoundManager.Sound.ItemPickedUp, transform.position);

                    Destroy(gameObject);

                    break;

                case "Rune_Givre(Clone)":

                    if (Inventory.Instance.nmbPageVierge > 5)
                    {
                        Inventory.Instance.runes[2].lvlRune++;
                        SoundManager.PlaySound(SoundManager.Sound.ItemPickedUp, transform.position);


                        Destroy(gameObject);
                    }

                    break;


                case "Rune_Amplification":
                    if (!Inventory.Instance.amplificationActive)
                    {
                        Inventory.Instance.amplificationActive = true;
                        Inventory.Instance.rune3.GetComponent<Image>().color = Color.white;
                    }
                    else
                    {
                        Inventory.Instance.runes[2].lvlRune++;
                    }
                    SoundManager.PlaySound(SoundManager.Sound.ItemPickedUp, transform.position);

                    Destroy(gameObject);

                    break;

                case "Rune_Amplification(Clone)":

                    if (Inventory.Instance.nmbPageVierge > 5)
                    {
                        Inventory.Instance.runes[3].lvlRune++;
                        SoundManager.PlaySound(SoundManager.Sound.ItemPickedUp, transform.position);


                        Destroy(gameObject);
                    }

                    break;


                default:
                    break;
            }

        }
    }
}
