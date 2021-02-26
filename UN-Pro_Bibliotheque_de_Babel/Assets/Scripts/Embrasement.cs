using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Embrasement : Runes
{

    public Transform firepoint;
    public GameObject Projectile;

    // Start is called before the first frame update
    void Start()
    {
        damage = 10;
        knockback = 0.1f;
        projectileSpeed = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
