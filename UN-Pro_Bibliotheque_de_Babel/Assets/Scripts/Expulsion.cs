using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expulsion : Runes
{


    public float dashForce = 10;
    public float dashDuration = 0.1f;
    public float dashCooldown = 3.5f;
    public PlayerMovement playerMovement;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        damage = 100;
        knockback = 1;
        attackTimer = 0.3f;
     
    }

    public void RuneMaitresse()
    {
        damage = damage * 1;
        knockback = knockback * 0.5f;

       // playerMovement.PlayerDash(rb.)
        //StartCoroutine(playerScript.uiManager.UpdateDash(dashCooldown));
        print("Dash");

    }
    public void RuneSupport()
    {
        damage = damage * 0.1f;
        knockback = knockback * 1;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
