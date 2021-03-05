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

        if (comboRune == null) comboRune = new List<GameObject>();
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

                    if (equippedRune_1.TryGetComponent(out Embrasement a))
                    {
                        equippedRune_1.GetComponent<Embrasement>().RuneMaitresse();
                    }
                    if (equippedRune_1.TryGetComponent(out Empalement b))
                    {
                        equippedRune_1.GetComponent<Empalement>().RuneMaitresse();
                    }
                    if (equippedRune_1.TryGetComponent(out Expulsion c))
                    {
                        equippedRune_1.GetComponent<Expulsion>().RuneMaitresse();
                    }



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
                    if (equippedRune_2.TryGetComponent(out Embrasement a))
                    {
                        equippedRune_2.GetComponent<Embrasement>().RuneMaitresse();
                    }
                    if (equippedRune_2.TryGetComponent(out Empalement b))
                    {
                        equippedRune_2.GetComponent<Empalement>().RuneMaitresse();
                    }
                    if (equippedRune_2.TryGetComponent(out Expulsion c))
                    {
                        equippedRune_2.GetComponent<Expulsion>().RuneMaitresse();
                    }
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
                    if (equippedRune_3.TryGetComponent(out Embrasement a))
                    {
                        equippedRune_3.GetComponent<Embrasement>().RuneMaitresse();
                    }
                    if (equippedRune_3.TryGetComponent(out Empalement b))
                    {
                        equippedRune_3.GetComponent<Empalement>().RuneMaitresse();
                    }
                    if (equippedRune_3.TryGetComponent(out Expulsion c))
                    {
                        equippedRune_3.GetComponent<Expulsion>().RuneMaitresse();
                    }
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
                    if (equippedRune_4.TryGetComponent(out Embrasement a))
                    {
                        equippedRune_4.GetComponent<Embrasement>().RuneMaitresse();
                    }
                    if (equippedRune_4.TryGetComponent(out Empalement b))
                    {
                        equippedRune_4.GetComponent<Empalement>().RuneMaitresse();
                    }
                    if (equippedRune_4.TryGetComponent(out Expulsion c))
                    {
                        equippedRune_4.GetComponent<Expulsion>().RuneMaitresse();
                    }
                }

                if (equippedRune_4 == null)
                {
                    print("Rune 4 not set");
                }
            }
        }

        if (isComboing)
        {
            if (player.playerInputs.GetButtonDown("Rune 1") && rune1)
            {
                if (equippedRune_1 != null)
                {
                    print("Pressed Rune 1 for combo");
                    comboRune.Add(equippedRune_1);
                    rune1 = false;
                }

                if (equippedRune_1 == null)
                {
                    print("Rune 1 not set");
                }

            }

            if (player.playerInputs.GetButtonDown("Rune 2") && rune2)
            {
                if (equippedRune_2 != null)
                {
                    print("Pressed Rune 2 for combo");
                    comboRune.Add(equippedRune_2);
                    rune2 = false;
                }

                if (equippedRune_2 == null)
                {
                    print("Rune 2 not set");
                }
            }

            if (player.playerInputs.GetButtonDown("Rune 3") && rune3)
            {
                if (equippedRune_3 != null)
                {
                    print("Pressed Rune 3 for combo");
                    comboRune.Add(equippedRune_3);
                    rune3 = false;
                }

                if (equippedRune_3 == null)
                {
                    print("Rune 3 not set");
                }
            }

            if (player.playerInputs.GetButtonDown("Rune 4") && rune4)
            {
                if (equippedRune_4 != null)
                {
                    print("Pressed Rune 4 for combo");
                    comboRune.Add(equippedRune_4);
                    rune4 = false;
                }

                if (equippedRune_4 == null)
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

            print("Combo Launched");

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
