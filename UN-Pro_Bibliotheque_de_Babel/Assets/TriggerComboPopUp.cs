using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerComboPopUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(GameObject.Find("ScriptDidacticiel").GetComponent<Didacticiel>().w != 0)
        {
            GameObject.Find("ScriptDidacticiel").GetComponent<Didacticiel>().howToCombo.SetActive(true);
            Destroy(gameObject);

            ArrowPointer.Instance.shouldPoint = false;
        }
    }
}
