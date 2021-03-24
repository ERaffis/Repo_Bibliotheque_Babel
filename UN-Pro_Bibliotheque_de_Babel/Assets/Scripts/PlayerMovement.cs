using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Rewired;


public class PlayerMovement : MonoBehaviour
{
    public float comboModifier;
    public float envModifier;

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


    public Vector2 lastVelocity;


    private void Start() 
    {
        PlayerScript.Instance.rb.gravityScale = 0;

        comboModifier = 1f;
        envModifier = 1f;
    }
    
    private void Update() 
    {
        CheckCombo();

        GetMoveAxies();
        GetAimAxies();
        FindMoveAngle();
        FindAimAngle();
        
        if (PlayerScript.Instance.canMove) MovePlayer();
        AimPlayer();

    }

    private void FixedUpdate() 
    {
    
    }

    private void GetMoveAxies() {

        // Mouvement sans délais
        moveHorizontal = PlayerScript.Instance.playerInputs.GetAxisRaw("Move Horizontal");
        moveVertical = PlayerScript.Instance.playerInputs.GetAxisRaw("Move Vertical");       
    }

    private void GetAimAxies()
    {
        // Mouvement sans délais
        aimHorizontal = PlayerScript.Instance.playerInputs.GetAxisRaw("Aim Horizontal");
        aimVertical = PlayerScript.Instance.playerInputs.GetAxisRaw("Aim Vertical");
    }

    private void AimPlayer()
    {
        if(aimDirection != Vector2.zero)
        {
            //Aim Right
            if (aimAngle >= -25 & aimAngle <= 25 && aimAngle != 0)
            {
                PlayerScript.Instance._GameHandler.ChangeRuneDir(0);
                PlayerScript.Instance.animator.SetInteger("Index", 1);
            }
            //Aim Left
            else if (aimAngle >= 155 || aimAngle <= -155)
            {
                PlayerScript.Instance._GameHandler.ChangeRuneDir(4);
                PlayerScript.Instance.animator.SetInteger("Index", 2);
            }
            //Aim Up
            else if (aimAngle >= 65 & aimAngle <= 115)
            {
                PlayerScript.Instance.animator.SetInteger("Index", 3);
                PlayerScript.Instance._GameHandler.ChangeRuneDir(2);
            }
            //Aim UpRight
            else if (aimAngle > 25 & aimAngle < 65)
            {
                PlayerScript.Instance.animator.SetInteger("Index", 3);
                PlayerScript.Instance._GameHandler.ChangeRuneDir(1);
            }
            //Aim UpLeft
            else if (aimAngle > 115 & aimAngle < 155)
            {
                PlayerScript.Instance.animator.SetInteger("Index", 3);
                PlayerScript.Instance._GameHandler.ChangeRuneDir(3);
            }
            //Aim Down
            else if (aimAngle >= -115 & aimAngle <= -65)
            {
                PlayerScript.Instance.animator.SetInteger("Index", 4);
                PlayerScript.Instance._GameHandler.ChangeRuneDir(6);
            }
            //Aim DownLeft
            else if (aimAngle > -155 & aimAngle < -115)
            {
                PlayerScript.Instance.animator.SetInteger("Index", 4);
                PlayerScript.Instance._GameHandler.ChangeRuneDir(5);
            }
            //Aim DownRight
            else if (aimAngle > -65 & aimAngle < -25)
            {
                PlayerScript.Instance.animator.SetInteger("Index", 4);
                PlayerScript.Instance._GameHandler.ChangeRuneDir(7);
            }
        }
        

    }

