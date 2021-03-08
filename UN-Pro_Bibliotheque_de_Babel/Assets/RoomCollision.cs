using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 9)
            Destroy(transform.parent.gameObject);
    }
}
