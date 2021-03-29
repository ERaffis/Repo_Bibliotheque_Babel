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
    public int nmbRune;
    public Runes[] activeRunes;


    public void ProjectileSolo(string name, Runes rune)
    {
        switch (name)
        {
            case "Simple":
                GameObject projectile = Instantiate(prefabProjectile, GameHandler.Instance.activeInstDir.transform);
                projectile.AddComponent<Projectile_Joueur>();
                projectile.GetComponent<Projectile_Joueur>().SetValues(
                    (baseDamage + rune.baseDamage) * rune.multDamage, 
                    rune.baseKnockbak, 
                    rune.dotDamage, 
                    rune.dotDuration, 
                    rune.areaSize, 
                    rune.areaDamage, 
                    rune.areaDuration, 
                    rune.stuntDuration, 
                    rune.debuff, 
                    rune.debuffDuration, 
                    rune.slowDuration, 
                    rune.slowPower, 
                    rune.aoeSize, 
                    rune.aoeDamage, 
                    rune.secondEnemyDamage, 
                    rune.secondAoeSize, 
                    rune.secondAoeDamage, 
                    rune.delaySecondAoe, 
                    rune.explosionForce);

                Debug.Log("Instantiaded Projectile");
                rune.Maitresse(projectile);
                break;

            case "3 Projectiles":
                GameObject projectile1 = Instantiate(prefabProjectile, GameHandler.Instance.activeInstDir.transform);
                Debug.Log("Instantiaded Projectile");
                rune.Maitresse(projectile1);
                break;

            case "Mitrailleuse":
                GameObject projectile2 = Instantiate(prefabProjectile,GameHandler.Instance.activeInstDir.transform);
                Debug.Log("Instantiaded Projectile");
                rune.Maitresse(projectile2);
                break;

            case "Tete Chercheuse":
                GameObject projectile3 = Instantiate(prefabProjectile, GameHandler.Instance.activeInstDir.transform);
                Debug.Log("Instantiaded Projectile");
                rune.Maitresse(projectile3);
                break;

            case "Vitesse Rapide":
                GameObject projectile4 = Instantiate(prefabProjectile, GameHandler.Instance.activeInstDir.transform);
                Debug.Log("Instantiaded Projectile");
                rune.Maitresse(projectile4);
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
                GameObject projectile = Instantiate(prefabProjectile, GameHandler.Instance.activeInstDir.transform);
                rune0.Maitresse(projectile);
                break;

            case "3 Projectiles":
                GameObject projectile1 = Instantiate(prefabProjectile, GameHandler.Instance.activeInstDir.transform);
                rune0.Maitresse(projectile1);
                break;

            case "Mitrailleuse":
                GameObject projectile2 = Instantiate(prefabProjectile, GameHandler.Instance.activeInstDir.transform);
                rune0.Maitresse(projectile2);
                break;

            case "Tete Chercheuse":
                GameObject projectile3 = Instantiate(prefabProjectile, GameHandler.Instance.activeInstDir.transform);
                rune0.Maitresse(projectile3);
                break;

            case "Vitesse Rapide":
                GameObject projectile4 = Instantiate(prefabProjectile, GameHandler.Instance.activeInstDir.transform);
                rune0.Maitresse(projectile4);
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
                GameObject projectile = Instantiate(prefabProjectile, GameHandler.Instance.activeInstDir.transform);
                rune0.Maitresse(projectile);
                rune1.Support(1);
                break;

            case "3 Projectiles":
                GameObject projectile1 = Instantiate(prefabProjectile, GameHandler.Instance.activeInstDir.transform);
                rune0.Maitresse(projectile1);
                rune1.Support(1);
                break;

            case "Mitrailleuse":
                GameObject projectile2 = Instantiate(prefabProjectile, GameHandler.Instance.activeInstDir.transform);
                rune0.Maitresse(projectile2);
                rune1.Support(1);
                break;

            case "Tete Chercheuse":
                GameObject projectile3 = Instantiate(prefabProjectile, GameHandler.Instance.activeInstDir.transform);
                rune0.Maitresse(projectile3);
                rune1.Support(1);
                break;

            case "Vitesse Rapide":
                GameObject projectile4 = Instantiate(prefabProjectile, GameHandler.Instance.activeInstDir.transform);
                rune0.Maitresse(projectile4);
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
                GameObject projectile = Instantiate(prefabProjectile, GameHandler.Instance.activeInstDir.transform);
                rune0.Maitresse(projectile);
                rune1.Support(1);
                rune2.Support(2);
                break;

            case "3 Projectiles":
                GameObject projectile1 = Instantiate(prefabProjectile, GameHandler.Instance.activeInstDir.transform);
                rune0.Maitresse(projectile1);
                rune1.Support(1);
                rune2.Support(2);
                break;

            case "Mitrailleuse":
                GameObject projectile2 = Instantiate(prefabProjectile, GameHandler.Instance.activeInstDir.transform);
                rune0.Maitresse(projectile2);
                rune1.Support(1);
                rune2.Support(2);
                break;

            case "Tete Chercheuse":
                GameObject projectile3 = Instantiate(prefabProjectile, GameHandler.Instance.activeInstDir.transform);
                rune0.Maitresse(projectile3);
                rune1.Support(1);
                rune2.Support(2);
                break;

            case "Vitesse Rapide":
                GameObject projectile4 = Instantiate(prefabProjectile, GameHandler.Instance.activeInstDir.transform);
                rune0.Maitresse(projectile4);
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
                GameObject projectile = Instantiate(prefabProjectile, GameHandler.Instance.activeInstDir.transform);
                rune0.Maitresse(projectile);
                rune1.Support(1);
                rune2.Support(2);
                rune3.Support(3);
                break;

            case "3 Projectiles":
                GameObject projectile1 = Instantiate(prefabProjectile, GameHandler.Instance.activeInstDir.transform);
                rune0.Maitresse(projectile1);
                rune1.Support(1);
                rune2.Support(2);
                rune3.Support(3);
                break;

            case "Mitrailleuse":
                GameObject projectile2 = Instantiate(prefabProjectile, GameHandler.Instance.activeInstDir.transform);
                rune0.Maitresse(projectile2);
                rune1.Support(1);
                rune2.Support(2);
                rune3.Support(3);
                break;

            case "Tete Chercheuse":
                GameObject projectile3 = Instantiate(prefabProjectile, GameHandler.Instance.activeInstDir.transform);
                rune0.Maitresse(projectile3);
                rune1.Support(1);
                rune2.Support(2);
                rune3.Support(3);
                break;

            case "Vitesse Rapide":
                GameObject projectile4 = Instantiate(prefabProjectile, GameHandler.Instance.activeInstDir.transform);
                rune0.Maitresse(projectile4);
                rune1.Support(1);
                rune2.Support(2);
                rune3.Support(3);
                break;

            default:
                break;
        }
    }
}