    private void MovePlayer(){

        if(moveDirection != Vector2.zero) {

            //Move Right
            if (moveAngle >= -25 & moveAngle <= 25)
            {
                Vector2 dir = Vector2.right;

                PlayerScript.Instance._GameHandler.ChangeMoveDir(0);
                if (aimDirection == Vector2.zero) PlayerScript.Instance._GameHandler.ChangeRuneDir(0);

                PlayerScript.Instance.animator.SetInteger("Index", 1);
                PlayerScript.Instance.rb.velocity = dir * PlayerScript.Instance.moveSpeed * comboModifier * envModifier;
                lastVelocity = PlayerScript.Instance.rb.velocity;
            }

            //Move Left
            else if (moveAngle >= 155 || moveAngle <= -155)
            {
                Vector2 dir = Vector2.left;
                PlayerScript.Instance._GameHandler.ChangeMoveDir(4);
                if (aimDirection == Vector2.zero) PlayerScript.Instance._GameHandler.ChangeRuneDir(4);


                PlayerScript.Instance.animator.SetInteger("Index", 2);
                PlayerScript.Instance.rb.velocity = dir * PlayerScript.Instance.moveSpeed * comboModifier * envModifier;
                lastVelocity = PlayerScript.Instance.rb.velocity;
            }

            //Move Up
            else if (moveAngle >= 65 & moveAngle <= 115)
            {
                Vector2 dir = Vector2.up;
                PlayerScript.Instance.animator.SetInteger("Index", 3);

                PlayerScript.Instance._GameHandler.ChangeMoveDir(2);
                if (aimDirection == Vector2.zero) PlayerScript.Instance._GameHandler.ChangeRuneDir(2);


                PlayerScript.Instance.rb.velocity = dir * PlayerScript.Instance.moveSpeed * comboModifier * envModifier;
                lastVelocity = PlayerScript.Instance.rb.velocity;
            }

            //Move Up_Right
            else if (moveAngle > 25 & moveAngle < 65) 
            {
                Vector2 dir = new Vector2(.75f, .75f);
                PlayerScript.Instance.animator.SetInteger("Index", 3);
                PlayerScript.Instance._GameHandler.ChangeMoveDir(1);
                if (aimDirection == Vector2.zero) PlayerScript.Instance._GameHandler.ChangeRuneDir(1);


                PlayerScript.Instance.rb.velocity = dir * PlayerScript.Instance.moveSpeed * comboModifier * envModifier;
                lastVelocity = PlayerScript.Instance.rb.velocity;
            }

            //Move Up_Left
            else if (moveAngle > 115 & moveAngle < 155) 
            {
                Vector2 dir = new Vector2(-.75f, .75f);
                PlayerScript.Instance.animator.SetInteger("Index", 3);
                PlayerScript.Instance._GameHandler.ChangeMoveDir(3);
                if (aimDirection == Vector2.zero) PlayerScript.Instance._GameHandler.ChangeRuneDir(3);


                PlayerScript.Instance.rb.velocity = dir * PlayerScript.Instance.moveSpeed * comboModifier * envModifier;
                lastVelocity = PlayerScript.Instance.rb.velocity;
            }

            //Move Down
            else if (moveAngle >= -115 & moveAngle <= -65)
            {
                Vector2 dir = Vector2.down;
                PlayerScript.Instance.animator.SetInteger("Index", 4);
                PlayerScript.Instance._GameHandler.ChangeMoveDir(6);
                if (aimDirection == Vector2.zero) PlayerScript.Instance._GameHandler.ChangeRuneDir(6);

                PlayerScript.Instance.rb.velocity = dir * PlayerScript.Instance.moveSpeed * comboModifier * envModifier;
                lastVelocity = PlayerScript.Instance.rb.velocity;
            }

            //Move Down_Left
            else if (moveAngle > -155 & moveAngle < -115) 
            {
                Vector2 dir = new Vector2(-.75f, -.75f);
                PlayerScript.Instance.animator.SetInteger("Index", 4);
                PlayerScript.Instance._GameHandler.ChangeMoveDir(5);
                if (aimDirection == Vector2.zero) PlayerScript.Instance._GameHandler.ChangeRuneDir(5);

                PlayerScript.Instance.rb.velocity = dir * PlayerScript.Instance.moveSpeed * comboModifier * envModifier;
                lastVelocity = PlayerScript.Instance.rb.velocity;
            }

            //Move Down_Right
            else if (moveAngle > -65 & moveAngle < -25) 
            {
                Vector2 dir = new Vector2(.75f, -.75f);
                PlayerScript.Instance.animator.SetInteger("Index", 4);
                PlayerScript.Instance._GameHandler.ChangeMoveDir(7);
                if (aimDirection == Vector2.zero) PlayerScript.Instance._GameHandler.ChangeRuneDir(7);

                PlayerScript.Instance.rb.velocity = dir * PlayerScript.Instance.moveSpeed * comboModifier * envModifier;
                lastVelocity = PlayerScript.Instance.rb.velocity;
            }

        } else
        {
            //PlayerScript.Instance.rb.velocity = Vector2.Lerp(PlayerScript.Instance.rb.velocity, Vector2.zero, Time.deltaTime * 0.5f);
        }
    }

    private void CheckCombo()
    {
        /*if (GameObject.Find("RuneManager").GetComponent<RuneCasting>().isComboing)
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
        */
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
}
