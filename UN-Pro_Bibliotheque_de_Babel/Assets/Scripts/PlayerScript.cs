using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : Entities
{
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer.sprite = activeSprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
