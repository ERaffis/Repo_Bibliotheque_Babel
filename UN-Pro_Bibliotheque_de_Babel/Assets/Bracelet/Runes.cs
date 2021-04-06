using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nouvelle Rune", menuName = "B&R/Runes")]
public class Runes : ScriptableObject
{
    [Header("Base Info")]
    public new string name;
    public string description;

    [Header("Base Stats")]
    public int baseDamage;
    public float multDamage;
    public float baseKnockbak;

    [Header("Order")]
    public int order;
    public float orderMultDamage;

    [Header("Embrasement")]
    public int dotDamage;
    public int dotDuration;
    public float areaSize;
    public int areaDamage;
    public float areaDuration;

    [Header("Givre")]
    public int stuntDuration;
    public float debuff;
    public int debuffDuration;
    public int slowDuration;
    public float slowPower;

    [Header("Amplification")]
    public float multSize;
    public float multSpeed;

    [Header("Explosion")]
    public float aoeSize;
    public int aoeDamage;
    public float secondEnemyDamage;
    public float secondAoeSize;
    public int secondAoeDamage;
    public float delaySecondAoe;
    public float explosionForce;
    public int nmbProjectileExplosion;

    public void Maitresse(GameObject projectile)
    {
        switch (name)
        {
            case "Embrasement":
                projectile.AddComponent<Embrasement_Maitresse>();
                projectile.GetComponent<Embrasement_Maitresse>().projectile_Joueur = projectile.GetComponent<Projectile_Joueur>();
                break;

            case "Givre":
                projectile.AddComponent<Givre_Maitresse>();
                projectile.GetComponent<Givre_Maitresse>().projectile_Joueur = projectile.GetComponent<Projectile_Joueur>();
                break;

            case "Amplification":
                projectile.AddComponent<Amplification_Maitresse>();
                projectile.GetComponent<Amplification_Maitresse>().projectile_Joueur = projectile.GetComponent<Projectile_Joueur>();
                break;

            case "Explosion":
                projectile.AddComponent<Explosion_Maitresse>();
                projectile.GetComponent<Explosion_Maitresse>().projectile_Joueur = projectile.GetComponent<Projectile_Joueur>();
                break;

            default:
                break;
        }
    }

    public void Support(int pressOrder, GameObject projectile)
    {
        switch (name)
        {
            case "Embrasement":
                if(order == pressOrder)
                {
                    Ordre(name, projectile);
                } else
                {
                    projectile.AddComponent<Embrasement_Support>();
                    projectile.GetComponent<Embrasement_Support>().projectile_Joueur = projectile.GetComponent<Projectile_Joueur>();
                    projectile.GetComponent<Projectile_Joueur>().damage *= multDamage;
                }
                break;

            case "Givre":
                if (order == pressOrder)
                {
                    Ordre(name, projectile);
                }
                else
                {
                    projectile.AddComponent<Givre_Support>();
                    projectile.GetComponent<Givre_Support>().projectile_Joueur = projectile.GetComponent<Projectile_Joueur>();
                    projectile.GetComponent<Projectile_Joueur>().damage *= multDamage;

                }
                break;

            case "Amplification":
                if (order == pressOrder)
                {
                    Ordre(name, projectile);
                }
                else
                {
                    projectile.AddComponent<Amplification_Support>();
                    projectile.GetComponent<Amplification_Support>().projectile_Joueur = projectile.GetComponent<Projectile_Joueur>();
                    projectile.GetComponent<Projectile_Joueur>().damage *= multDamage;

                }
                break;

            case "Explosion":
                if (order == pressOrder)
                {
                    Ordre(name, projectile);
                }
                else
                {
                    projectile.AddComponent<Explosion_Support>();
                    projectile.GetComponent<Explosion_Support>().projectile_Joueur = projectile.GetComponent<Projectile_Joueur>();
                    projectile.GetComponent<Projectile_Joueur>().damage *= multDamage;

                }
                break;

            default:
                break;
        }
    }

    public void Ordre(string name, GameObject projectile)
    {
        switch (name)
        {
            case "Embrasement":
                projectile.AddComponent<Embrasement_Ordre>();
                projectile.GetComponent<Embrasement_Ordre>().projectile_Joueur = projectile.GetComponent<Projectile_Joueur>();
                projectile.GetComponent<Projectile_Joueur>().damage *= orderMultDamage;

                break;

            case "Givre":
                projectile.AddComponent<Givre_Ordre>();
                projectile.GetComponent<Givre_Ordre>().projectile_Joueur = projectile.GetComponent<Projectile_Joueur>();
                projectile.GetComponent<Projectile_Joueur>().damage *= orderMultDamage;

                break;

            case "Amplification":
                projectile.AddComponent<Amplification_Ordre>();
                projectile.GetComponent<Amplification_Ordre>().projectile_Joueur = projectile.GetComponent<Projectile_Joueur>();
                projectile.GetComponent<Projectile_Joueur>().damage *= orderMultDamage;

                break;

            case "Explosion":
                projectile.AddComponent<Explosion_Ordre>();
                projectile.GetComponent<Explosion_Ordre>().projectile_Joueur = projectile.GetComponent<Projectile_Joueur>();
                projectile.GetComponent<Projectile_Joueur>().damage *= orderMultDamage;

                break;

            default:
                break;
        }
    }
}
