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
    public float angle;

    [Header("Runes")]
    public int nmbRune;
    public Runes[] activeRunes;


    public void ProjectileSolo(string name, Runes rune)
    {
        var shotRotation = GameHandler.Instance.activeInstDir.transform.rotation;

        switch (name)
        {
            case "Simple":
                GameObject projectile = Instantiate(prefabProjectile, GameHandler.Instance.activeInstDir.transform.position, shotRotation);
                projectile.GetComponent<Rigidbody2D>().velocity = projectile.transform.right * baseSpeed * rune.multSpeed;

                projectile.AddComponent<Projectile_Joueur>();
                projectile.GetComponent<Projectile_Joueur>().SetValues(
                    (baseDamage + rune.baseDamage), 
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
                angle = -45f;
                for (int i = 0; i < 3; i++)
                {
                    var shotRotation1 = GameHandler.Instance.activeInstDir.transform.rotation;
                    shotRotation1 *= Quaternion.Euler(0, 0, angle);

                    GameObject projectile1 = Instantiate(prefabProjectile, GameHandler.Instance.activeInstDir.transform.position, shotRotation1);
                    projectile1.GetComponent<Rigidbody2D>().velocity = projectile1.transform.right * baseSpeed * rune.multSpeed;

                    projectile1.AddComponent<Projectile_Joueur>();
                    projectile1.GetComponent<Projectile_Joueur>().SetValues(
                        (baseDamage + rune.baseDamage),
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

                    rune.Maitresse(projectile1);
                    angle += 45f;
                }
                break;

            case "Mitrailleuse":
                GameObject projectile2 = Instantiate(prefabProjectile, GameHandler.Instance.activeInstDir.transform.position, shotRotation);
                projectile2.GetComponent<Rigidbody2D>().velocity = projectile2.transform.right * baseSpeed * rune.multSpeed;

                projectile2.AddComponent<Projectile_Joueur>();
                projectile2.GetComponent<Projectile_Joueur>().SetValues(
                    (baseDamage + rune.baseDamage),
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
                rune.Maitresse(projectile2);
                break;

            case "Tete Chercheuse":
                GameObject projectile3 = Instantiate(prefabProjectile, GameHandler.Instance.activeInstDir.transform.position, shotRotation);
                projectile3.GetComponent<Rigidbody2D>().velocity = projectile3.transform.right * baseSpeed * rune.multSpeed;

                projectile3.AddComponent<Projectile_Joueur>();
                projectile3.GetComponent<Projectile_Joueur>().SetValues(
                    (baseDamage + rune.baseDamage),
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
                rune.Maitresse(projectile3);
                break;

            case "Vitesse Rapide":
                GameObject projectile4 = Instantiate(prefabProjectile, GameHandler.Instance.activeInstDir.transform.position, shotRotation);
                projectile4.GetComponent<Rigidbody2D>().velocity = projectile4.transform.right * baseSpeed * rune.multSpeed;

                projectile4.AddComponent<Projectile_Joueur>();
                projectile4.GetComponent<Projectile_Joueur>().SetValues(
                    (baseDamage + rune.baseDamage),
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
                rune.Maitresse(projectile4);
                break;

            default:
                break;
        }
    }


    public void ProjectileCombo(string braceletName, Runes rune0)
    {
        var shotRotation = GameHandler.Instance.activeInstDir.transform.rotation;


        switch (braceletName)
        {
            case "Simple":
                GameObject projectile = Instantiate(prefabProjectile, GameHandler.Instance.activeInstDir.transform.position, shotRotation);
                projectile.GetComponent<Rigidbody2D>().velocity = projectile.transform.right * baseSpeed * rune0.multSpeed;

                projectile.AddComponent<Projectile_Joueur>();
                projectile.GetComponent<Projectile_Joueur>().SetValues(
                    (baseDamage + rune0.baseDamage),
                    rune0.baseKnockbak,
                    rune0.dotDamage,
                    rune0.dotDuration,
                    rune0.areaSize,
                    rune0.areaDamage,
                    rune0.areaDuration,
                    rune0.stuntDuration,
                    rune0.debuff,
                    rune0.debuffDuration,
                    rune0.slowDuration,
                    rune0.slowPower,
                    rune0.aoeSize,
                    rune0.aoeDamage,
                    rune0.secondEnemyDamage,
                    rune0.secondAoeSize,
                    rune0.secondAoeDamage,
                    rune0.delaySecondAoe,
                    rune0.explosionForce);

                rune0.Maitresse(projectile);
                break;

            case "3 Projectiles":
                for (int i = 0; i < 3; i++)
                {
                    shotRotation *= Quaternion.Euler(0, 0, angle);

                    GameObject projectile1 = Instantiate(prefabProjectile, GameHandler.Instance.activeInstDir.transform.position, shotRotation);
                    projectile1.GetComponent<Rigidbody2D>().velocity = projectile1.transform.right * baseSpeed * rune0.multSpeed;

                    projectile1.AddComponent<Projectile_Joueur>();
                    projectile1.GetComponent<Projectile_Joueur>().SetValues(
                        (baseDamage + rune0.baseDamage),
                        rune0.baseKnockbak,
                        rune0.dotDamage,
                        rune0.dotDuration,
                        rune0.areaSize,
                        rune0.areaDamage,
                        rune0.areaDuration,
                        rune0.stuntDuration,
                        rune0.debuff,
                        rune0.debuffDuration,
                        rune0.slowDuration,
                        rune0.slowPower,
                        rune0.aoeSize,
                        rune0.aoeDamage,
                        rune0.secondEnemyDamage,
                        rune0.secondAoeSize,
                        rune0.secondAoeDamage,
                        rune0.delaySecondAoe,
                        rune0.explosionForce);

                    rune0.Maitresse(projectile1);
                    angle += 15f;
                }

                
                break;

            case "Mitrailleuse":
                GameObject projectile2 = Instantiate(prefabProjectile, GameHandler.Instance.activeInstDir.transform.position, shotRotation);
                projectile2.GetComponent<Rigidbody2D>().velocity = projectile2.transform.right * baseSpeed * rune0.multSpeed;

                projectile2.AddComponent<Projectile_Joueur>();
                projectile2.GetComponent<Projectile_Joueur>().SetValues(
                    (baseDamage + rune0.baseDamage),
                    rune0.baseKnockbak,
                    rune0.dotDamage,
                    rune0.dotDuration,
                    rune0.areaSize,
                    rune0.areaDamage,
                    rune0.areaDuration,
                    rune0.stuntDuration,
                    rune0.debuff,
                    rune0.debuffDuration,
                    rune0.slowDuration,
                    rune0.slowPower,
                    rune0.aoeSize,
                    rune0.aoeDamage,
                    rune0.secondEnemyDamage,
                    rune0.secondAoeSize,
                    rune0.secondAoeDamage,
                    rune0.delaySecondAoe,
                    rune0.explosionForce);

                rune0.Maitresse(projectile2);
                break;

            case "Tete Chercheuse":
                GameObject projectile3 = Instantiate(prefabProjectile, GameHandler.Instance.activeInstDir.transform.position, shotRotation);
                projectile3.GetComponent<Rigidbody2D>().velocity = projectile3.transform.right * baseSpeed * rune0.multSpeed;


                projectile3.AddComponent<Projectile_Joueur>();
                projectile3.GetComponent<Projectile_Joueur>().SetValues(
                    (baseDamage + rune0.baseDamage),
                    rune0.baseKnockbak,
                    rune0.dotDamage,
                    rune0.dotDuration,
                    rune0.areaSize,
                    rune0.areaDamage,
                    rune0.areaDuration,
                    rune0.stuntDuration,
                    rune0.debuff,
                    rune0.debuffDuration,
                    rune0.slowDuration,
                    rune0.slowPower,
                    rune0.aoeSize,
                    rune0.aoeDamage,
                    rune0.secondEnemyDamage,
                    rune0.secondAoeSize,
                    rune0.secondAoeDamage,
                    rune0.delaySecondAoe,
                    rune0.explosionForce);

                rune0.Maitresse(projectile3);
                break;

            case "Vitesse Rapide":
                GameObject projectile4 = Instantiate(prefabProjectile, GameHandler.Instance.activeInstDir.transform.position, shotRotation);
                projectile4.GetComponent<Rigidbody2D>().velocity = projectile4.transform.right * baseSpeed * rune0.multSpeed;


                projectile4.AddComponent<Projectile_Joueur>();
                projectile4.GetComponent<Projectile_Joueur>().SetValues(
                    (baseDamage + rune0.baseDamage),
                    rune0.baseKnockbak,
                    rune0.dotDamage,
                    rune0.dotDuration,
                    rune0.areaSize,
                    rune0.areaDamage,
                    rune0.areaDuration,
                    rune0.stuntDuration,
                    rune0.debuff,
                    rune0.debuffDuration,
                    rune0.slowDuration,
                    rune0.slowPower,
                    rune0.aoeSize,
                    rune0.aoeDamage,
                    rune0.secondEnemyDamage,
                    rune0.secondAoeSize,
                    rune0.secondAoeDamage,
                    rune0.delaySecondAoe,
                    rune0.explosionForce);

                rune0.Maitresse(projectile4);
                break;

            default:
                break;
        }
    }

    public void ProjectileCombo(string braceletName, Runes rune0, Runes rune1)
    {
        var shotRotation = GameHandler.Instance.activeInstDir.transform.rotation;


        switch (braceletName)
        {
            case "Simple":
                GameObject projectile = Instantiate(prefabProjectile, GameHandler.Instance.activeInstDir.transform.position, shotRotation);
                projectile.GetComponent<Rigidbody2D>().velocity = projectile.transform.right * baseSpeed * rune0.multSpeed * rune1.multSpeed;


                projectile.AddComponent<Projectile_Joueur>();
                projectile.GetComponent<Projectile_Joueur>().SetValues(
                    (baseDamage + rune0.baseDamage) * rune1.multDamage,
                    rune0.baseKnockbak,
                    rune0.dotDamage,
                    rune0.dotDuration,
                    rune0.areaSize,
                    rune0.areaDamage,
                    rune0.areaDuration,
                    rune0.stuntDuration,
                    rune0.debuff,
                    rune0.debuffDuration,
                    rune0.slowDuration,
                    rune0.slowPower,
                    rune0.aoeSize,
                    rune0.aoeDamage,
                    rune0.secondEnemyDamage,
                    rune0.secondAoeSize,
                    rune0.secondAoeDamage,
                    rune0.delaySecondAoe,
                    rune0.explosionForce);

                rune0.Maitresse(projectile);
                rune1.Support(2, projectile);
                break;

            case "3 Projectiles":
                for (int i = 0; i < 3; i++)
                {
                    shotRotation *= Quaternion.Euler(0, 0, angle);

                    GameObject projectile1 = Instantiate(prefabProjectile, GameHandler.Instance.activeInstDir.transform.position, shotRotation);
                    projectile1.GetComponent<Rigidbody2D>().velocity = projectile1.transform.right * baseSpeed * rune0.multSpeed * rune1.multSpeed;

                    projectile1.AddComponent<Projectile_Joueur>();
                    projectile1.GetComponent<Projectile_Joueur>().SetValues(
                        (baseDamage + rune0.baseDamage) * rune1.multDamage,
                        rune0.baseKnockbak,
                        rune0.dotDamage,
                        rune0.dotDuration,
                        rune0.areaSize,
                        rune0.areaDamage,
                        rune0.areaDuration,
                        rune0.stuntDuration,
                        rune0.debuff,
                        rune0.debuffDuration,
                        rune0.slowDuration,
                        rune0.slowPower,
                        rune0.aoeSize,
                        rune0.aoeDamage,
                        rune0.secondEnemyDamage,
                        rune0.secondAoeSize,
                        rune0.secondAoeDamage,
                        rune0.delaySecondAoe,
                        rune0.explosionForce);

                    rune0.Maitresse(projectile1);
                    rune1.Support(2, projectile1);
                    angle += 15f;
                }
               
                break;

            case "Mitrailleuse":
                GameObject projectile2 = Instantiate(prefabProjectile, GameHandler.Instance.activeInstDir.transform.position, shotRotation);
                projectile2.GetComponent<Rigidbody2D>().velocity = projectile2.transform.right * baseSpeed * rune0.multSpeed * rune1.multSpeed;


                projectile2.AddComponent<Projectile_Joueur>();
                projectile2.GetComponent<Projectile_Joueur>().SetValues(
                    (baseDamage + rune0.baseDamage) * rune1.multDamage,
                    rune0.baseKnockbak,
                    rune0.dotDamage,
                    rune0.dotDuration,
                    rune0.areaSize,
                    rune0.areaDamage,
                    rune0.areaDuration,
                    rune0.stuntDuration,
                    rune0.debuff,
                    rune0.debuffDuration,
                    rune0.slowDuration,
                    rune0.slowPower,
                    rune0.aoeSize,
                    rune0.aoeDamage,
                    rune0.secondEnemyDamage,
                    rune0.secondAoeSize,
                    rune0.secondAoeDamage,
                    rune0.delaySecondAoe,
                    rune0.explosionForce);

                rune0.Maitresse(projectile2);
                rune1.Support(2, projectile2);
                break;

            case "Tete Chercheuse":
                GameObject projectile3 = Instantiate(prefabProjectile, GameHandler.Instance.activeInstDir.transform.position, shotRotation);
                projectile3.GetComponent<Rigidbody2D>().velocity = projectile3.transform.right * baseSpeed * rune0.multSpeed * rune1.multSpeed;


                projectile3.AddComponent<Projectile_Joueur>();
                projectile3.GetComponent<Projectile_Joueur>().SetValues(
                    (baseDamage + rune0.baseDamage) * rune1.multDamage,
                    rune0.baseKnockbak,
                    rune0.dotDamage,
                    rune0.dotDuration,
                    rune0.areaSize,
                    rune0.areaDamage,
                    rune0.areaDuration,
                    rune0.stuntDuration,
                    rune0.debuff,
                    rune0.debuffDuration,
                    rune0.slowDuration,
                    rune0.slowPower,
                    rune0.aoeSize,
                    rune0.aoeDamage,
                    rune0.secondEnemyDamage,
                    rune0.secondAoeSize,
                    rune0.secondAoeDamage,
                    rune0.delaySecondAoe,
                    rune0.explosionForce);

                rune0.Maitresse(projectile3);
                rune1.Support(2, projectile3);
                break;

            case "Vitesse Rapide":
                GameObject projectile4 = Instantiate(prefabProjectile, GameHandler.Instance.activeInstDir.transform.position, shotRotation);
                projectile4.GetComponent<Rigidbody2D>().velocity = projectile4.transform.right * baseSpeed * rune0.multSpeed * rune1.multSpeed;


                projectile4.AddComponent<Projectile_Joueur>();
                projectile4.GetComponent<Projectile_Joueur>().SetValues(
                    (baseDamage + rune0.baseDamage) * rune1.multDamage,
                    rune0.baseKnockbak,
                    rune0.dotDamage,
                    rune0.dotDuration,
                    rune0.areaSize,
                    rune0.areaDamage,
                    rune0.areaDuration,
                    rune0.stuntDuration,
                    rune0.debuff,
                    rune0.debuffDuration,
                    rune0.slowDuration,
                    rune0.slowPower,
                    rune0.aoeSize,
                    rune0.aoeDamage,
                    rune0.secondEnemyDamage,
                    rune0.secondAoeSize,
                    rune0.secondAoeDamage,
                    rune0.delaySecondAoe,
                    rune0.explosionForce);

                rune0.Maitresse(projectile4);
                rune1.Support(2, projectile4);
                break;

            default:
                break;
        }
    }

    public void ProjectileCombo(string braceletName, Runes rune0, Runes rune1, Runes rune2)
    {
        var shotRotation = GameHandler.Instance.activeInstDir.transform.rotation;

        switch (braceletName)
        {
            case "Simple":
                GameObject projectile = Instantiate(prefabProjectile, GameHandler.Instance.activeInstDir.transform.position, shotRotation);
                projectile.GetComponent<Rigidbody2D>().velocity = projectile.transform.right * baseSpeed * rune0.multSpeed * rune1.multSpeed * rune2.multSpeed;


                projectile.AddComponent<Projectile_Joueur>();
                projectile.GetComponent<Projectile_Joueur>().SetValues(
                    (baseDamage + rune0.baseDamage) * rune1.multDamage * rune2.multDamage,
                    rune0.baseKnockbak,
                    rune0.dotDamage,
                    rune0.dotDuration,
                    rune0.areaSize,
                    rune0.areaDamage,
                    rune0.areaDuration,
                    rune0.stuntDuration,
                    rune0.debuff,
                    rune0.debuffDuration,
                    rune0.slowDuration,
                    rune0.slowPower,
                    rune0.aoeSize,
                    rune0.aoeDamage,
                    rune0.secondEnemyDamage,
                    rune0.secondAoeSize,
                    rune0.secondAoeDamage,
                    rune0.delaySecondAoe,
                    rune0.explosionForce);

                rune0.Maitresse(projectile);
                rune1.Support(2, projectile);
                rune2.Support(3, projectile);
                break;

            case "3 Projectiles":
                for (int i = 0; i < 3; i++)
                {
                    shotRotation *= Quaternion.Euler(0, 0, angle);

                    GameObject projectile1 = Instantiate(prefabProjectile, GameHandler.Instance.activeInstDir.transform.position, shotRotation);
                    projectile1.GetComponent<Rigidbody2D>().velocity = projectile1.transform.right * baseSpeed * rune0.multSpeed * rune1.multSpeed * rune2.multSpeed;

                    projectile1.AddComponent<Projectile_Joueur>();
                    projectile1.GetComponent<Projectile_Joueur>().SetValues(
                        (baseDamage + rune0.baseDamage) * rune1.multDamage * rune2.multDamage,
                        rune0.baseKnockbak,
                        rune0.dotDamage,
                        rune0.dotDuration,
                        rune0.areaSize,
                        rune0.areaDamage,
                        rune0.areaDuration,
                        rune0.stuntDuration,
                        rune0.debuff,
                        rune0.debuffDuration,
                        rune0.slowDuration,
                        rune0.slowPower,
                        rune0.aoeSize,
                        rune0.aoeDamage,
                        rune0.secondEnemyDamage,
                        rune0.secondAoeSize,
                        rune0.secondAoeDamage,
                        rune0.delaySecondAoe,
                        rune0.explosionForce);

                    rune0.Maitresse(projectile1);
                    rune1.Support(2, projectile1);
                    rune2.Support(3, projectile1);
                    angle += 15f;
                }
                
                break;

            case "Mitrailleuse":
                GameObject projectile2 = Instantiate(prefabProjectile, GameHandler.Instance.activeInstDir.transform.position, shotRotation);
                projectile2.GetComponent<Rigidbody2D>().velocity = projectile2.transform.right * baseSpeed * rune0.multSpeed * rune1.multSpeed * rune2.multSpeed;


                projectile2.AddComponent<Projectile_Joueur>();
                projectile2.GetComponent<Projectile_Joueur>().SetValues(
                    (baseDamage + rune0.baseDamage) * rune1.multDamage * rune2.multDamage,
                    rune0.baseKnockbak,
                    rune0.dotDamage,
                    rune0.dotDuration,
                    rune0.areaSize,
                    rune0.areaDamage,
                    rune0.areaDuration,
                    rune0.stuntDuration,
                    rune0.debuff,
                    rune0.debuffDuration,
                    rune0.slowDuration,
                    rune0.slowPower,
                    rune0.aoeSize,
                    rune0.aoeDamage,
                    rune0.secondEnemyDamage,
                    rune0.secondAoeSize,
                    rune0.secondAoeDamage,
                    rune0.delaySecondAoe,
                    rune0.explosionForce);

                rune0.Maitresse(projectile2);
                rune1.Support(2, projectile2);
                rune2.Support(3, projectile2);
                break;

            case "Tete Chercheuse":
                GameObject projectile3 = Instantiate(prefabProjectile, GameHandler.Instance.activeInstDir.transform.position, shotRotation);
                projectile3.GetComponent<Rigidbody2D>().velocity = projectile3.transform.right * baseSpeed * rune0.multSpeed * rune1.multSpeed * rune2.multSpeed;


                projectile3.AddComponent<Projectile_Joueur>();
                projectile3.GetComponent<Projectile_Joueur>().SetValues(
                    (baseDamage + rune0.baseDamage) * rune1.multDamage * rune2.multDamage,
                    rune0.baseKnockbak,
                    rune0.dotDamage,
                    rune0.dotDuration,
                    rune0.areaSize,
                    rune0.areaDamage,
                    rune0.areaDuration,
                    rune0.stuntDuration,
                    rune0.debuff,
                    rune0.debuffDuration,
                    rune0.slowDuration,
                    rune0.slowPower,
                    rune0.aoeSize,
                    rune0.aoeDamage,
                    rune0.secondEnemyDamage,
                    rune0.secondAoeSize,
                    rune0.secondAoeDamage,
                    rune0.delaySecondAoe,
                    rune0.explosionForce);

                rune0.Maitresse(projectile3);
                rune1.Support(2, projectile3);
                rune2.Support(3, projectile3);
                break;

            case "Vitesse Rapide":
                GameObject projectile4 = Instantiate(prefabProjectile, GameHandler.Instance.activeInstDir.transform.position, shotRotation);
                projectile4.GetComponent<Rigidbody2D>().velocity = projectile4.transform.right * baseSpeed * rune0.multSpeed * rune1.multSpeed * rune2.multSpeed;


                projectile4.AddComponent<Projectile_Joueur>();
                projectile4.GetComponent<Projectile_Joueur>().SetValues(
                    (baseDamage + rune0.baseDamage) * rune1.multDamage * rune2.multDamage,
                    rune0.baseKnockbak,
                    rune0.dotDamage,
                    rune0.dotDuration,
                    rune0.areaSize,
                    rune0.areaDamage,
                    rune0.areaDuration,
                    rune0.stuntDuration,
                    rune0.debuff,
                    rune0.debuffDuration,
                    rune0.slowDuration,
                    rune0.slowPower,
                    rune0.aoeSize,
                    rune0.aoeDamage,
                    rune0.secondEnemyDamage,
                    rune0.secondAoeSize,
                    rune0.secondAoeDamage,
                    rune0.delaySecondAoe,
                    rune0.explosionForce);

                rune0.Maitresse(projectile4);
                rune1.Support(2, projectile4);
                rune2.Support(3, projectile4);
                break;

            default:
                break;
        }
    }

    public void ProjectileCombo(string braceletName, Runes rune0, Runes rune1, Runes rune2, Runes rune3)
    {
        var shotRotation = GameHandler.Instance.activeInstDir.transform.rotation;

        switch (braceletName)
        {
            case "Simple":
                GameObject projectile = Instantiate(prefabProjectile, GameHandler.Instance.activeInstDir.transform.position, shotRotation);
                projectile.GetComponent<Rigidbody2D>().velocity = projectile.transform.right * baseSpeed * rune0.multSpeed * rune1.multSpeed * rune2.multSpeed * rune3.multSpeed;


                projectile.AddComponent<Projectile_Joueur>();
                projectile.GetComponent<Projectile_Joueur>().SetValues(
                    (baseDamage + rune0.baseDamage) * rune1.multDamage * rune2.multDamage * rune3.multDamage,
                    rune0.baseKnockbak,
                    rune0.dotDamage,
                    rune0.dotDuration,
                    rune0.areaSize,
                    rune0.areaDamage,
                    rune0.areaDuration,
                    rune0.stuntDuration,
                    rune0.debuff,
                    rune0.debuffDuration,
                    rune0.slowDuration,
                    rune0.slowPower,
                    rune0.aoeSize,
                    rune0.aoeDamage,
                    rune0.secondEnemyDamage,
                    rune0.secondAoeSize,
                    rune0.secondAoeDamage,
                    rune0.delaySecondAoe,
                    rune0.explosionForce);

                rune0.Maitresse(projectile);
                rune1.Support(2, projectile);
                rune2.Support(3, projectile);
                rune3.Support(4, projectile);
                break;

            case "3 Projectiles":
                for (int i = 0; i < 3; i++)
                {
                    shotRotation *= Quaternion.Euler(0, 0, angle);

                    GameObject projectile1 = Instantiate(prefabProjectile, GameHandler.Instance.activeInstDir.transform.position, shotRotation);
                    projectile1.GetComponent<Rigidbody2D>().velocity = projectile1.transform.right * baseSpeed * rune0.multSpeed * rune1.multSpeed * rune2.multSpeed * rune3.multSpeed;

                    projectile1.AddComponent<Projectile_Joueur>();
                    projectile1.GetComponent<Projectile_Joueur>().SetValues(
                        (baseDamage + rune0.baseDamage) * rune1.multDamage * rune2.multDamage * rune3.multDamage,
                        rune0.baseKnockbak,
                        rune0.dotDamage,
                        rune0.dotDuration,
                        rune0.areaSize,
                        rune0.areaDamage,
                        rune0.areaDuration,
                        rune0.stuntDuration,
                        rune0.debuff,
                        rune0.debuffDuration,
                        rune0.slowDuration,
                        rune0.slowPower,
                        rune0.aoeSize,
                        rune0.aoeDamage,
                        rune0.secondEnemyDamage,
                        rune0.secondAoeSize,
                        rune0.secondAoeDamage,
                        rune0.delaySecondAoe,
                        rune0.explosionForce);

                    rune0.Maitresse(projectile1);
                    rune1.Support(2, projectile1);
                    rune2.Support(3, projectile1);
                    rune3.Support(4, projectile1);
                    angle += 15f;
                }
                
                break;

            case "Mitrailleuse":
                GameObject projectile2 = Instantiate(prefabProjectile, GameHandler.Instance.activeInstDir.transform.position, shotRotation);
                projectile2.GetComponent<Rigidbody2D>().velocity = projectile2.transform.right * baseSpeed * rune0.multSpeed * rune1.multSpeed * rune2.multSpeed * rune3.multSpeed;


                projectile2.AddComponent<Projectile_Joueur>();
                projectile2.GetComponent<Projectile_Joueur>().SetValues(
                    (baseDamage + rune0.baseDamage) * rune1.multDamage * rune2.multDamage * rune3.multDamage,
                    rune0.baseKnockbak,
                    rune0.dotDamage,
                    rune0.dotDuration,
                    rune0.areaSize,
                    rune0.areaDamage,
                    rune0.areaDuration,
                    rune0.stuntDuration,
                    rune0.debuff,
                    rune0.debuffDuration,
                    rune0.slowDuration,
                    rune0.slowPower,
                    rune0.aoeSize,
                    rune0.aoeDamage,
                    rune0.secondEnemyDamage,
                    rune0.secondAoeSize,
                    rune0.secondAoeDamage,
                    rune0.delaySecondAoe,
                    rune0.explosionForce);

                rune0.Maitresse(projectile2);
                rune1.Support(2, projectile2);
                rune2.Support(3, projectile2);
                rune3.Support(4, projectile2);
                break;

            case "Tete Chercheuse":
                GameObject projectile3 = Instantiate(prefabProjectile, GameHandler.Instance.activeInstDir.transform.position, shotRotation);
                projectile3.GetComponent<Rigidbody2D>().velocity = projectile3.transform.right * baseSpeed * rune0.multSpeed * rune1.multSpeed * rune2.multSpeed * rune3.multSpeed;


                projectile3.AddComponent<Projectile_Joueur>();
                projectile3.GetComponent<Projectile_Joueur>().SetValues(
                    (baseDamage + rune0.baseDamage) * rune1.multDamage * rune2.multDamage * rune3.multDamage,
                    rune0.baseKnockbak,
                    rune0.dotDamage,
                    rune0.dotDuration,
                    rune0.areaSize,
                    rune0.areaDamage,
                    rune0.areaDuration,
                    rune0.stuntDuration,
                    rune0.debuff,
                    rune0.debuffDuration,
                    rune0.slowDuration,
                    rune0.slowPower,
                    rune0.aoeSize,
                    rune0.aoeDamage,
                    rune0.secondEnemyDamage,
                    rune0.secondAoeSize,
                    rune0.secondAoeDamage,
                    rune0.delaySecondAoe,
                    rune0.explosionForce);

                rune0.Maitresse(projectile3);
                rune1.Support(2, projectile3);
                rune2.Support(3, projectile3);
                rune3.Support(4, projectile3);
                break;

            case "Vitesse Rapide":
                GameObject projectile4 = Instantiate(prefabProjectile, GameHandler.Instance.activeInstDir.transform.position, shotRotation);
                projectile4.GetComponent<Rigidbody2D>().velocity = projectile4.transform.right * baseSpeed * rune0.multSpeed * rune1.multSpeed * rune2.multSpeed * rune3.multSpeed;


                projectile4.AddComponent<Projectile_Joueur>();
                projectile4.GetComponent<Projectile_Joueur>().SetValues(
                    (baseDamage + rune0.baseDamage) * rune1.multDamage * rune2.multDamage * rune3.multDamage,
                    rune0.baseKnockbak,
                    rune0.dotDamage,
                    rune0.dotDuration,
                    rune0.areaSize,
                    rune0.areaDamage,
                    rune0.areaDuration,
                    rune0.stuntDuration,
                    rune0.debuff,
                    rune0.debuffDuration,
                    rune0.slowDuration,
                    rune0.slowPower,
                    rune0.aoeSize,
                    rune0.aoeDamage,
                    rune0.secondEnemyDamage,
                    rune0.secondAoeSize,
                    rune0.secondAoeDamage,
                    rune0.delaySecondAoe,
                    rune0.explosionForce);

                rune0.Maitresse(projectile4);
                rune1.Support(2, projectile4);
                rune2.Support(3, projectile4);
                rune3.Support(4, projectile4);
                break;

            default:
                break;
        }
    }
}
