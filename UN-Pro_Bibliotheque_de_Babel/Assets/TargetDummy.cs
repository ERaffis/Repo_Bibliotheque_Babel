using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDummy : MonoBehaviour
{
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
        for (int i = 0; i <= ticks; i++)
        {
            TargetDamage(dmg);
            yield return new WaitForSeconds(0.5f);
        }
       
    }

    public void TargetDamage(float dmg)
    {
        DamagePopup.Create(GetPosition(), (int)dmg);
    }

    public Vector3 GetPosition()
    {
        return transform.position + new Vector3(0,1.5f);
    }
}
