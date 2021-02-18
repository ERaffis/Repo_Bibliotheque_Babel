using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    

    [Header("Type of entity")]
    public string entityType;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
