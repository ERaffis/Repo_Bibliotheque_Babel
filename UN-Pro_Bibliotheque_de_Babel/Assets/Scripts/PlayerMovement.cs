using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Rewired;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Rewired Attributes")]
    [SerializeField] private int playerID = 0;
    private Player player;

    [Header("Player Components")]
    public PlayerScript playerScript;
    public Rigidbody2D rb;

    public float comboModifier;

    private float moveHorizontal;
    private float moveVertical ;
    private Vector2 moveDirection;
    private int moveAngle;

    private void Start() {

        player = ReInput.players.GetPlayer(playerID);
        playerScript = GetComponent<PlayerScript>();

        rb.gravityScale = 0;
    }
    
    private void Update() {
        
    }

    private void FixedUpdate() {

        comboModifier = 1f;
        
        GetAxies();

        FindAngle();

        MovePlayer();
    }

    private void GetAxies() {

        // Mouvement sans délais
        moveHorizontal = player.GetAxisRaw("Move Horizontal");
        moveVertical = player.GetAxisRaw("Move Vertical");
        
    }

    private void MovePlayer(){
        
        if(player.GetButton("Combo"))
        {   
            //Vitesse Reduite
            comboModifier = .5f;

            //Vitesse Nulle
            //comboModifier = 0f;
            
        }


        if(moveDirection != Vector2.zero) {
            //Move Right
            if (moveAngle >= -25 & moveAngle <= 25)
            {
                rb.velocity = Vector2.right * playerScript.moveSpeed * comboModifier;
                playerScript.animator.SetInteger("Index", 1);
                playerScript.spriteRenderer.flipX = false;
                
                //playerScript.spriteRenderer.sprite = playerScript.spritesList[0];
            }

            //Move Up_Right
            if (moveAngle > 25 & moveAngle < 65) 
            {
                rb.velocity = new Vector2(.75f, .75f) * playerScript.moveSpeed * comboModifier;
                playerScript.animator.SetInteger("Index", 2);
                playerScript.spriteRenderer.flipX = false;
                
                //playerScript.spriteRenderer.sprite = playerScript.spritesList[1];
            }

            //Move Up
            if (moveAngle >= 65 & moveAngle <= 115) 
            {
                rb.velocity = Vector2.up * playerScript.moveSpeed * comboModifier;
                playerScript.animator.SetInteger("Index", 3);
                playerScript.spriteRenderer.flipX = false;
                
                //playerScript.spriteRenderer.sprite = playerScript.spritesList[2];
            }

            //Move Up_Left
            if (moveAngle > 115 & moveAngle < 155) 
            {
                rb.velocity = new Vector2(-.75f, .75f) * playerScript.moveSpeed * comboModifier;
                playerScript.animator.SetInteger("Index", 2);
                playerScript.spriteRenderer.flipX = true;
                
                //playerScript.spriteRenderer.sprite = playerScript.spritesList[3];
            }

            //Move Left
            if (moveAngle >= 155 || moveAngle <= -155) 
            {
                rb.velocity = Vector2.left * playerScript.moveSpeed * comboModifier;
                playerScript.animator.SetInteger("Index", 1);
                playerScript.spriteRenderer.flipX = true;
                
                //playerScript.spriteRenderer.sprite = playerScript.spritesList[4];
            }

            //Move Down_Left
            if (moveAngle > -155 & moveAngle < -115) 
            {
                rb.velocity = new Vector2(-.75f, -.75f) * playerScript.moveSpeed * comboModifier;
                playerScript.animator.SetInteger("Index", 5);
                playerScript.spriteRenderer.flipX = true;
                
                //playerScript.spriteRenderer.sprite = playerScript.spritesList[5];
            }

            //Move Down
            if (moveAngle >= -115 & moveAngle <= -65) 
            {
                rb.velocity = Vector2.down * playerScript.moveSpeed * comboModifier;
                playerScript.animator.SetInteger("Index", 4);
                playerScript.spriteRenderer.flipX = false;
                
                //playerScript.spriteRenderer.sprite = playerScript.spritesList[6];
            }

            //Move Down_Right
            if (moveAngle > -65 & moveAngle < -25) 
            {
                rb.velocity = new Vector2(.75f, -.75f) * playerScript.moveSpeed * comboModifier;
                playerScript.animator.SetInteger("Index", 5);
                playerScript.spriteRenderer.flipX = false;
                
                //playerScript.spriteRenderer.sprite = playerScript.spritesList[7];
            }

        }

        if (moveDirection == Vector2.zero)
        {
            rb.velocity = Vector2.zero;
            playerScript.animator.SetInteger("Index", 0);
            playerScript.spriteRenderer.flipX = false;
            
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
}
