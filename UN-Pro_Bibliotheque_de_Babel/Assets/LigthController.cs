using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LigthController : MonoBehaviour
{
    public Light2D[] lightComponent;
    WaitForSeconds timer;
    bool isTwitch;
    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("ChangeIntensity", 2f, 2.5f);
        timer = new WaitForSeconds(3f);
        isTwitch = false;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float rdm = Random.Range(0, 100);
        if (rdm > 90 && !isTwitch) StartCoroutine(ChangeIntensity());
    }

    IEnumerator ChangeIntensity()
    {
        isTwitch = true;


        foreach (Light2D light in lightComponent)
        {
            light.intensity = Random.Range(light.intensity - 0.25f, light.intensity + 0.25f);
            yield return new WaitForSeconds(0.2f);

            light.intensity = Random.Range(light.intensity - 0.25f, light.intensity + 0.25f);
            yield return new WaitForSeconds(0.25f);

            light.intensity = Random.Range(light.intensity - 0.25f, light.intensity + 0.25f);
            yield return new WaitForSeconds(0.05f);

            light.intensity = Random.Range(light.intensity - 0.25f, light.intensity + 0.25f);
            yield return new WaitForSeconds(0.1f);

            light.intensity = Random.Range(light.intensity - 0.25f, light.intensity + 0.25f);
            yield return new WaitForSeconds(0.35f);

            light.intensity = Random.Range(light.intensity - 0.25f, light.intensity + 0.25f);
        }
        yield return new WaitForSeconds(1f);

        isTwitch = false;
    }
}
