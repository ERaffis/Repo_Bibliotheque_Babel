using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TasLivre : MonoBehaviour
{
    private int nmbCharge;

    private void OnEnable()
    {
        nmbCharge = 3;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("TouchedProjectile");
        if (collision.gameObject.TryGetComponent(out Amplification_Maitresse b))
        {
            nmbCharge--;
            if (nmbCharge <= 0)
            {
                Destroy(gameObject);
                Destroy(collision.gameObject);
            }
            transform.localScale *= 0.75f;
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("TouchedProjectile");
        if (collision.gameObject.TryGetComponent(out Amplification_Maitresse b))
        {
            nmbCharge--;
            if (nmbCharge <= 0)
            {
                Destroy(gameObject);
                Destroy(collision.gameObject);
            }
            transform.localScale *= 0.75f;
            Destroy(collision.gameObject);
        }
    }
}
