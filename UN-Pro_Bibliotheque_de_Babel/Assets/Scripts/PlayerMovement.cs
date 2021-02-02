using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Rewired;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{

    /*[SerializedField]*/ private int playerID = 0;
    /*[SerializedField]*/ private Player player;
    private float moveHorizontal;
    private float moveVertical;
    public Rigidbody2D rb;
    public float speed;

    private static UnityAction _Move;
    
    private void Start() {

        player = ReInput.players.GetPlayer(playerID);
        //rb.gravityScale = 0f;
        _Move += GetAxies;
        _Move += MovePlayer;
        

    }
    
    private void Update() {
        
    }

    private void FixedUpdate() {
        GetAxies();
        MovePlayer();
    }

    private void GetAxies(){
        moveHorizontal = player.GetAxis("Move Horizontal");
        moveVertical = player.GetAxis("Move Vertical");
    }

    private void MovePlayer(){
        Vector2 moveDirection = new Vector2(moveHorizontal,moveVertical);
        rb.AddForce(moveDirection * speed);
    }
}
