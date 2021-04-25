using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkSpill : MonoBehaviour
{
    public Sprite frozenSprite;
    public Sprite normalSprite;
    public bool isFrozen = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "HalfCollider" :
                if(collision.transform.parent.TryGetComponent(out PlayerScript plScript) && !isFrozen)
                {
                    collision.transform.parent.GetComponent<PlayerMovement>().envModifier = 0.6f;
                }
                break;

            case "Projectile":
                Debug.Log("TouchedProjectile");
                if (collision.TryGetComponent(out Givre_Maitresse b) && !isFrozen)
                {
                    Debug.Log("Freeze InkSpill");
                    isFrozen = true;
                    GetComponent<SpriteRenderer>().sprite = frozenSprite;
                }

                if (collision.TryGetComponent(out Embrasement_Maitresse c) && isFrozen)
                {
                    Debug.Log("Freeze InkSpill");
                    isFrozen = false;
                    GetComponent<SpriteRenderer>().sprite = normalSprite;
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

