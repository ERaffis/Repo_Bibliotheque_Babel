using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Joueur : MonoBehaviour
{
    public float damage;
    public float knockback;
    public int dotDamage;
    public int dotDuration;
    public float areaSize;
    public int areaDamage;
    public float areaDuration;
    public int stuntDuration;
    public float debuff;
    public int debuffDuration;
    public int slowDuration;
    public float slowPower;
    public float aoeSize;
    public int aoeDamage;
    public float secondEnemyDamage;
    public float secondAoeSize;
    public int secondAoeDamage;
    public float delaySecondAoe;
    public float explosionForce;
    public int nmbProjectileExplosion;

    public void SetValues(float damage, float knockback, int dotDamage, int dotDuration, float areaSize, int areaDamage, float areaDuration, int stuntDuration, float debuff, int debuffDuration, int slowDuration, float slowPower, float aoeSize, int aoeDamage, float secondEnemyDamage, float secondAoeSize, int secondAoeDamage, float delaySecondAoe, float explosionForce, int nmbProjectileExplosion)
    {
        this.damage = damage;
        this.knockback = knockback;
        this.dotDamage = dotDamage;
        this.dotDuration = dotDuration;
        this.areaSize = areaSize;
        this.areaDamage = areaDamage;
        this.areaDuration = areaDuration;
        this.stuntDuration = stuntDuration;
        this.debuff = debuff;
        this.debuffDuration = debuffDuration;
        this.slowDuration = slowDuration;
        this.slowPower = slowPower;
        this.aoeSize = aoeSize;
        this.aoeDamage = aoeDamage;
        this.secondEnemyDamage = secondEnemyDamage;
        this.secondAoeSize = secondAoeSize;
        this.secondAoeDamage = secondAoeDamage;
        this.delaySecondAoe = delaySecondAoe;
        this.explosionForce = explosionForce;
        this.nmbProjectileExplosion = nmbProjectileExplosion;

        GetComponent<PointEffector2D>().forceMagnitude = this.knockback * 20;
    }

    public void SetKnockback(float value)
    {
        GetComponent<PointEffector2D>().forceMagnitude = value * 20;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9)
            StartCoroutine(ExplodeProjectile());
    }


    IEnumerator ExplodeProjectile()
    {
        yield return new WaitForSeconds(0.01f);
        Destroy(gameObject);
    }
}
