using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RuneCasting : MonoBehaviour
{

    [Header("Player")]
    public PlayerScript player;

    [Header("UI")]
    public Image equippedRune_1;
    public Image equippedRune_2;
    public Image equippedRune_3;
    public Image equippedRune_4;

    public bool coolDown1;
    public bool coolDown2;
    public bool coolDown3;
    public bool coolDown4;

    [Header("Runes")]
    public GameObject[] equippedRune;

    [Header("Bracelets")]
    public GameObject[] availableBracelets;
    public GameObject equippedBracelet;

    [Header("Combos")]
    public bool isComboing;
    public bool rune1, rune2, rune3, rune4;

    public List<GameObject> comboRune;


    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        isComboing = false;
        rune1 = true;
        rune2 = true;
        rune3 = true;
        rune4 = true;

        coolDown1 = true;
        coolDown2 = true;
        coolDown3 = true;
        coolDown4 = true;

        if (comboRune == null) comboRune = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        FireRune();
    }

    IEnumerator HighlightRune(Image img, int coolD)
    {
        img.color = Color.gray;

        switch (coolD)
        {
            case 1:
                coolDown1 = false;
                break;
            case 2:
                coolDown2 = false;
                break;
            case 3:
                coolDown3 = false;
                break;
            case 4:
                coolDown4 = false;
                break;
        }

        yield return new WaitForSeconds(.5f);
        
        img.color = Color.white;


        switch (coolD)
        {
            case 1:
                coolDown1 = true;
                break;
            case 2:
                coolDown2 = true;
                break;
            case 3:
                coolDown3 = true;
                break;
            case 4:
                coolDown4 = true;
                break;
        }
    }

    private void FireRune()
    {
        if (player.playerInputs.GetButtonDown("Combo"))
        {
            print("Combo Started");
            isComboing = true;
        }

        if(!isComboing)
        {
            if (player.playerInputs.GetButtonDown("Rune 1"))
            {
                if(equippedRune[0] !=null && coolDown1)
                {
                    print("Pressed Rune 1");

                    StartCoroutine(HighlightRune(equippedRune_1, 1));

                    if (equippedRune[0].TryGetComponent(out Embrasement a))
                    {
                        equippedRune[0].GetComponent<Embrasement>().RuneMaitresse();
                    }
                    if (equippedRune[0].TryGetComponent(out Empalement b))
                    {
                        equippedRune[0].GetComponent<Empalement>().RuneMaitresse();
                    }
                    if (equippedRune[0].TryGetComponent(out Expulsion c))
                    {
                        equippedRune[0].GetComponent<Expulsion>().RuneMaitresse();
                    }



                }

                if(equippedRune[0] == null)
                {
                    print("Rune 1 not set");
                }

            }

            if (player.playerInputs.GetButtonDown("Rune 2"))
            {
                if (equippedRune[1] != null && coolDown2)
                {
                    print("Pressed Rune 2");

                    StartCoroutine(HighlightRune(equippedRune_2, 2));

                    if (equippedRune[1].TryGetComponent(out Embrasement a))
                    {
                        equippedRune[1].GetComponent<Embrasement>().RuneMaitresse();
                    }
                    if (equippedRune[1].TryGetComponent(out Empalement b))
                    {
                        equippedRune[1].GetComponent<Empalement>().RuneMaitresse();
                    }
                    if (equippedRune[1].TryGetComponent(out Expulsion c))
                    {
                        equippedRune[1].GetComponent<Expulsion>().RuneMaitresse();
                    }
                }

                if (equippedRune[1] == null)
                {
                    print("Rune 2 not set");
                }
            }

            if (player.playerInputs.GetButtonDown("Rune 3"))
            {
                if (equippedRune[2] != null && coolDown3)
                {

                    StartCoroutine(HighlightRune(equippedRune_3, 3));

                    if (equippedRune[2].TryGetComponent(out Embrasement a))
                    {
                        equippedRune[2].GetComponent<Embrasement>().RuneMaitresse();
                    }
                    if (equippedRune[2].TryGetComponent(out Empalement b))
                    {
                        equippedRune[2].GetComponent<Empalement>().RuneMaitresse();
                    }
                    if (equippedRune[2].TryGetComponent(out Expulsion c))
                    {
                        equippedRune[2].GetComponent<Expulsion>().RuneMaitresse();
                    }
                }

                if (equippedRune[2] == null)
                {
                    print("Rune 3 not set");
                }
            }

            if (player.playerInputs.GetButtonDown("Rune 4"))
            {
                if (equippedRune[3] != null && coolDown4)
                {

                    StartCoroutine(HighlightRune(equippedRune_4, 4));

                    if (equippedRune[3].TryGetComponent(out Embrasement a))
                    {
                        equippedRune[3].GetComponent<Embrasement>().RuneMaitresse();
                    }
                    if (equippedRune[3].TryGetComponent(out Empalement b))
                    {
                        equippedRune[3].GetComponent<Empalement>().RuneMaitresse();
                    }
                    if (equippedRune[3].TryGetComponent(out Expulsion c))
                    {
                        equippedRune[3].GetComponent<Expulsion>().RuneMaitresse();
                    }
                }

                if (equippedRune[3] == null)
                {
                    print("Rune 4 not set");
                }
            }
        }

        if (isComboing)
        {
            if (player.playerInputs.GetButtonDown("Rune 1") && rune1)
            {
                if (equippedRune[0] != null)
                {
                    print("Pressed Rune 1 for combo");
                    comboRune.Add(equippedRune[0]);
                    rune1 = false;
                    equippedRune_1.color = Color.gray;
                }

                if (equippedRune[0] == null)
                {
                    print("Rune 1 not set");
                }

            }

            if (player.playerInputs.GetButtonDown("Rune 2") && rune2)
            {
                if (equippedRune[1] != null)
                {
                    print("Pressed Rune 2 for combo");
                    comboRune.Add(equippedRune[1]);
                    rune2 = false;
                    equippedRune_2.color = Color.gray;
                }

                if (equippedRune[1] == null)
                {
                    print("Rune 2 not set");
                }
            }

            if (player.playerInputs.GetButtonDown("Rune 3") && rune3)
            {
                if (equippedRune[2] != null)
                {
                    print("Pressed Rune 3 for combo");
                    comboRune.Add(equippedRune[2]);
                    rune3 = false;
                    equippedRune_3.color = Color.gray;

                }

                if (equippedRune[2] == null)
                {
                    print("Rune 3 not set");
                }
            }

            if (player.playerInputs.GetButtonDown("Rune 4") && rune4)
            {
                if (equippedRune[3] != null)
                {
                    print("Pressed Rune 4 for combo");
                    comboRune.Add(equippedRune[3]);
                    rune4 = false;
                    equippedRune_4.color = Color.gray;

                }

                if (equippedRune[3] == null)
                {
                    print("Rune 4 not set");
                }
            }
        }

        if (player.playerInputs.GetButtonUp("Combo"))
        {
            rune1 = true;
            rune2 = true;
            rune3 = true;
            rune4 = true;

            equippedRune_1.color = Color.white;
            equippedRune_2.color = Color.white;
            equippedRune_3.color = Color.white;
            equippedRune_4.color = Color.white;

            print("Combo Launched");

            if (comboRune.Count == 1)
            {

                if (comboRune[0].TryGetComponent(out Embrasement a))
                {
                    comboRune[0].GetComponent<Embrasement>().RuneMaitresse();
                }
                if (comboRune[0].TryGetComponent(out Empalement b))
                {
                    comboRune[0].GetComponent<Empalement>().RuneMaitresse();
                }
                if (comboRune[0].TryGetComponent(out Expulsion c))
                {
                    comboRune[0].GetComponent<Expulsion>().RuneMaitresse();
                }

            }

            if (comboRune.Count == 2)
            {

                if (comboRune[0].TryGetComponent(out Embrasement a))
                {
                    comboRune[0].GetComponent<Embrasement>().RuneMaitresse(comboRune[1]);
                }
                if (comboRune[0].TryGetComponent(out Empalement b))
                {
                    comboRune[0].GetComponent<Empalement>().RuneMaitresse(comboRune[1]);
                }
                if (comboRune[0].TryGetComponent(out Expulsion c))
                {
                    comboRune[0].GetComponent<Expulsion>().RuneMaitresse(comboRune[1]);
                }
                
            }
            if (comboRune.Count == 3) 
            {
                if (comboRune[0].TryGetComponent(out Embrasement a))
                {
                    comboRune[0].GetComponent<Embrasement>().RuneMaitresse(comboRune[1], comboRune[2]);
                }
                if (comboRune[0].TryGetComponent(out Empalement b))
                {
                    comboRune[0].GetComponent<Empalement>().RuneMaitresse(comboRune[1], comboRune[2]);
                }
                if (comboRune[0].TryGetComponent(out Expulsion c))
                {
                    comboRune[0].GetComponent<Expulsion>().RuneMaitresse(comboRune[1], comboRune[2]);
                }
            }

            if (comboRune.Count == 4) 
            {
                if (comboRune[0].TryGetComponent(out Embrasement a))
                {
                    comboRune[0].GetComponent<Embrasement>().RuneMaitresse(comboRune[1], comboRune[2], comboRune[3]);
                }
                if (comboRune[0].TryGetComponent(out Empalement b))
                {
                    comboRune[0].GetComponent<Empalement>().RuneMaitresse(comboRune[1], comboRune[2], comboRune[3]);
                }
                if (comboRune[0].TryGetComponent(out Expulsion c))
                {
                    comboRune[0].GetComponent<Expulsion>().RuneMaitresse(comboRune[1], comboRune[2], comboRune[3]);
                }
            }



            isComboing = false;
            comboRune.Clear();
            
        }
    }
}
