using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilSpill : MonoBehaviour
{
    public GameObject fireAnimation;
    public bool isOnFire = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("HalfCollider") && !isOnFire)
        {
            collision.transform.parent.GetComponent<PlayerScript>().ChangeMoveState();
            collision.transform.parent.GetComponent<Rigidbody2D>().drag = 0;
        }

        if (collision.gameObject.CompareTag("Projectile") && !isOnFire)
        {
            if (collision.TryGetComponent(out Embrasement_Maitresse var))
            {
                Debug.Log("Light Spill");

                Instantiate(fireAnimation, transform);
                isOnFire = true;
                Destroy(collision.gameObject);
            }
        }

        if (collision.gameObject.CompareTag("Projectile") && isOnFire)
        {
            if (collision.TryGetComponent(out Givre_Maitresse var))
            {
                Destroy(transform.GetChild(0).gameObject);
                isOnFire = false;
                Destroy(collision.gameObject);
            }
        }

        if (collision.gameObject.CompareTag("HalfCollider") && isOnFire)
        {
            StartCoroutine(DamgePlayer(collision));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("HalfCollider"))
        {
            if(!isOnFire)
            {
                collision.transform.parent.GetComponent<PlayerScript>().ChangeMoveState();
                collision.transform.parent.GetComponent<Rigidbody2D>().drag = 10;
            }
            StopAllCoroutines();
        }
    }


    IEnumerator DamgePlayer(Collider2D collision)
    {
        collision.transform.parent.GetComponent<PlayerScript>().SetPlayerHealth(Random.Range(2,8));
        yield return new WaitForSeconds(1f);
        collision.transform.parent.GetComponent<PlayerScript>().SetPlayerHealth(Random.Range(2, 8));
        yield return new WaitForSeconds(1f);
        collision.transform.parent.GetComponent<PlayerScript>().SetPlayerHealth(Random.Range(2, 8));
        yield return new WaitForSeconds(1f);
        collision.transform.parent.GetComponent<PlayerScript>().SetPlayerHealth(Random.Range(2, 8));
        yield return new WaitForSeconds(1f);
        collision.transform.parent.GetComponent<PlayerScript>().SetPlayerHealth(Random.Range(2, 8));
        yield return new WaitForSeconds(1f);
        collision.transform.parent.GetComponent<PlayerScript>().SetPlayerHealth(Random.Range(2, 8));
        yield return new WaitForSeconds(1f);
        collision.transform.parent.GetComponent<PlayerScript>().SetPlayerHealth(Random.Range(2, 8));
        yield return new WaitForSeconds(1f);
        collision.transform.parent.GetComponent<PlayerScript>().SetPlayerHealth(Random.Range(2, 8));

    }
}
