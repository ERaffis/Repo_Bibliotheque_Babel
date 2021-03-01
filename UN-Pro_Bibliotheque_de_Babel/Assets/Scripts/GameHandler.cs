using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public GameObject mainCam;
    public GameObject eventSystem;


    private void Awake()
    {
        SoundManager.Initialize();
        mainCam = GameObject.Find("Main Camera");
        eventSystem = GameObject.Find("EventSystem");

        DontDestroyOnLoad(mainCam);
        DontDestroyOnLoad(eventSystem);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
