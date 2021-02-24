using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public Animator animator;

    public RoomNumberManager numberManager;

    private int levelToLoad;

    private void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            StartCoroutine(numberManager.WriteNumber(numberManager.levelNumber + numberManager.roomNumber));
            if (levelToLoad == 0) FadeToLevel(3);
            if (levelToLoad == 3) FadeToLevel(2);
            if (levelToLoad == 2) FadeToLevel(3);
        }
    }

    public void FadeToLevel(int levelIndex)
    {
        animator.SetTrigger("FadeOut");
        levelToLoad = levelIndex;
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
