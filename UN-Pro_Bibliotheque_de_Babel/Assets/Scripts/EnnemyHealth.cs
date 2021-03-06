using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnnemyHealth : MonoBehaviour
{
    public int maxHealth = 5;
    public int currentHealth;

    public GameObject healthBar;
    void Start()
    {
        
        currentHealth = maxHealth;
        healthBar.GetComponentInChildren<HealthBar>().SetMaxHealth(maxHealth);
    }



    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            currentHealth--;
            healthBar.GetComponentInChildren<HealthBar>().SetHealth(currentHealth);

        }
        if(currentHealth == 0)
        {
            Destroy(this.gameObject);
        }
    }
}
