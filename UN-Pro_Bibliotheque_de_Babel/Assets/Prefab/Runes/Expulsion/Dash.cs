using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public bool canDash;

    public float dashForce;
    public float dashDuration;
    public float dashCooldown;

    public PlayerScript playerScript;
    public Rigidbody2D playerRb;
    public GameObject firepoint;

    // Start is called before the first frame update
    void Start()
    {
        canDash = false;

        StartCoroutine(LaunchDash(firepoint));
    }

    // Update is called once per frame
    void Update()
    {
        if(canDash == true)
        {
            StartCoroutine(LaunchDash(firepoint));
        }
    }

    public IEnumerator LaunchDash(GameObject dir)
    {
        

        yield return new WaitForEndOfFrame();

        canDash = false;

        playerScript.gameObject.GetComponent<SpriteRenderer>().color = Color.gray;
        playerScript.gameObject.layer = 11;
        playerScript.isImmune = true;

        yield return new WaitForSeconds(0.1f);

        playerRb.AddForce(new Vector2(dashForce * dir.transform.localPosition.x, dashForce * dir.transform.localPosition.y));

        yield return new WaitForSeconds(0.25f);

        playerScript.isImmune = false;
        playerScript.gameObject.layer = 7;
        playerScript.gameObject.GetComponent<SpriteRenderer>().color = Color.white;

        if (GameObject.FindGameObjectWithTag("ForceField") != null)
            Destroy(GameObject.FindGameObjectWithTag("ForceField"));

        canDash = true;

    }
}
