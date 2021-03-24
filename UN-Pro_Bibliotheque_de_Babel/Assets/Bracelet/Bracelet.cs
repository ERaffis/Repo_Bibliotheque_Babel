using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Nouveau Bracelet", menuName = "B&R/Bracelets")]
public class Bracelet : ScriptableObject
{
    [Header("Base Info")]

    public new string name;
    public string description;

    [Header("Projectile Info")]
    public int nmbProjectile;
    public float sizeProjectile;
    public GameObject prefabProjectile;

    [Header("Base Stats")]
    public int baseDamage;
    public float baseSpeed;
    public float damageCast;
    public float castSpeed;
    public float castMultDamage;

    [Header("Runes")]
    public float nmbRune;
    public Runes[] activeRunes;


    public void Projectile(string name)
    {
        switch (name)
        {
            case "1":
                break;

            case "2":
                break;

            case "3":
                break;

            case "4":
                break;

            case "5":
                break;

            default:
                break;
        }
    }
}
