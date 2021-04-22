using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Amplification_Support : MonoBehaviour
{
    public Projectile_Joueur projectile_Joueur;
    public int lvlRune;

    public void OnEnable()
    {
        if (lvlRune == 1)
        {
            transform.localScale = transform.localScale * 1.5f;
            GetComponent<Rigidbody2D>().velocity *= 0.8f;
        }
        if (lvlRune == 2)
        {
            transform.localScale = transform.localScale * 1.5f;
            GetComponent<Rigidbody2D>().velocity *= 1f;
        }
        if (lvlRune == 3)
        {
            transform.localScale = transform.localScale * 1.5f;
            GetComponent<Rigidbody2D>().velocity *= 1.2f;
        }
    }

}
