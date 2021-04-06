using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilSpill : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("HalfCollider"))
        {
            collision.transform.parent.GetComponent<PlayerScript>().ChangeMoveState();
            collision.transform.parent.GetComponent<Rigidbody2D>().drag = 0;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("HalfCollider"))
        {
            collision.transform.parent.GetComponent<PlayerScript>().ChangeMoveState();
            collision.transform.parent.GetComponent<Rigidbody2D>().drag = 10;
        }
    }
}
