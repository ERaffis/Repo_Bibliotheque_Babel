using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingAnimation : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        transform.LeanScale(transform.localScale * 0.9f, 0.125f);
    }
}
