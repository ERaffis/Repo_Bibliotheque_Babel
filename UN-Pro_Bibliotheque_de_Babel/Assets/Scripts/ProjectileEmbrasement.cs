using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileEmbrasement : MonoBehaviour


    // pour faire le hit effet (voir particules)
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 9)
        {
            StartCoroutine(ExplodeProjectile());
        }
    }

    IEnumerator ExplodeProjectile()
    {
        yield return new WaitForSeconds(0.01f);
        Destroy(this.gameObject);
    }
}
