using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AffichageRune : MonoBehaviour
{
    [SerializeField] private int index;
    [SerializeField] private Image runeImage;

    void Update()
    {
        if(Inventory.Instance.equippedRunes.Length >= index)
            runeImage.sprite = Inventory.Instance.equippedRunes[index].GetComponent<Image>().sprite;
    }
}
