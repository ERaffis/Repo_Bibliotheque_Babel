using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneCasting : MonoBehaviour
{

    [Header("Player")]
    public PlayerScript player;

    [Header("Runes")]
    public GameObject[] availableRunes;
    public GameObject equippedRune_1, equippedRune_2, equippedRune_3, equippedRune_4;

    [Header("Bracelets")]
    public GameObject[] availableBracelets;
    public GameObject equippedBracelet;

    [Header("Combos")]
    public bool isComboing;

    // Start is called before the first frame update
    void Start()
    {
        isComboing = false;
    }

    // Update is called once per frame
    void Update()
    {
        FireRune();
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
                if(equippedRune_1 !=null)
                {
                    print("Pressed Rune 1");
                    Instantiate(equippedRune_1,gameObject.transform);
                }

                if(equippedRune_1 == null)
                {
                    print("Rune 1 not set");
                }

            }

            if (player.playerInputs.GetButtonDown("Rune 2"))
            {
                if (equippedRune_2 != null)
                {
                    print("Pressed Rune 2");
                    Instantiate(equippedRune_2);
                }

                if (equippedRune_2 == null)
                {
                    print("Rune 2 not set");
                }
            }

            if (player.playerInputs.GetButtonDown("Rune 3"))
            {
                if (equippedRune_3 != null)
                {
                    print("Pressed Rune 3");
                    Instantiate(equippedRune_3, gameObject.transform);
                }

                if (equippedRune_3 == null)
                {
                    print("Rune 3 not set");
                }
            }

            if (player.playerInputs.GetButtonDown("Rune 4"))
            {
                if (equippedRune_4 != null)
                {
                    print("Pressed Rune 4");
                    Instantiate(equippedRune_4, gameObject.transform);
                }

                if (equippedRune_4 == null)
                {
                    print("Rune 4 not set");
                }
            }
        }

        if (isComboing)
        {
            if (player.playerInputs.GetButtonDown("Rune 1"))
            {
                if (equippedRune_1 != null)
                {
                    print("Pressed Rune 1 for combo");
                    Instantiate(equippedRune_1);
                }

                if (equippedRune_1 == null)
                {
                    print("Rune 1 not set");
                }

            }

            if (player.playerInputs.GetButtonDown("Rune 2"))
            {
                if (equippedRune_2 != null)
                {
                    print("Pressed Rune 2 for combo");
                    Instantiate(equippedRune_2);
                }

                if (equippedRune_2 == null)
                {
                    print("Rune 2 not set");
                }
            }

            if (player.playerInputs.GetButtonDown("Rune 3"))
            {
                if (equippedRune_3 != null)
                {
                    print("Pressed Rune 3 for combo");
                    Instantiate(equippedRune_3);
                }

                if (equippedRune_3 == null)
                {
                    print("Rune 3 not set");
                }
            }

            if (player.playerInputs.GetButtonDown("Rune 4"))
            {
                if (equippedRune_4 != null)
                {
                    print("Pressed Rune 4 for combo");
                    Instantiate(equippedRune_4);
                }

                if (equippedRune_4 == null)
                {
                    print("Rune 4 not set");
                }
            }
        }

        if (player.playerInputs.GetButtonUp("Combo"))
        {
            print("Combo Launched");
            isComboing = false;
        }
    }
}
