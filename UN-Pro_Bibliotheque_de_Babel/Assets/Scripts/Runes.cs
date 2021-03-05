using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runes : MonoBehaviour
{
    [Header("Common Values")]
    public string runeame;
    public int damage;

    [Header("Player Components")]
    public PlayerScript playerScript;
    public Rigidbody2D playerRb;

    [Header("Game Handler")]
    public GameHandler _GameHandler;

    private void Awake()
    {
        _GameHandler = GameObject.FindGameObjectWithTag("GameHandler").GetComponent<GameHandler>();
        playerScript = GameObject.FindGameObjectWithTag("Player1").GetComponent<PlayerScript>();
        playerRb = GameObject.FindGameObjectWithTag("Player1").GetComponent<Rigidbody2D>();
}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
