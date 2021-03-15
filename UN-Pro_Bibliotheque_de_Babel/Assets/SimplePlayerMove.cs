using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class SimplePlayerMove : MonoBehaviour
{
    private float moveHorizontal;
    private float moveVertical;

    [Header("Rewired Attributes")]
    [SerializeField] private int playerID = 0;
    public Player playerInputs;

    // Start is called before the first frame update
    void Start()
    {
        playerInputs = ReInput.players.GetPlayer(playerID);

    }

    // Update is called once per frame
    void Update()
    {
        moveHorizontal = playerInputs.GetAxisRaw("Move Horizontal");
        moveVertical = playerInputs.GetAxisRaw("Move Vertical");


        this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveHorizontal*2, moveVertical*2);

    }
}
