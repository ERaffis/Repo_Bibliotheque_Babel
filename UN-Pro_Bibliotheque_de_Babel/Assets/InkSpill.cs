using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkSpill : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerScript a))
        {
            collision.gameObject.GetComponent<PlayerMovement>().envModifier = 0.25f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerScript a))
        {
            collision.gameObject.GetComponent<PlayerMovement>().envModifier = 1f;
        }
    }
}