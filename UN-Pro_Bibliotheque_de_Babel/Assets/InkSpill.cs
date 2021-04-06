using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkSpill : MonoBehaviour
{
    public Sprite frozenSprite;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "HalfCollider" :
                if(collision.transform.parent.TryGetComponent(out PlayerScript plScript))
                {
                    collision.transform.parent.GetComponent<PlayerMovement>().envModifier = 0.25f;
                }
                break;

            case "Projectile":

                if (collision.TryGetComponent(out Givre_Maitresse b))
                {
                    Debug.Log("Freeze InkSpill");
                    GetComponent<CircleCollider2D>().enabled = false;
                    GetComponent<SpriteRenderer>().sprite = frozenSprite;
                    Destroy(collision.gameObject);
                }
                break;

            default:
                break;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "HalfCollider":
                if (collision.transform.parent.TryGetComponent(out PlayerScript a))
                {
                    collision.transform.parent.GetComponent<PlayerMovement>().envModifier = 1f;
                }
                break;
        }
    }
        
}

