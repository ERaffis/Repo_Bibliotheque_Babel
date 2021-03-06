using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class RoomNumberManager : MonoBehaviour
{
    public TMP_Text roomNumberText;
    public string roomNumber;
    public int roomNumberINT;
    public string levelNumber;
    public int levelNumberINT;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        GenerateNumbers();
    }

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.O)) PlusLevelNumber();
        if (Input.GetKeyDown(KeyCode.L)) PlusRoomNumber();
    }

    public void GenerateNumbers()
    {
        levelNumberINT = (Random.Range(0, 9)*1000) + (Random.Range(0, 9)*100) + (Random.Range(0, 9)*10) + Random.Range(0, 9);
        levelNumber = "" + levelNumberINT;

        roomNumberINT = (Random.Range(0, 9) * 10000) + (Random.Range(0, 9) * 1000) + (Random.Range(0, 9) * 100) + (Random.Range(0, 9) * 10) + Random.Range(0, 9);
        roomNumber = "." + roomNumberINT; 
    }

    public void PlusLevelNumber()
    {
        levelNumberINT += 1;
        levelNumber = "" + levelNumberINT;
    }

    public void PlusRoomNumber()
    {
        roomNumberINT += 1;
        roomNumber = "." + roomNumberINT;
    }

    public IEnumerator WriteNumber(string number)
    {
        roomNumberText.gameObject.SetActive(true);
        roomNumberText.text = null;
        yield return new WaitForSeconds(1f);

        for (int i = 0; i < number.Length; i++)
        {
            roomNumberText.text += number[i];
            SoundManager.PlaySound(SoundManager.Sound.TypeWriter);
            yield return new WaitForSeconds(0.20f) ;
        }

        yield return new WaitForSeconds(.25f);

        SoundManager.PlaySound(SoundManager.Sound.TypeWriterEnd);

        yield return new WaitForSeconds(.5f);
        roomNumberText.text = null;
        roomNumberText.gameObject.SetActive(false);
        
    }
}
