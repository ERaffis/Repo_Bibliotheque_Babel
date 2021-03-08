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

    private float aimHorizontal;
    private float aimVertical;
    private Vector2 aimDirection;
    private int aimAngle;

    



    private void Start() 
    {

        playerScript = GetComponent<PlayerScript>();

        playerScript.rb.gravityScale = 0;

        comboModifier = 1f;
    }
    
    private void Update() 
    {
        CheckCombo();

        GetMoveAxies();
        GetAimAxies();
        FindMoveAngle();
        FindAimAngle();
        
        if (playerScript.canMove) MovePlayer();
        AimPlayer();

    }

    private void FixedUpdate() 
    {
    
    }

    private void GetMoveAxies() {

        // Mouvement sans délais
        moveHorizontal = playerScript.playerInputs.GetAxisRaw("Move Horizontal");
        moveVertical = playerScript.playerInputs.GetAxisRaw("Move Vertical");       
    }

    private void GetAimAxies()
    {
        // Mouvement sans délais
        aimHorizontal = playerScript.playerInputs.GetAxisRaw("Aim Horizontal");
        aimVertical = playerScript.playerInputs.GetAxisRaw("Aim Vertical");
    }

    private void AimPlayer()
    {
        //Aim Right
        if (aimAngle >= -25 & aimAngle <= 25 && aimAngle != 0)
        {
            playerScript._GameHandler.ChangeRuneDir(0);
            playerScript.animator.SetInteger("Index", 1);
        }
        //Aim Left
        else if (aimAngle >= 155 || aimAngle <= -155)
        {
            playerScript._GameHandler.ChangeRuneDir(4);
            playerScript.animator.SetInteger("Index", 2);
        }
        //Aim Up
        else if (aimAngle >= 65 & aimAngle <= 115)
        {
            playerScript.animator.SetInteger("Index", 3);
            playerScript._GameHandler.ChangeRuneDir(2);
        }
        //Aim UpRight
        else if (aimAngle > 25 & aimAngle < 65)
        {
            playerScript.animator.SetInteger("Index", 3);
            playerScript._GameHandler.ChangeRuneDir(1);
        }
        //Aim UpLeft
        else if (aimAngle > 115 & aimAngle < 155)
        {
            playerScript.animator.SetInteger("Index", 3);
            playerScript._GameHandler.ChangeRuneDir(3);
        }
        //Aim Down
        else if (aimAngle >= -115 & aimAngle <= -65)
        {
            playerScript.animator.SetInteger("Index", 4);
            playerScript._GameHandler.ChangeRuneDir(6);
        }
        //Aim DownLeft
        else if (aimAngle > -155 & aimAngle < -115)
        {
            playerScript.animator.SetInteger("Index", 4);
            playerScript._GameHandler.ChangeRuneDir(5);
        }
        //Aim DownRight
        else if (aimAngle > -65 & aimAngle < -25)
        {
            playerScript.animator.SetInteger("Index", 4);
            playerScript._GameHandler.ChangeRuneDir(7);
        }

    }

    private void MovePlayer(){

        if(moveDirection != Vector2.zero) {

            //Move Right
            if (moveAngle >= -25 & moveAngle <= 25)
            {
                Vector2 dir = Vector2.right;
                playerScript._GameHandler.ChangeRuneDir(0);
                playerScript.animator.SetInteger("Index", 1);
                playerScript.rb.velocity = dir * playerScript.moveSpeed * comboModifier;
            }

            //Move Left
            else if (moveAngle >= 155 || moveAngle <= -155)
            {
                Vector2 dir = Vector2.left;
                playerScript._GameHandler.ChangeRuneDir(4);
                playerScript.animator.SetInteger("Index", 2);
                playerScript.rb.velocity = dir * playerScript.moveSpeed * comboModifier;
            }

            //Move Up
            else if (moveAngle >= 65 & moveAngle <= 115)
            {
                Vector2 dir = Vector2.up;
                playerScript.animator.SetInteger("Index", 3);
                playerScript._GameHandler.ChangeRuneDir(2);
                playerScript.rb.velocity = dir * playerScript.moveSpeed * comboModifier;
            }

            //Move Up_Right
            else if (moveAngle > 25 & moveAngle < 65) 
            {
                Vector2 dir = new Vector2(.75f, .75f);
                playerScript.animator.SetInteger("Index", 3);
                playerScript._GameHandler.ChangeRuneDir(1);
                playerScript.rb.velocity = dir * playerScript.moveSpeed * comboModifier;
            }

            //Move Up_Left
            else if (moveAngle > 115 & moveAngle < 155) 
            {
                Vector2 dir = new Vector2(-.75f, .75f);
                playerScript.animator.SetInteger("Index", 3);
                playerScript._GameHandler.ChangeRuneDir(3);
                playerScript.rb.velocity = dir * playerScript.moveSpeed * comboModifier;
            }

            //Move Down
            else if (moveAngle >= -115 & moveAngle <= -65)
            {
                Vector2 dir = Vector2.down;
                playerScript.animator.SetInteger("Index", 4);
                playerScript._GameHandler.ChangeRuneDir(6);
                playerScript.rb.velocity = dir * playerScript.moveSpeed * comboModifier;
            }

            //Move Down_Left
            else if (moveAngle > -155 & moveAngle < -115) 
            {
                Vector2 dir = new Vector2(-.75f, -.75f);
                playerScript.animator.SetInteger("Index", 4);
                playerScript._GameHandler.ChangeRuneDir(5);
                playerScript.rb.velocity = dir * playerScript.moveSpeed * comboModifier;
            }

            //Move Down_Right
            else if (moveAngle > -65 & moveAngle < -25) 
            {
                Vector2 dir = new Vector2(.75f, -.75f);
                playerScript.animator.SetInteger("Index", 4);
                playerScript._GameHandler.ChangeRuneDir(7);
                playerScript.rb.velocity = dir * playerScript.moveSpeed * comboModifier;
            }

        }

        if (moveDirection == Vector2.zero)
        {
            playerScript.rb.velocity = Vector2.zero;
        }
    }


    private void CheckCombo()
    {
        if (GameObject.Find("RuneManager").GetComponent<RuneCasting>().isComboing)
        {
            //Vitesse Reduite
            comboModifier = .5f;

            //Vitesse Nulle
            //comboModifier = 0f;

        }
        else
        {
            comboModifier = 1f;
        }
    }

    private void FindMoveAngle(){
        moveDirection = new Vector2(moveHorizontal, moveVertical);

        moveAngle = (int) Vector2.Angle(moveDirection, Vector2.right);
        if (moveVertical < 0)
        {
            moveAngle *= -1;
        }  
    }

    private void FindAimAngle()
    {
        aimDirection = new Vector2(aimHorizontal, aimVertical);

        aimAngle = (int)Vector2.Angle(aimDirection, Vector2.right);
        if (aimVertical < 0)
        {
            aimAngle *= -1;
        }
    }

    public Vector3 GetPosition()
    {
        return this.gameObject.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ExitTrigger")
        {
            if (playerScript._GameHandler.roomCleared)
            {
                playerScript._GameHandler.roomCleared = false;
                playerScript._GameHandler.lvlManager.GetComponent<LevelManager>().FadeToLevel();
            }
            else
            {
                Debug.LogWarning("Roomed Not Cleared");
            }
        }
    }

}
