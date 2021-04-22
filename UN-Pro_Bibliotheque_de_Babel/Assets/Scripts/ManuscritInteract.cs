using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ManuscritInteract : MonoBehaviour
{

    public PlayerScript player;
    public GameObject ManuscritMenu;
    public GameObject TextManuscrit;
    public GameObject mainUI;
    public bool CanInteract;
    public bool isActive;
    public GameObject openFirstButton;
    public Animator animator;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player1").GetComponent<PlayerScript>();
        mainUI  = GameObject.FindGameObjectWithTag("MainUI");
        CanInteract = false;
        isActive = false;


    }

    void OnTriggerEnter2D (Collider2D collision)
    {
        if(collision.gameObject.layer == 14)
        {
            TextManuscrit.SetActive(true);
            CanInteract = true;
            StartCoroutine(PlayOpenAnimation());

        }

    }
   
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 14)
        {
            TextManuscrit.SetActive(false);
            CanInteract = false;
            StartCoroutine(PlayCloseAnimation());
        }

    }

    void Update()
    {
        if (PlayerScript.Instance.playerInputs.GetButtonDown("Interact") && CanInteract)
        {
            OpenCloseMenu();
        }
    }

    public void OpenCloseMenu()
    {
        isActive = !isActive;

        if (isActive)
        {
            Time.timeScale = 0;

            player.playerInputs.controllers.maps.SetMapsEnabled(false, "In Game");
            player.playerInputs.controllers.maps.SetMapsEnabled(true, "In Menu");

            mainUI.SetActive(false);
            StartCoroutine(SelectFirstButton());
        }
        else
        {
            Time.timeScale = 1;

            player.playerInputs.controllers.maps.SetMapsEnabled(false, "In Menu");
            player.playerInputs.controllers.maps.SetMapsEnabled(true, "In Game");

            mainUI.SetActive(true);
        }

        ManuscritMenu.SetActive(isActive);
    }

    IEnumerator SelectFirstButton()
    {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(openFirstButton);
    }

    IEnumerator PlayCloseAnimation()
    {
        yield return new WaitForEndOfFrame();
        animator.Play("CloseAnimation");
    }
    IEnumerator PlayOpenAnimation()
    {
        yield return new WaitForEndOfFrame();
        animator.Play("OpenAnimation");
    }
}
