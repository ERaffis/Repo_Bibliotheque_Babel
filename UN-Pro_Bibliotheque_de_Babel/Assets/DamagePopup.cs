using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamagePopup : MonoBehaviour
{
    private TextMeshPro textMesh;
    private float disappearTimer;
    private Color textColor;
    private Vector3 moveVector;

    private static int sortingOrder;

    private const float DISAPPEAR_TIMER_MAX = 1f;
    
    public static DamagePopup Create(Vector3 position, int damageAmount)
    {
        Transform damagePopupTransform = Instantiate(GameAssets.i.pfDamagePopup, position, Quaternion.identity);

        DamagePopup damagePopup = damagePopupTransform.GetComponent<DamagePopup>();
        damagePopup.Setup(damageAmount);

        return damagePopup;
    }
    
    private void Awake()
    {
        textMesh = transform.GetComponent<TextMeshPro>();
    }
    public void Setup(int damageAmount)
    {
        textMesh.SetText(damageAmount.ToString());

        textColor = textMesh.color;

        disappearTimer = 1f;
        disappearTimer = DISAPPEAR_TIMER_MAX;

        moveVector = new Vector3(Random.Range(-0.1f,0.1f), .5f) * 10f;

        sortingOrder++;
        textMesh.sortingOrder = sortingOrder;
    }

    private void Update()
    {
        transform.position += moveVector * Time.unscaledDeltaTime;
        moveVector -= moveVector * 8f * Time.unscaledDeltaTime;

        if (disappearTimer > DISAPPEAR_TIMER_MAX * 0.5f)
        {
            //FirstHalf
            float increaseScaleAmount = .25f;
            transform.localScale += Vector3.one * increaseScaleAmount * Time.unscaledDeltaTime;
        }
        else
        {
            float decreaseScaleAmount = .25f;
            transform.localScale -= Vector3.one * decreaseScaleAmount * Time.unscaledDeltaTime;

        }

        disappearTimer -= Time.deltaTime;
        if (disappearTimer < 0)
        {
            //Start disappearing

            float disappearSpeed = 3f;
            textColor.a -= disappearSpeed * Time.unscaledDeltaTime;
            textMesh.color = textColor;
            if (textColor.a <-0)
            {
                Destroy(gameObject);
            }
        }
    }
}
