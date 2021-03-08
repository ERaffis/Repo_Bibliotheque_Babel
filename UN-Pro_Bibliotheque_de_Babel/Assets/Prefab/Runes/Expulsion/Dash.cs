using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public bool canDash;

    public float dashForce;
    public float dashDuration;
    public float dashCooldown;

    public bool shouldDestroy;

    public PlayerScript playerScript;
    public Rigidbody2D playerRb;
    public GameObject firepoint;

    // Start is called before the first frame update
    void Start()
    {
        canDash = false;
        shouldDestroy = true;

        StartCoroutine(LaunchDash(firepoint));
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player1"))
        {
            if (collision.gameObject.layer == 6)
            {
                if (collision.gameObject.transform.childCount <= 3)
                {
                    shouldDestroy = false;
                    StartCoroutine(DisableProjectile());
                }
            }
        }
    }

    IEnumerator DisableProjectile()
    {

        if (TryGetComponent(out Collider2D a))
            Destroy(a);
        if (TryGetComponent(out Collider2D b))
            Destroy(b);

        yield return new WaitForSeconds(.2f);

        if (TryGetComponent(out Effector2D c))
            Destroy(c);

        yield return new WaitForSeconds(1.5f);

        if (GameObject.FindGameObjectWithTag("ForceField") != null)
            Destroy(GameObject.FindGameObjectWithTag("ForceField"));
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

        if (GameObject.FindGameObjectWithTag("ForceField") != null && shouldDestroy)
            Destroy(GameObject.FindGameObjectWithTag("ForceField"));
        else StartCoroutine(DisableProjectile());

        canDash = true;

    }
}
