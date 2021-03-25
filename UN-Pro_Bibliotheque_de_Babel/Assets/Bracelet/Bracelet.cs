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


    public void ProjectileSolo(string name, Runes rune)
    {
        switch (name)
        {
            case "Simple":
                Instantiate(prefabProjectile);
                rune.Maitresse();
                break;

            case "3 Projectiles":
                Instantiate(prefabProjectile);
                rune.Maitresse();
                break;

            case "Mitrailleuse":
                Instantiate(prefabProjectile);
                rune.Maitresse();
                break;

            case "Tete Chercheuse":
                Instantiate(prefabProjectile);
                rune.Maitresse();
                break;

            case "Vitesse Rapide":
                Instantiate(prefabProjectile);
                rune.Maitresse();
                break;

            default:
                break;
        }
    }


    public void ProjectileCombo(string braceletName, Runes rune0)
    {
        switch (braceletName)
        {
            case "Simple":
                Instantiate(prefabProjectile);
                rune0.Maitresse();
                break;

            case "3 Projectiles":
                Instantiate(prefabProjectile);
                rune0.Maitresse();
                break;

            case "Mitrailleuse":
                Instantiate(prefabProjectile);
                rune0.Maitresse();
                break;

            case "Tete Chercheuse":
                Instantiate(prefabProjectile);
                rune0.Maitresse();
                break;

            case "Vitesse Rapide":
                Instantiate(prefabProjectile);
                rune0.Maitresse();
                break;

            default:
                break;
        }
    }

    public void ProjectileCombo(string braceletName, Runes rune0, Runes rune1)
    {
        switch (braceletName)
        {
            case "Simple":
                Instantiate(prefabProjectile);
                rune0.Maitresse();
                rune1.Support(1);
                break;

            case "3 Projectiles":
                Instantiate(prefabProjectile);
                rune0.Maitresse();
                rune1.Support(1);
                break;

            case "Mitrailleuse":
                Instantiate(prefabProjectile);
                rune0.Maitresse();
                rune1.Support(1);
                break;

            case "Tete Chercheuse":
                Instantiate(prefabProjectile);
                rune0.Maitresse();
                rune1.Support(1);
                break;

            case "Vitesse Rapide":
                Instantiate(prefabProjectile);
                rune0.Maitresse();
                rune1.Support(1);
                break;

            default:
                break;
        }
    }

    public void ProjectileCombo(string braceletName, Runes rune0, Runes rune1, Runes rune2)
    {
        switch (braceletName)
        {
            case "Simple":
                Instantiate(prefabProjectile);
                rune0.Maitresse();
                rune1.Support(1);
                rune2.Support(2);
                break;

            case "3 Projectiles":
                Instantiate(prefabProjectile);
                rune0.Maitresse();
                rune1.Support(1);
                rune2.Support(2);
                break;

            case "Mitrailleuse":
                Instantiate(prefabProjectile);
                rune0.Maitresse();
                rune1.Support(1);
                rune2.Support(2);
                break;

            case "Tete Chercheuse":
                Instantiate(prefabProjectile);
                rune0.Maitresse();
                rune1.Support(1);
                rune2.Support(2);
                break;

            case "Vitesse Rapide":
                Instantiate(prefabProjectile);
                rune0.Maitresse();
                rune1.Support(1);
                rune2.Support(2);
                break;

            default:
                break;
        }
    }

    public void ProjectileCombo(string braceletName, Runes rune0, Runes rune1, Runes rune2, Runes rune3)
    {
        switch (braceletName)
        {
            case "Simple":
                Instantiate(prefabProjectile);
                rune0.Maitresse();
                rune1.Support(1);
                rune2.Support(2);
                rune3.Support(3);
                break;

            case "3 Projectiles":
                Instantiate(prefabProjectile);
                rune0.Maitresse();
                rune1.Support(1);
                rune2.Support(2);
                rune3.Support(3);
                break;

            case "Mitrailleuse":
                Instantiate(prefabProjectile);
                rune0.Maitresse();
                rune1.Support(1);
                rune2.Support(2);
                rune3.Support(3);
                break;

            case "Tete Chercheuse":
                Instantiate(prefabProjectile);
                rune0.Maitresse();
                rune1.Support(1);
                rune2.Support(2);
                rune3.Support(3);
                break;

            case "Vitesse Rapide":
                Instantiate(prefabProjectile);
                rune0.Maitresse();
                rune1.Support(1);
                rune2.Support(2);
                rune3.Support(3);
                break;

            default:
                break;
        }
    }
}
