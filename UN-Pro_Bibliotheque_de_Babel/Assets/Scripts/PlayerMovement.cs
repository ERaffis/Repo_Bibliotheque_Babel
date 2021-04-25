using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Rewired;
using UnityEngine.SceneManagement;
using CodeMonkey.Utils;


public class PlayerMovement : MonoBehaviour
{
    public float comboModifier;
    public float envModifier;
    public float speedBoost;

    [Header("Dash Values")]
    public float dashDistance;
    public float dashCooldown = 3.5f;
    public bool canDash = true;
    public Transform pfDashEffect;
    

    private float moveHorizontal;
    private float moveVertical ;
    private Vector2 moveDirection;
    private int moveAngle;

    private float aimHorizontal;
    private float aimVertical;
    private Vector2 aimDirection;
    private int aimAngle;


    public Vector2 lastVelocity;

    public RuneManager runeManager;

    [Header("ModifVitesseCombo")]
    public bool pourcent20;
    public bool pourcent40;
    public bool pourcent80;

    private void Start() 
    {
        PlayerScript.Instance.rb.gravityScale = 0;

        comboModifier = 1f;
        envModifier = 1f;
        speedBoost = 1f;
    }
    
    private void Update() 
    {
        CheckCombo();
        if (!PlayerScript.Instance.isDead)
        {
            GetMoveAxies();
            GetAimAxies();
            FindMoveAngle();
            FindAimAngle();


            if (PlayerScript.Instance.canMove)
            {
                MovePlayer();
                Dash();
            }
            AimPlayer();
        }

        dashCooldown -= Time.deltaTime;

        PlayerScript.Instance.animator.SetFloat("Velocity X", GetComponent<Rigidbody2D>().velocity.x);
        PlayerScript.Instance.animator.SetFloat("Velocity Y", GetComponent<Rigidbody2D>().velocity.y);
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
    }


    private void OnDisable()
    {
        SceneManager.sceneLoaded -= SceneManager_sceneLoaded;
    }

    private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        comboModifier = 1f;

