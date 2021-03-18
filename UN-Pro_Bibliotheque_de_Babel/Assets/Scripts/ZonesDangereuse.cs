using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonesDangereuse : MonoBehaviour
{
    public float previewTime;
    public float activateTime;

    public GameObject player;
    public int damage;

    public bool isTakingDamage;
    public bool isPreviewing;
    public bool isActive;
    private CircleCollider2D Collider;
    private SpriteRenderer Sprite;

    public Sprite[] spriteArray;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player1");
        previewTime = 1.5f;
        activateTime = 2.5f;
        damage = 5;
        isPreviewing = false;
        isActive = false;
        Collider = GetComponent<CircleCollider2D>();
        Sprite = gameObject.GetComponent<SpriteRenderer>();
        isTakingDamage = false;
    }

    
    void Update()
    {
        if(gameObject.activeInHierarchy && previewTime >= 0f)
        {
            previewTime -= Time.deltaTime;
            isPreviewing = true;
            Collider.enabled = false;
            Sprite.sprite = spriteArray[0];
        }
        else if (gameObject.activeInHierarchy && previewTime <= 0f)
        {
            isPreviewing = false;
            isActive = true;
            Collider.enabled = true;
            Sprite.sprite = spriteArray[1];
            StartCoroutine(DestroyZone());
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player1" && isActive == true && isTakingDamage == false)
        {
            StartCoroutine(DamageOverTime(collision));
        }
        
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "player1" && isActive == true)
        {
            isTakingDamage = false;
        }
    }

    public IEnumerator DamageOverTime(Collider2D collision)
    {
        if (!player.GetComponent<PlayerScript>().isImmune)
        {
            isTakingDamage = true;
            collision.gameObject.GetComponent<PlayerScript>().SetPlayerHealth(damage);
        }
        yield return new WaitForSeconds(0.5f);
        isTakingDamage = false;
    }

    public IEnumerator DestroyZone()
    {
        yield return new WaitForSeconds(activateTime);
        Destroy(gameObject);
    }
}
