using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManuscritInteract : MonoBehaviour
{
    public GameObject ManuscritMenu;
    public GameObject TextManuscrit;
    public bool CanInteract;
    

    private void Start()
    {
        CanInteract = false;
        
    }

    void OnTriggerEnter2D (Collider2D collision)
    {
        if(collision.gameObject.tag == "Player1")
        {
            TextManuscrit.SetActive(true);
            CanInteract = true;

        }

    }
   
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player1")
        {
            TextManuscrit.SetActive(false);
            CanInteract = false;
        }
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L) && CanInteract)
        {
            ManuscritMenu.SetActive(true);
           
        }
    }
}
