using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class PlayerScript : Entities
{

    public uiManager uiManager;

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
        
    }
}
