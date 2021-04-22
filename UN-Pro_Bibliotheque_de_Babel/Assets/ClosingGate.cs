using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosingGate : MonoBehaviour
{

    public Animator gateAnimator;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player1"))
        {
            gateAnimator.Play("AppearAnimTop");
        }
    }
}
