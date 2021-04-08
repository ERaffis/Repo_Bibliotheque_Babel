using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Amplification_Support : MonoBehaviour
{
    public Projectile_Joueur projectile_Joueur;


    public void OnEnable()
    {
        transform.localScale = transform.localScale * 1.5f;
        GetComponent<Rigidbody2D>().velocity *= 0.8f;
    }

}
