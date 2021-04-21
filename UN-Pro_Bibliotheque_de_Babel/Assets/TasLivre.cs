using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TasLivre : MonoBehaviour
{
    private int nmbCharge;
    private float waitTimer;
    [SerializeField] private ParticleSystem particle;

    private void OnEnable()
    {
        nmbCharge = 3;
        waitTimer = 0;
    }

    private void Update()
    {
        waitTimer -= Time.deltaTime;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("TouchedProjectile");
        if (collision.gameObject.TryGetComponent(out Amplification_Maitresse b) && waitTimer <= 0f)
        {
            particle.Stop();
            particle.Play();
            nmbCharge--;
            waitTimer = 5f;
            if (nmbCharge <= 0)
            {
                Destroy(gameObject, 1f);
            }
            transform.localScale *= 0.75f;
        }
    }
}
