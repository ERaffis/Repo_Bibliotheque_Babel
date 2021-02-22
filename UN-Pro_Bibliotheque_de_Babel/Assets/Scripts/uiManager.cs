using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class uiManager : MonoBehaviour
{

    public Canvas ui;
    public Image dashIcon;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator UpdateDash(float duration)
    {
        dashIcon.color = new Color(dashIcon.color.r, dashIcon.color.g, dashIcon.color.b, 0);
        float alpha = dashIcon.color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / duration)
        {
            Color newColor = new Color(dashIcon.color.r, dashIcon.color.g, dashIcon.color.b, Mathf.Lerp(alpha, 1, t));
            dashIcon.color = newColor;
            yield return null;
        }
    }
}
