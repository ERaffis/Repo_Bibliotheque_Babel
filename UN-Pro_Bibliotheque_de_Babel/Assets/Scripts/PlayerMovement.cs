using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Rewired;


public class PlayerMovement : MonoBehaviour
{
    

    [Header("Player Components")]
    public PlayerScript playerScript;

    [Space]
    public float comboModifier;

    [Header("Dash Values")]
    public float dashForce = 10;
    public float dashDuration = 0.1f;
    public float dashCooldown = 3.5f;
    public bool canDash = true;
    public bool isDashing = false;

    private float moveHorizontal;
    private float moveVertical ;
    private Vector2 moveDirection;
    private int moveAngle;


    private void Start() {

        
        playerScript = GetComponent<PlayerScript>();

        playerScript.rb.gravityScale = 0;

        comboModifier = 1f;
    }
    
    private void Update() {
        
    }

    private void FixedUpdate() {

        
        
        GetAxies();

        FindAngle();
        if(playerScript.canMove) MovePlayer();

        
    }

    private void GetAxies() {

        // Mouvement sans délais
        moveHorizontal = playerScript.playerInputs.GetAxisRaw("Move Horizontal");
        moveVertical = playerScript.playerInputs.GetAxisRaw("Move Vertical");
        
    }

    private void MovePlayer(){
        
        if(GameObject.Find("RuneManager").GetComponent<RuneCasting>().isComboing)
        {   
            //Vitesse Reduite
            comboModifier = .5f;

            //Vitesse Nulle
            //comboModifier = 0f;
            
        } else
        {
            comboModifier = 1f;
        }



        if(moveDirection != Vector2.zero) {

            //SoundManager.PlaySound(SoundManager.Sound.PlayerMove, GetPosition());

            //Move Right
            if (moveAngle >= -25 & moveAngle <= 25)
            {
                Vector2 dir = Vector2.right;
                playerScript.rb.velocity = dir * playerScript.moveSpeed * comboModifier;
                playerScript.animator.SetInteger("Index", 1);
                playerScript._GameHandler.ChangeRuneDir(0);
            }

            //Move Left
            if (moveAngle >= 155 || moveAngle <= -155)
            {
                Vector2 dir = Vector2.left;
                playerScript.rb.velocity = dir * playerScript.moveSpeed * comboModifier;
                playerScript.animator.SetInteger("Index", 2);
                playerScript._GameHandler.ChangeRuneDir(4);
            }

            //Move Up
            if (moveAngle >= 65 & moveAngle <= 115)
            {
                Vector2 dir = Vector2.up;
                playerScript.rb.velocity = dir * playerScript.moveSpeed * comboModifier;
                playerScript.animator.SetInteger("Index", 3);
                playerScript._GameHandler.ChangeRuneDir(2);
            }

            //Move Up_Right
            if (moveAngle > 25 & moveAngle < 65) 
            {
                Vector2 dir = new Vector2(.75f, .75f);
                playerScript.rb.velocity = dir * playerScript.moveSpeed * comboModifier;
                playerScript.animator.SetInteger("Index", 3);
                playerScript._GameHandler.ChangeRuneDir(1);
            }

            //Move Up_Left
            if (moveAngle > 115 & moveAngle < 155) 
            {
                Vector2 dir = new Vector2(-.75f, .75f);
                playerScript.rb.velocity = dir * playerScript.moveSpeed * comboModifier;
                playerScript.animator.SetInteger("Index", 3);
                playerScript._GameHandler.ChangeRuneDir(3);
            }

            //Move Down
            if (moveAngle >= -115 & moveAngle <= -65)
            {
                Vector2 dir = Vector2.down;
                playerScript.rb.velocity = dir * playerScript.moveSpeed * comboModifier;
                playerScript.animator.SetInteger("Index", 4);
                playerScript._GameHandler.ChangeRuneDir(6);
            }

            //Move Down_Left
            if (moveAngle > -155 & moveAngle < -115) 
            {
                Vector2 dir = new Vector2(-.75f, -.75f);
                playerScript.rb.velocity = dir * playerScript.moveSpeed * comboModifier;
                playerScript.animator.SetInteger("Index", 4);
                playerScript._GameHandler.ChangeRuneDir(5);
            }

            //Move Down_Right
            if (moveAngle > -65 & moveAngle < -25) 
            {
                Vector2 dir = new Vector2(.75f, -.75f);
                playerScript.rb.velocity = dir * playerScript.moveSpeed * comboModifier;
                playerScript.animator.SetInteger("Index", 4);
                playerScript._GameHandler.ChangeRuneDir(7);
            }

        }

        if (moveDirection == Vector2.zero)
        {
            playerScript.rb.velocity = Vector2.zero;
            playerScript.animator.SetInteger("Index", 0);
            playerScript._GameHandler.ChangeRuneDir(0);
        }
    }

    private void FindAngle(){
        moveDirection = new Vector2(moveHorizontal, moveVertical);

        moveAngle = (int) Vector2.Angle(moveDirection, Vector2.right);
        if (moveVertical < 0)
        {
            moveAngle *= -1;
        }  
    }

    public Vector3 GetPosition()
    {
        return this.gameObject.transform.position;
    }

    //private void Playerdash(Vector2 direction)
    //{
    //    playerScript.rb.AddForce(direction * dashForce, ForceMode2D.Impulse);
    //    StartCoroutine(playerScript._GameHandler.uiManager.UpdateDash(dashCooldown));
    //    StartCoroutine(WaitForDash());
    //    print("dash");
    //}

    //private IEnumerator WaitForDash()
    //{
    //    isDashing = true;
    //    playerScript.animator.SetBool("IsDashing", isDashing);

    //    yield return new WaitForSeconds(dashDuration);

    //    isDashing = false;
    //    playerScript.animator.SetBool("IsDashing", isDashing);

    //    canDash = false;
    //    yield return new WaitForSeconds(dashCooldown);
    //    canDash = true;
    //}
}
