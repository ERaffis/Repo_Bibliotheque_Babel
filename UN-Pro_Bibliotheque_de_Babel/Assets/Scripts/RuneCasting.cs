using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneCasting : MonoBehaviour
{

    [Header("Player")]
    public PlayerScript player;

    [Header("Runes")]
    public Runes[] availableRunes;
    public Runes equippedRune_1, equippedRune_2, equippedRune_3, equippedRune_4;

    [Header("Bracelets")]
    public Bracelet[] availableBracelets;
    public Bracelet equippedBracelet;

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

        if (player.playerInputs.GetButtonDown("Rune 1") && !isComboing)
        {
            print("Pressed X");
        }

        if (player.playerInputs.GetButtonDown("Rune 1") && isComboing)
        {
            print("Pressed X for combo");
        }

        if (player.playerInputs.GetButtonDown("Rune 2") && !isComboing)
        {
            print("Pressed Square");
        }

        if (player.playerInputs.GetButtonDown("Rune 2") && isComboing)
        {
            print("Pressed Square for combo");
        }

        if (player.playerInputs.GetButtonDown("Rune 3") && !isComboing)
        {
            print("Pressed Circle");
        }

        if (player.playerInputs.GetButtonDown("Rune 3") && isComboing)
        {
            print("Pressed Circle for combo");
        }

        if (player.playerInputs.GetButtonDown("Rune 4") && !isComboing)
        {
            print("Pressed Triangle");
        }

        if (player.playerInputs.GetButtonDown("Rune 4") && isComboing)
        {
            print("Pressed Triangle for combo");
        }

        if (player.playerInputs.GetButtonUp("Combo"))
        {
            print("Combo Launched");
            isComboing = false;
        }
    }
}
