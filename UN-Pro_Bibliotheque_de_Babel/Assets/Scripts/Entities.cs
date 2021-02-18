using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entities : MonoBehaviour
{
    [Header("Basic Info")]
    public string entityName;
    public int health;
    [Space]
    public SpriteRenderer spriteRenderer;
    public Sprite activeSprite;
    public Sprite[] spritesList;
    

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