        if (pourcent20)
        {
            comboModifier = 0.8f;

            if (pourcent40)
            {
                comboModifier = 0.6f;

                if (pourcent80)
                {
                    comboModifier = 0.2f;
                }
            }

        }
        envModifier = 1f;
        speedBoost = 1f;
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
                GameHandler.Instance.ChangeRuneDir(0);
            }
            //Aim Left
            else if (aimAngle >= 155 || aimAngle <= -155)
            {
                GameHandler.Instance.ChangeRuneDir(4);
            }
            //Aim Up
            else if (aimAngle >= 65 & aimAngle <= 115)
            {
                GameHandler.Instance.ChangeRuneDir(2);
            }
            //Aim UpRight
            else if (aimAngle > 25 & aimAngle < 65)
            {
                GameHandler.Instance.ChangeRuneDir(1);
            }
            //Aim UpLeft
            else if (aimAngle > 115 & aimAngle < 155)
            {
                GameHandler.Instance.ChangeRuneDir(3);
            }
            //Aim Down
            else if (aimAngle >= -115 & aimAngle <= -65)
            {
                GameHandler.Instance.ChangeRuneDir(6);
            }
            //Aim DownLeft
            else if (aimAngle > -155 & aimAngle < -115)
            {
                GameHandler.Instance.ChangeRuneDir(5);
            }
            //Aim DownRight
            else if (aimAngle > -65 & aimAngle < -25)
            {
                GameHandler.Instance.ChangeRuneDir(7);
            }
        }
    }

    private void MovePlayer(){

        if(moveDirection != Vector2.zero) {

            SoundManager.PlaySound(SoundManager.Sound.PlayerMove,transform.position);

            //Move Right
            if (moveAngle >= -25 & moveAngle <= 25)
            {
                Vector2 dir = Vector2.right;

                GameHandler.Instance.ChangeMoveDir(0);
                if (aimDirection == Vector2.zero) GameHandler.Instance.ChangeRuneDir(0);

                PlayerScript.Instance.rb.velocity = dir * PlayerScript.Instance.moveSpeed * comboModifier * envModifier * speedBoost;
                lastVelocity = PlayerScript.Instance.rb.velocity;
            }

            //Move Left
            else if (moveAngle >= 155 || moveAngle <= -155)
            {
                Vector2 dir = Vector2.left;
                GameHandler.Instance.ChangeMoveDir(4);
                if (aimDirection == Vector2.zero) GameHandler.Instance.ChangeRuneDir(4);


                PlayerScript.Instance.rb.velocity = dir * PlayerScript.Instance.moveSpeed * comboModifier * envModifier * speedBoost;
                lastVelocity = PlayerScript.Instance.rb.velocity;
            }

            //Move Up
            else if (moveAngle >= 65 & moveAngle <= 115)
            {
                Vector2 dir = Vector2.up;

                GameHandler.Instance.ChangeMoveDir(2);
                if (aimDirection == Vector2.zero) GameHandler.Instance.ChangeRuneDir(2);


                PlayerScript.Instance.rb.velocity = dir * PlayerScript.Instance.moveSpeed * comboModifier * envModifier * speedBoost;
                lastVelocity = PlayerScript.Instance.rb.velocity;
            }

            //Move Up_Right
            else if (moveAngle > 25 & moveAngle < 65) 
            {
                Vector2 dir = new Vector2(.75f, .75f);
                GameHandler.Instance.ChangeMoveDir(1);
                if (aimDirection == Vector2.zero) GameHandler.Instance.ChangeRuneDir(1);


                PlayerScript.Instance.rb.velocity = dir * PlayerScript.Instance.moveSpeed * comboModifier * envModifier * speedBoost;
                lastVelocity = PlayerScript.Instance.rb.velocity;
            }

            //Move Up_Left
            else if (moveAngle > 115 & moveAngle < 155) 
            {
                Vector2 dir = new Vector2(-.75f, .75f);
                GameHandler.Instance.ChangeMoveDir(3);
                if (aimDirection == Vector2.zero) GameHandler.Instance.ChangeRuneDir(3);


                PlayerScript.Instance.rb.velocity = dir * PlayerScript.Instance.moveSpeed * comboModifier * envModifier * speedBoost;
                lastVelocity = PlayerScript.Instance.rb.velocity;
            }

            //Move Down
            else if (moveAngle >= -115 & moveAngle <= -65)
            {
                Vector2 dir = Vector2.down;
                GameHandler.Instance.ChangeMoveDir(6);
                if (aimDirection == Vector2.zero) GameHandler.Instance.ChangeRuneDir(6);

                PlayerScript.Instance.rb.velocity = dir * PlayerScript.Instance.moveSpeed * comboModifier * envModifier * speedBoost;
                lastVelocity = PlayerScript.Instance.rb.velocity;
            }

            //Move Down_Left
            else if (moveAngle > -155 & moveAngle < -115) 
            {
                Vector2 dir = new Vector2(-.75f, -.75f);
                GameHandler.Instance.ChangeMoveDir(5);
                if (aimDirection == Vector2.zero) GameHandler.Instance.ChangeRuneDir(5);

                PlayerScript.Instance.rb.velocity = dir * PlayerScript.Instance.moveSpeed * comboModifier * envModifier * speedBoost;
                lastVelocity = PlayerScript.Instance.rb.velocity;
            }

            //Move Down_Right
            else if (moveAngle > -65 & moveAngle < -25) 
            {
                Vector2 dir = new Vector2(.75f, -.75f);
                GameHandler.Instance.ChangeMoveDir(7);
                if (aimDirection == Vector2.zero) GameHandler.Instance.ChangeRuneDir(7);

                PlayerScript.Instance.rb.velocity = dir * PlayerScript.Instance.moveSpeed * comboModifier * envModifier * speedBoost;
                lastVelocity = PlayerScript.Instance.rb.velocity;
            }

        } 
    }

    private void CheckCombo()
    {
        if (runeManager.isComboing)
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

    private bool HitWall(Vector3 dir, float distance)
    {
        return Physics2D.Raycast(transform.position, dir, distance,LayerMask.GetMask("Room")).collider == null ;
    }
    private void Dash()
    {
        if (PlayerScript.Instance.playerInputs.GetButtonDown("Dash") && dashCooldown <= 0 && !runeManager.isComboing)
        {
            if(HitWall(new Vector3(lastVelocity.x, lastVelocity.y,0).normalized, dashDistance + 0.8f))
            {
                dashCooldown = 0.75f;
                Vector3 beforeDashPosition = transform.position;
                Transform dashEffectTransform = Instantiate(pfDashEffect, beforeDashPosition, Quaternion.identity);
                dashEffectTransform.eulerAngles = new Vector3(0, 0, 180 + UtilsClass.GetAngleFromVectorFloat(lastVelocity));
                transform.position += new Vector3(lastVelocity.x * dashDistance, lastVelocity.y * dashDistance) ;
            }
        }
    }

    public IEnumerator BoostSpeed()
    {
        speedBoost = 1.2f;
        yield return new WaitForSeconds(1.5f);
        speedBoost = 1f;
    }
}
