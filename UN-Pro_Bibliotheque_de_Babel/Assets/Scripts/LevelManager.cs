using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public Animator animator;

    [Header("Class Relations")]
    public RoomNumberManager numberManager;
    public PlayerScript playerScript;

    private int levelToLoad;

    private void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void FadeToLevel(int levelIndex)
    {
        StartCoroutine(playerScript.BlockMove());
        StartCoroutine(numberManager.WriteNumber(numberManager.levelNumber + numberManager.roomNumber));
        animator.SetTrigger("FadeOut");
        levelToLoad = levelIndex;
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
