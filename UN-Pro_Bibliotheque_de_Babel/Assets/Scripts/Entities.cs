using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Entities : MonoBehaviour
{
    [Header("Basic Info")]
    public string entityName;
    public int maxHealth;
    public int currentHealth;
    public float moveSpeed;
    public int animationIndex;

    [Header("Components")]
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    public Rigidbody2D rb;

    //public bool canMove;

    [Header("Type of entity")]
    public string entityType;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha5)) SetHealth();
    }

    public void SetHealth()
    {
        currentHealth --;
    }
}
