using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Amplification_Ordre : MonoBehaviour
{ 
    public Projectile_Joueur projectile_Joueur;

    public void OnEnable()
    {
        GetComponent<Rigidbody2D>().velocity *= 1.3f;
    }
}
