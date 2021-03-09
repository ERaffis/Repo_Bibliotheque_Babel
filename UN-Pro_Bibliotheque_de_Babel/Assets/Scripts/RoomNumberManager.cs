using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class RoomNumberManager : MonoBehaviour
{
    public static RoomNumberManager Instance { get; private set; }


    public TMP_Text roomNumberText;
    public int roomNumber;
    public int levelNumber;

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

    private void Start()
    {
        GenerateNumbers();
    }

    private void Update()
    {
        
    }

    public void GenerateNumbers()
    {
        levelNumber = (Random.Range(0, 9)*1000) + (Random.Range(0, 9)*100) + (Random.Range(0, 9)*10) + Random.Range(0, 9);

        roomNumber = (Random.Range(0, 9) * 10000) + (Random.Range(0, 9) * 1000) + (Random.Range(0, 9) * 100) + (Random.Range(0, 9) * 10) + Random.Range(0, 9);
    }

    public void PlusLevelNumber()
    {
        levelNumber += 1;

    }

    public void PlusRoomNumber()
    {
        roomNumber += 1;
    }

    public IEnumerator WriteNumber()
    {
        roomNumberText.gameObject.SetActive(true);
        roomNumberText.text = null;

        string number = levelNumber.ToString() + "." + roomNumber.ToString();

        yield return new WaitForSeconds(1f);

        for (int i = 0; i < number.Length; i++)
        {
            roomNumberText.text += number[i];
            SoundManager.PlaySound(SoundManager.Sound.TypeWriter);
            yield return new WaitForSeconds(0.25f);
        }

        yield return new WaitForSeconds(.25f);

        SoundManager.PlaySound(SoundManager.Sound.TypeWriterEnd);

        yield return new WaitForSeconds(.5f);
        roomNumberText.text = null;
        roomNumberText.gameObject.SetActive(false);
        
    }

    public IEnumerator WriteTrial(string number)
    {
        roomNumberText.gameObject.SetActive(true);
        roomNumberText.text = null;
        yield return new WaitForSeconds(1f);

        for (int i = 0; i < number.Length; i++)
        {
            roomNumberText.text += number[i];
            SoundManager.PlaySound(SoundManager.Sound.TypeWriter);
            yield return new WaitForSeconds(0.20f);
        }

        yield return new WaitForSeconds(.25f);
        SoundManager.PlaySound(SoundManager.Sound.TypeWriterEnd);

        yield return new WaitForSeconds(.5f);
        roomNumberText.text = null;
        roomNumberText.gameObject.SetActive(false);
    }
}
