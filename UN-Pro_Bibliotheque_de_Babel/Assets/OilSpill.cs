using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilSpill : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerScript a))
        {
            collision.gameObject.GetComponent<PlayerScript>().ChangeMoveState();
            collision.gameObject.GetComponent<Rigidbody2D>().drag = 0;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out PlayerScript a))
        {
            collision.gameObject.GetComponent<PlayerScript>().ChangeMoveState();
            collision.gameObject.GetComponent<Rigidbody2D>().drag = 10;
        }
    }
}
