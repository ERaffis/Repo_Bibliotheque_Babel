using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Embrasement_Ordre : MonoBehaviour
{
    public Projectile_Joueur projectile_Joueur;
    public GameObject AoE_Feu;
    public int lvlRune;

    private void Start()
    {
        AoE_Feu = GetComponent<Projectile_Joueur>().aoePrefab;
    }
    private void OnEnable()
    {
        AoE_Feu = GetComponent<Projectile_Joueur>().aoePrefab;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        AoE_Feu = GetComponent<Projectile_Joueur>().aoePrefab;

        if (collider.gameObject.CompareTag("Ennemy") || collider.gameObject.CompareTag("Tour"))
        {    
            GameObject aoe = Instantiate(AoE_Feu, collider.transform.position, Quaternion.identity);
            aoe.GetComponent<EmbrasementAoEScript>().projectile_Joueur = projectile_Joueur;
            aoe.transform.parent = null;
        }

        if (collider.gameObject.CompareTag("Boss"))
        {
            GameObject aoe = Instantiate(AoE_Feu, collider.transform.position, Quaternion.identity);
            aoe.GetComponent<EmbrasementAoEScript>().projectile_Joueur = projectile_Joueur;
            aoe.transform.parent = null;
        }

    } 
}