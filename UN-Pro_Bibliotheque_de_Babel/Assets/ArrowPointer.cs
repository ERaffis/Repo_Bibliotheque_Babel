using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using UnityEngine.SceneManagement;

public class ArrowPointer : MonoBehaviour
{
    public static ArrowPointer Instance { get; private set; }

    [SerializeField] private Camera _Camera;
    public Vector3 targetPosition;
    [SerializeField] private RectTransform pointerRectTransform;

    public bool shouldPoint;
    private Canvas _Canvas;
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

        targetPosition = GameObject.Find("TriggerSortie").transform.position;
        pointerRectTransform = GameObject.Find("IndicationArrow").GetComponent<RectTransform>();
        _Camera = Camera.main;
        _Canvas = GetComponent<Canvas>();
        _Canvas.worldCamera = Camera.main;
        shouldPoint = false;
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
        targetPosition = GameObject.Find("TriggerSortie").transform.position;
        _Camera = Camera.main;
        _Canvas = GetComponent<Canvas>();
        _Canvas.worldCamera = Camera.main;
        shouldPoint = false;
    }

    private void Update()
    {
        if (Inventory.Instance.activeBracelet != null && SceneManager.GetActiveScene().name == "HUB_Principal")
            shouldPoint = true;

        if (shouldPoint)
        {
            float borderSizeX;
            float borderSizeY;

            if (SceneManager.GetActiveScene().name == "HUB_Didacticiel")
            {
                borderSizeX = 450f;
                borderSizeY = 100f;
            } else
            {
                borderSizeX = 100f;
                borderSizeY = 100f;
            }
            
            Vector3 targetPositionScreenPoint = Camera.main.WorldToScreenPoint(targetPosition);
            bool isOffScreen = targetPositionScreenPoint.x <= borderSizeX || targetPositionScreenPoint.x >= Screen.width - borderSizeX || targetPositionScreenPoint.y <= borderSizeY || targetPositionScreenPoint.y >= Screen.height - borderSizeY;

            if (isOffScreen)
            {
                pointerRectTransform.gameObject.SetActive(true);
                RotatePointerTowardsTargetPosition();
                Vector3 cappedTargetScreenPostion = targetPositionScreenPoint;
                if (cappedTargetScreenPostion.x <= borderSizeX) cappedTargetScreenPostion.x = borderSizeX;
                if (cappedTargetScreenPostion.x >= Screen.width - borderSizeX) cappedTargetScreenPostion.x = Screen.width - borderSizeX;
                if (cappedTargetScreenPostion.y <= borderSizeY) cappedTargetScreenPostion.y = borderSizeY;
                if (cappedTargetScreenPostion.y >= Screen.height - borderSizeY) cappedTargetScreenPostion.y = Screen.height - borderSizeY;

                Vector3 pointerWorldPosition = _Camera.ScreenToWorldPoint(cappedTargetScreenPostion);
                pointerRectTransform.position = pointerWorldPosition;
                pointerRectTransform.localPosition = new Vector3(pointerRectTransform.localPosition.x, pointerRectTransform.localPosition.y, 0f);
            }
            else
            {
                pointerRectTransform.gameObject.SetActive(false);
            }
        } else
        {
            pointerRectTransform.gameObject.SetActive(false);
        }
        
    }



    private void RotatePointerTowardsTargetPosition()
    {
        Vector3 toPosition = targetPosition;
        Vector3 fromPosition = Camera.main.transform.position;
        fromPosition.z = 0f;
        Vector3 dir = (toPosition - fromPosition).normalized;
        //float angle = UtilsClass.GetAngleFromVectorFloat(dir);
        float angle = (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg) % 360;
        pointerRectTransform.localEulerAngles = new Vector3(0, 0, angle - 90);
    }
}
