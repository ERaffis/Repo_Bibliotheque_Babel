using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TargetDummy : MonoBehaviour
{
    public SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public IEnumerator DamageoverTime(float dmg, float ticks)
    {
        yield return new WaitForSeconds(1f);

        if (transform.childCount < 3)
        {
            for (int i = 0; i <= ticks; i++)
            {
                TargetDamage(dmg);
                yield return new WaitForSeconds(0.5f);
            }
        }
        
       
    }

    public void TargetDamage(float dmg)
    {
        DamagePopup.Create(GetPosition(), (int)dmg);
        StartCoroutine(FlashRed());

        if (SceneManager.GetActiveScene().name == "HUB_Didacticiel" && dmg > 20)
            GameObject.Find("ScriptDidacticiel").GetComponent<Didacticiel>().a++;
    }

    public Vector3 GetPosition()
    {
        return transform.position + new Vector3(0,1.5f);
    }

    public IEnumerator FlashRed()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.white;
    }
}
