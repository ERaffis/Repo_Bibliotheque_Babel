using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler
{
    [Header("Tooltip Information")]
    public string header;
    [Multiline()]
    public string content;

    private static LTDescr delay;

    public void OnPointerEnter(PointerEventData eventData)
    {
        //delay = LeanTween.delayedCall(0.5f, () =>
        //{
            TooltipSystem.Show(transform.position, content, header);
        //});
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //LeanTween.cancel(delay.uniqueId);
        TooltipSystem.Hide();
    }

    public void OnMouseEnter()
    {
        //delay = LeanTween.delayedCall(0.5f, () =>
        //{
            TooltipSystem.Show(transform.position, content, header);
        //});
    }

    public void OnMouseExit()
    {
        //LeanTween.cancel(delay.uniqueId);
        TooltipSystem.Hide();
    }

    public void OnSelect(BaseEventData eventData)
    {
        //delay = LeanTween.delayedCall(0.5f, () =>
        //
            TooltipSystem.Show(transform.position, content, header);
        //});
    }

    public void OnDeselect(BaseEventData eventData)
    {
        //LeanTween.cancel(delay.uniqueId);
        TooltipSystem.Hide();
    }

}
