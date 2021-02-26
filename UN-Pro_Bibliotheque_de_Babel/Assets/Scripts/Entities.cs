using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Entities : MonoBehaviour
{
    [Header("Basic Info")]
    public string entityName;
    public int health;
    public float moveSpeed;
    public int animationIndex;

    [Header("Components")]
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    public Rigidbody2D rb;


    [Header("Type of entity")]
    public string entityType;

    
}
