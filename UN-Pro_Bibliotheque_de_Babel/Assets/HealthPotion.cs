using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour  
{
    public PlayerScript playerscript;
    public AudioSource Healthsound;

    // Start is called before the first frame update
    void Start()
    {
     playerscript = GameObject.FindGameObjectWithTag("Player1").GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player1" && playerscript.currentHealth < playerscript.maxHealth)
        {
            playerscript.PickedUpHeart();
            StartCoroutine(HealthPotSound());
            
        }
    }

    public IEnumerator HealthPotSound()
    {
        Healthsound.Play();
        yield return new WaitForSeconds(0.3f);
        Destroy(this.gameObject);
    }
}
