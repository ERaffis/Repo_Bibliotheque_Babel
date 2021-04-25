using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Rigidbody2D))]
public class Entities : MonoBehaviour
{

    [Header("Basic Info")]
    public string entityName;
    public int maxHealth;
    public float currentHealth;
    public float moveSpeed;
    public int animationIndex;

    [Header("Components")]
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    public Rigidbody2D rb;

    [Header("IsTakingDamage")]
    public bool isTakingDamage;

    [Header("Effects")]
    public bool canMove = true;
    public bool isStuned;
    public bool isRooted; 
    public float weakness;

    [Header("Immunity")]
    public bool isImmune;

    [Header("Health Bar")]
    public Slider healthBar;

    [Header("Type of entity")]
    public string entityType;

    public GameObject bloodParticles;

    

    // Start is called before the first frame update
    void Start()
    {
        SetStartHealth();
        //StartCoroutine(WaitToMoveStart());
        weakness = 1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckHealth();
    }

    public void SetHealth(float dmg)
    {
        if(!isImmune)
        {
            currentHealth -= dmg * weakness;
            DamagePopup.Create(GetPosition(), (int) dmg);
            StartCoroutine(FlashRed());
        }
    }
    public IEnumerator FlashRed()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = Color.white;
    }

    public void SetPlayerHealth(int dmg)
    {
        if (!isImmune)
        {
            currentHealth -= dmg;
            GameObject bloodSplat = Instantiate(bloodParticles, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -0.15f), Quaternion.identity);
            bloodSplat.transform.parent = null;
        }
    }

    protected void SetStartHealth()
    {
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = maxHealth;
        
    }
    void CheckHealth()
    {
        if(healthBar!=null)
            healthBar.value = currentHealth;

        if (currentHealth <= 0 && !this.gameObject.CompareTag("Player1") && !gameObject.CompareTag("Tour"))
        {
            if(PlayerScript.Instance.lifeStealLvl1)
            {
                PlayerScript.Instance.PickedUpHeart();

                if(PlayerScript.Instance.lifeStealLvl2)
                {
                    PlayerScript.Instance.PickedUpHeart();

                    if (PlayerScript.Instance.lifeStealLvl3)
                    {
                        PlayerScript.Instance.PickedUpHeart();
                    }
                }
            }

            GameHandler.Instance.nmbRemaining--;
            SpawnReward.Instance.SpawnItem(gameObject.transform.position, this.gameObject.tag);
            SoundManager.PlaySound(SoundManager.Sound.EnemyDie, transform.position);
            Destroy(this.gameObject);
        }
    }

    public void SetMovement()
    {
        canMove = !canMove;
    }
    public void SetMaxHealth(int Health)
    {
        healthBar.maxValue = Health;
        healthBar.value = Health;
        maxHealth = Health;
        currentHealth = maxHealth;
    }

    protected IEnumerator WaitToMoveStart()
    {
        canMove = false;
        yield return new WaitForSeconds(0.25f);
        canMove = true;
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public IEnumerator WeakenEnemy(float val, float time)
    {
        weakness = val;
        Debug.Log("Weakend for " + time);
        yield return new WaitForSeconds(time);
        weakness = 1;
        Debug.Log("Unweakend");
    }
    public IEnumerator StunEnnemy(float time)
    {
        isStuned = true;
        Debug.Log("Stunned for " + time);

        yield return new WaitForSeconds(time);

        isStuned = false;
        Debug.Log("Unstunned");

    }

    public IEnumerator SlowEnnemy(float val, float time)
    {
        float previousMS = moveSpeed;
        moveSpeed = val;
        yield return new WaitForSeconds(time);
        moveSpeed = previousMS;
    }

    public IEnumerator DamageoverTime(float dmg, float ticks)
    {
        yield return new WaitForSeconds(1f);
        if (!isTakingDamage)
        {
           isTakingDamage = true;
            for (int i = 0; i <= ticks; i++)
            {
                SetHealth(dmg);
                yield return new WaitForSeconds(0.5f);
            }
            isTakingDamage = false;
        }
    }

    public void InstantiateNewProjectile(int nmbProj, GameObject projectile)
    {
        for (int i = 0; i < nmbProj; i++)
        {
            GameObject newProjectile = Instantiate(projectile, transform.position + Vector3.up * 1.25f, new Quaternion(0, 0, 0, 0));
            newProjectile.transform.RotateAround(transform.position, Vector3.forward, 360 / nmbProj * i);
            Destroy(newProjectile.GetComponent<Explosion_Support>());
            newProjectile.GetComponent<Rigidbody2D>().velocity = newProjectile.transform.right * GetComponent<Rigidbody2D>().velocity;
        }
    }

    public IEnumerator AoEEffect(Vector3 position, float dotDuration, float dotDamage)
    {
        int i = 0;
        while (i < dotDuration)
        {
            Collider[] hitColliders = Physics.OverlapSphere(position, 1.65f);
            int j = 0;
            while (j < hitColliders.Length)
            {
                hitColliders[j].GetComponent<Entities>().SetHealth(dotDamage);
                j++;
            }
            i++;

            yield return new WaitForSeconds(.2f);
        }
    }
}
