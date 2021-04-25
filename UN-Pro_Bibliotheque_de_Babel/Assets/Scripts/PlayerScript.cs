using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;
using UnityEngine.SceneManagement;

public class PlayerScript : Entities
{

    public static PlayerScript Instance { get; private set; }

    [Header("Rewired Attributes")]
    [SerializeField] private int playerID = 0;
    public Player playerInputs;

    [Header("Run Counter")]
    public int nmbRun;

    [Header("PlayerLifesteal")]
    public bool lifeStealLvl1;
    public bool lifeStealLvl2;
    public bool lifeStealLvl3;

    public bool resurectCharge;
    public bool isDead = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        playerInputs = ReInput.players.GetPlayer(playerID);
        SetStartHealth();

        isImmune = false;
        resurectCharge = false;
        lifeStealLvl1 = false;
        lifeStealLvl2 = false;
        lifeStealLvl3 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            isDead = true;
            animator.Play("PlayerDead",0,0.25f);
        }
        if(currentHealth <= 0)
        {
            if(!resurectCharge)
            {
                Debug.LogWarning("Full Death");
                PlayerDied();
            } 
            else
            {
                Debug.LogWarning("ResurectCharge Used");
                currentHealth = maxHealth * 0.20f;
                StartCoroutine(ResurectPlayer());
                resurectCharge = false;

            }

        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
    }
    

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= SceneManager_sceneLoaded;
    }

    private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        isDead = false;
        animator.Play("WalkTree");
    }

    public IEnumerator SetSpawn()
    {
        yield return new WaitForSeconds(.1f);
        GameObject spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint");
        this.transform.position = spawnPoint.transform.position;
    }

    public IEnumerator BlockMove()
    {
        canMove = false;
        yield return new WaitForSeconds(5f);
        canMove = true;
    }

    public void ChangeMoveState()
    {
        canMove = !canMove;
    }


    public void PlayerDied()
    {
        foreach (GameObject item in GameObject.FindGameObjectsWithTag("Projectile"))
        {
            Destroy(item);
        }

        foreach (GameObject item in GameObject.FindGameObjectsWithTag("Ennemy"))
        {
            Destroy(item);
        }

        SoundManager.PlaySound(SoundManager.Sound.PlayerDie, transform.position);
        animator.Play("PlayerDead");

        SetStartHealth();
        GameHandler.Instance.RunEnded(false); 
    }
    public void PickedUpHeart()
    {
        currentHealth += 10;
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
    }

    public void PickedUpHeart(int i)
    {
        currentHealth += i;
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
    }

    private IEnumerator ResurectPlayer()
    {
        isImmune = true;
        canMove = false;
        healthBar.value = currentHealth;
        yield return new WaitForSeconds(0.75f);
        canMove = true;
        yield return new WaitForSeconds(1.25f);
        isImmune = false;
    }
}
