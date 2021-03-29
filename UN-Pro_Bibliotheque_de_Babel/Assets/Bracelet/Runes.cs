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

    public void Maitresse(GameObject projectile)
    {
        switch (name)
        {
            case "Embrasemnent":

                break;

            case "Givre":

                break;

            case "Amplification":

                break;

            case "Explosion":
                projectile.AddComponent<Explosion_Maîtresse>();
                projectile.GetComponent<Explosion_Maîtresse>().projectile_Joueur = projectile.GetComponent<Projectile_Joueur>();
                break;

            default:
                break;
        }
    }

    public void Support(int pressOrder)
    {
        switch (name)
        {
            case "Embrasemnent":
                if(order == pressOrder )
                {
                    Ordre(name);
                } else
                {

                }
                break;

            case "Givre":
                if (order == pressOrder)
                {
                    Ordre(name);
                }
                else
                {

                }
                break;

            case "Amplification":
                if (order == pressOrder)
                {
                    Ordre(name);
                }
                else
                {

                }
                break;

            case "Explosion":
                if (order == pressOrder)
                {
                    Ordre(name);
                }
                else
                {

                }
                break;

            default:
                break;
        }
    }

    public void Ordre(string name)
    {
        switch (name)
        {
            case "Embrasemnent":

                break;

            case "Givre":

                break;

            case "Amplification":

                break;

            case "Explosion":

                break;

            default:
                break;
        }
    }
}
