using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class ArrowPointer : MonoBehaviour
{
    [SerializeField] private Camera uiCamera;
    public Vector3 targetPosition;
    private RectTransform pointerRectTransform;
    public bool shouldPoint;
    private void Awake()
    {
        targetPosition = GameObject.Find("TriggerSortie").transform.position;
        pointerRectTransform = transform.Find("IndicationArrow").GetComponent<RectTransform>();
        shouldPoint = false;
    }

    private void Update()
    {
        if (shouldPoint)
        {
            float borderSize = 100f;
            Vector3 targetPositionScreenPoint = Camera.main.WorldToScreenPoint(targetPosition);
            bool isOffScreen = targetPositionScreenPoint.x <= borderSize || targetPositionScreenPoint.x >= Screen.width - borderSize || targetPositionScreenPoint.y <= borderSize || targetPositionScreenPoint.y >= Screen.height - borderSize;

            if (isOffScreen)
            {
                transform.Find("IndicationArrow").gameObject.SetActive(true);
                RotatePointerTowardsTargetPosition();
                Vector3 cappedTargetScreenPostion = targetPositionScreenPoint;
                if (cappedTargetScreenPostion.x <= borderSize) cappedTargetScreenPostion.x = borderSize;
                if (cappedTargetScreenPostion.x >= Screen.width - borderSize) cappedTargetScreenPostion.x = Screen.width - borderSize;
                if (cappedTargetScreenPostion.y <= borderSize) cappedTargetScreenPostion.y = borderSize;
                if (cappedTargetScreenPostion.y >= Screen.height - borderSize) cappedTargetScreenPostion.y = Screen.height - borderSize;

                Vector3 pointerWorldPosition = uiCamera.ScreenToWorldPoint(cappedTargetScreenPostion);
                pointerRectTransform.position = pointerWorldPosition;
                pointerRectTransform.localPosition = new Vector3(pointerRectTransform.localPosition.x, pointerRectTransform.localPosition.y, 0f);
            }
            else
            {
                transform.Find("IndicationArrow").gameObject.SetActive(false);

                /*
                Vector3 pointerWorldPosition = uiCamera.ScreenToWorldPoint(targetPositionScreenPoint);
                pointerRectTransform.position = pointerWorldPosition;
                pointerRectTransform.localPosition = new Vector3(pointerRectTransform.localPosition.x, pointerRectTransform.localPosition.y, 0f);
                */
            }
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
