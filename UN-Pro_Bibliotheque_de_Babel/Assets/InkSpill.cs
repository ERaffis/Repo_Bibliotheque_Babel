using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkSpill : MonoBehaviour
{
    public Sprite frozenSprite;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.parent.TryGetComponent(out PlayerScript a))
        {
            collision.transform.parent.GetComponent<PlayerMovement>().envModifier = 0.25f;
        }

        if (collision.TryGetComponent(out Givre_Maitresse b))
        {
            GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<SpriteRenderer>().sprite = frozenSprite;
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.parent.TryGetComponent(out PlayerScript a))
        {
            collision.transform.parent.GetComponent<PlayerMovement>().envModifier = 1f;
        }
    }

}
