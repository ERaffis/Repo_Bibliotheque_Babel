using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour  
{
    public AudioSource Healthsound;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "HalfCollider" && PlayerScript.Instance.currentHealth < PlayerScript.Instance.maxHealth)
        {
            PlayerScript.Instance.PickedUpHeart();
            StartCoroutine(HealthPotSound());
        }
    }

    public IEnumerator HealthPotSound()
    {
        Healthsound.Play();
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
    }
}
