using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Rewired;


public class PlayerScriptPhil : MonoBehaviour
{
    public float comboModifier;
    public float envModifier;

    [Header("Rewired Attributes")]
    [SerializeField] private int playerID = 0;
    public Player playerInputs;

    private float moveHorizontal;
    private float moveVertical;
    private Vector2 moveDirection;
    private int moveAngle;
    public float moveSpeed;



    public Vector2 lastVelocity;


    private void Start()
    {
        playerInputs = ReInput.players.GetPlayer(playerID);
        this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        moveSpeed = 2f;
        comboModifier = 1f;
        envModifier = 1f;
    }

    private void Update()
    {
        GetMoveAxies();
        FindMoveAngle();
        MovePlayer();
    }

    private void FixedUpdate()
    {

    }

    private void GetMoveAxies()
    {

        // Mouvement sans délais
        moveHorizontal = playerInputs.GetAxisRaw("Move Horizontal");
        moveVertical = playerInputs.GetAxisRaw("Move Vertical");
    }

   

  

    private void MovePlayer()
    {

        if (moveDirection != Vector2.zero)
        {

            //Move Right
            if (moveAngle >= -25 & moveAngle <= 25)
            {
                Vector2 dir = Vector2.right;
                this.gameObject.GetComponent<Rigidbody2D>().velocity = dir * moveSpeed * comboModifier * envModifier;
                
            }

            //Move Left
            else if (moveAngle >= 155 || moveAngle <= -155)
            {
                Vector2 dir = Vector2.left;
                this.gameObject.GetComponent<Rigidbody2D>().velocity = dir * moveSpeed * comboModifier * envModifier;
            }

            //Move Up
            else if (moveAngle >= 65 & moveAngle <= 115)
            {
                Vector2 dir = Vector2.up;
                this.gameObject.GetComponent<Rigidbody2D>().velocity = dir * moveSpeed * comboModifier * envModifier;
            }

            //Move Up_Right
            else if (moveAngle > 25 & moveAngle < 65)
            {
                Vector2 dir = new Vector2(.75f, .75f);
                this.gameObject.GetComponent<Rigidbody2D>().velocity = dir * moveSpeed * comboModifier * envModifier;
            }

            //Move Up_Left
            else if (moveAngle > 115 & moveAngle < 155)
            {
                Vector2 dir = new Vector2(-.75f, .75f);
                this.gameObject.GetComponent<Rigidbody2D>().velocity = dir * moveSpeed * comboModifier * envModifier;
            }

            //Move Down
            else if (moveAngle >= -115 & moveAngle <= -65)
            {
                Vector2 dir = Vector2.down;
                this.gameObject.GetComponent<Rigidbody2D>().velocity = dir * moveSpeed * comboModifier * envModifier;
            }

            //Move Down_Left
            else if (moveAngle > -155 & moveAngle < -115)
            {
                Vector2 dir = new Vector2(-.75f, -.75f);
                this.gameObject.GetComponent<Rigidbody2D>().velocity = dir * moveSpeed * comboModifier * envModifier;
            }

            //Move Down_Right
            else if (moveAngle > -65 & moveAngle < -25)
            {
                Vector2 dir = new Vector2(.75f, -.75f);
                this.gameObject.GetComponent<Rigidbody2D>().velocity = dir * moveSpeed * comboModifier * envModifier;
            }

        }
        else
        {
            //PlayerScript.Instance.rb.velocity = Vector2.Lerp(PlayerScript.Instance.rb.velocity, Vector2.zero, Time.deltaTime * 0.5f);
        }
    }


    private void FindMoveAngle()
    {
        moveDirection = new Vector2(moveHorizontal, moveVertical);

        moveAngle = (int)Vector2.Angle(moveDirection, Vector2.right);
        if (moveVertical < 0)
        {
            moveAngle *= -1;
        }
    }

    

    public Vector3 GetPosition()
    {
        return this.gameObject.transform.position;
    }
}

