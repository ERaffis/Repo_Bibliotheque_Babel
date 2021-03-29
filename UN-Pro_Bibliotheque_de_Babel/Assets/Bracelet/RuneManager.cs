using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneManager : MonoBehaviour
{
    [Header("Equipped Bracelet")]
    public Bracelet equippedBracelet;

    [Header("Combo")]
    public bool isComboing;
    public int nmbPressed;
    public bool pressed0, pressed1, pressed2, pressed3;
    public List<Runes> orderRune = new List<Runes>();

    private void Start()
    {
        isComboing = false;
        pressed0 = false;
        pressed1 = false;
        pressed2 = false;
        pressed3 = false;
        nmbPressed = 0;
    }
    private void Update()
    {
        equippedBracelet = Inventory.Instance.activeBracelet;
        CheckCombo();
        ShootRune();
    }

    private void ShootRune()
    {
        if (!isComboing) SingleRune();
        if (isComboing) ComboRune();
    }

    private void CheckCombo()
    {
        if (PlayerScript.Instance.playerInputs.GetButtonDown("Combo"))
            isComboing = true;
    }

    private void SingleRune()
    {
        if (equippedBracelet != null)
        { 
            if (PlayerScript.Instance.playerInputs.GetButtonDown("Rune 1"))
                if (equippedBracelet.activeRunes[0] != null)
                    equippedBracelet.ProjectileSolo(equippedBracelet.name, equippedBracelet.activeRunes[0]);
            if (PlayerScript.Instance.playerInputs.GetButtonDown("Rune 2"))
                if (equippedBracelet.activeRunes[1] != null)
                    equippedBracelet.ProjectileSolo(equippedBracelet.name, equippedBracelet.activeRunes[1]);
            if (PlayerScript.Instance.playerInputs.GetButtonDown("Rune 3"))
                if (equippedBracelet.activeRunes[2] != null)
                    equippedBracelet.ProjectileSolo(equippedBracelet.name, equippedBracelet.activeRunes[2]);
            if (PlayerScript.Instance.playerInputs.GetButtonDown("Rune 4"))
                if (equippedBracelet.activeRunes[3] != null)
                    equippedBracelet.ProjectileSolo(equippedBracelet.name, equippedBracelet.activeRunes[3]);
        }
    }

    private void ComboRune()
    {
        if (equippedBracelet != null)
        {
            if (PlayerScript.Instance.playerInputs.GetButtonDown("Rune 1"))
            {
                if (equippedBracelet.activeRunes[0] != null && !pressed0 && nmbPressed < equippedBracelet.nmbRune)
                {
                    pressed0 = true;
                    orderRune.Add(equippedBracelet.activeRunes[0]);
                    nmbPressed++;
                }
            }
            if (PlayerScript.Instance.playerInputs.GetButtonDown("Rune 2"))
            {
                if (equippedBracelet.activeRunes[1] != null && !pressed1 && nmbPressed < equippedBracelet.nmbRune)
                {
                    pressed1 = true;
                    orderRune.Add(equippedBracelet.activeRunes[1]);
                    nmbPressed++;
                }
            }
            if (PlayerScript.Instance.playerInputs.GetButtonDown("Rune 3"))
            {
                if (equippedBracelet.activeRunes[2] != null && !pressed2 && nmbPressed < equippedBracelet.nmbRune)
                {
                    pressed2 = true;
                    orderRune.Add(equippedBracelet.activeRunes[2]);
                    nmbPressed++;
                }
            }
            if (PlayerScript.Instance.playerInputs.GetButtonDown("Rune 4"))
            {
                if (equippedBracelet.activeRunes[3] != null && !pressed3 && nmbPressed < equippedBracelet.nmbRune)
                {
                    pressed3 = true;
                    orderRune.Add(equippedBracelet.activeRunes[3]);
                    nmbPressed++;
                }
            }
        }

        if (PlayerScript.Instance.playerInputs.GetButtonUp("Combo"))
            LaunchCombo();
    }

    private void LaunchCombo()
    {
        switch (nmbPressed)
        {
            case 1:
                equippedBracelet.ProjectileCombo(equippedBracelet.name, orderRune[0]);
                break;

            case 2:
                equippedBracelet.ProjectileCombo(equippedBracelet.name, orderRune[0], orderRune[1]);
                break;

            case 3:
                equippedBracelet.ProjectileCombo(equippedBracelet.name, orderRune[0], orderRune[1], orderRune[2]);
                break;

            case 4:
                equippedBracelet.ProjectileCombo(equippedBracelet.name, orderRune[0], orderRune[1], orderRune[2], orderRune[3]);
                break;

            default:
                break;
        }

        //Clear Stuff for combo
        nmbPressed = 0;
        orderRune.Clear();
        pressed0 = false;
        pressed1 = false;
        pressed2 = false;
        pressed3 = false;
        isComboing = false;
    }
}
