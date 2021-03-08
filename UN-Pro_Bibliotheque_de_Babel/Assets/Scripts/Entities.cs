using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Rigidbody2D))]
public class Entities : MonoBehaviour
{
    [Header("GameHandler")]
    public GameHandler _GameHandler;

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

    [Header("IsTakingDamage")]
    public bool isTakingDamage;

    [Header("IsRooted")]
    public bool canMove;

    [Header("Health Bar")]
    public Slider healthBar;

    [Header("Type of entity")]
    public string entityType;

    // Start is called before the first frame update
    void Start()
    {
        SetStartHealth();
        _GameHandler = GameObject.FindGameObjectWithTag("GameHandler").GetComponent<GameHandler>();
        canMove = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckHealth();
    }

    public void SetHealth(int dmg)
    {
        currentHealth -= dmg;
    }

    protected void SetStartHealth()
    {
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = maxHealth;
        
    }
    void CheckHealth()
    {
        healthBar.value = currentHealth;

        if (currentHealth <= 0)
        {
            _GameHandler.nmbRemaining--;
            Destroy(this.gameObject);
        }
    }

    public void SetMovement()
    {
        canMove = !canMove;
    }
    public void SetMaxHealth(int Health)
    {
        healthBar.maxValue = Health;
        healthBar.value = Health;
        maxHealth = Health;
        currentHealth = maxHealth;
    }

}
