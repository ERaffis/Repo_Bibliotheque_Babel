using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Testing : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            DamagePopup.Create(UtilsClass.GetMouseWorldPosition(), 100);
    }
}
