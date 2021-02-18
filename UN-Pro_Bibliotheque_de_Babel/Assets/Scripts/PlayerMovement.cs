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

    [Header("Player Script")]
    public PlayerScript playerScript;

    [Header("Vector Information")]
    private float moveHorizontal;
    private float moveVertical ;
    private Vector2 moveDirection;
    private int moveAngle;

    public Rigidbody2D rb;
    public float moveSpeed;
    
    private void Start() {
        player = ReInput.players.GetPlayer(playerID);
    }
    
    private void Update() {
        
    }

    private void FixedUpdate() {
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
        
        if(moveDirection != Vector2.zero) {
            //Move Right
            if (moveAngle >= -25 & moveAngle <= 25)
            {
                rb.velocity = Vector2.right * moveSpeed;
                playerScript.activeSprite = playerScript.spritesList[0];
            }

            //Move Up_Right
            if (moveAngle > 25 & moveAngle < 65) 
            {
                rb.velocity = new Vector2(1, 1) * moveSpeed;
                playerScript.activeSprite = playerScript.spritesList[1];
            }

            //Move Up
            if (moveAngle >= 65 & moveAngle <= 115) 
            {
                rb.velocity = Vector2.up * moveSpeed;
                playerScript.activeSprite = playerScript.spritesList[2];
            }

            //Move Up_Left
            if (moveAngle > 115 & moveAngle < 155) 
            {
                rb.velocity = new Vector2(-1, 1) * moveSpeed;
                playerScript.activeSprite = playerScript.spritesList[3];
            }

            //Move Left
            if (moveAngle >= 155 || moveAngle <= -155) 
            {
                rb.velocity = Vector2.left * moveSpeed;
                playerScript.activeSprite = playerScript.spritesList[4];
            }

            //Move Down_Left
            if (moveAngle > -155 & moveAngle < -115) 
            {
                rb.velocity = new Vector2(-1, -1) * moveSpeed;
                playerScript.activeSprite = playerScript.spritesList[5];
            }

            //Move Down
            if (moveAngle >= -115 & moveAngle <= -65) 
            {
                rb.velocity = Vector2.down * moveSpeed;
                playerScript.activeSprite = playerScript.spritesList[6];
            }

            //Move Down_Right
            if (moveAngle > -65 & moveAngle < -25) 
            {
                rb.velocity = new Vector2(1, -1) * moveSpeed;
                playerScript.activeSprite = playerScript.spritesList[7];
            }

        }

        if (moveDirection == Vector2.zero)
        {
            rb.velocity = Vector2.zero;
        }
        
 
        
    }

    private void FindAngle(){
        moveDirection = new Vector2(moveHorizontal, moveVertical);

        moveAngle = (int) Vector2.Angle(moveDirection, Vector2.right);
        if (moveVertical < 0)
        {
            moveAngle = moveAngle * -1;
        }  
        print(moveAngle);
    }
}
