using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Empalement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            if (collision.gameObject.tag != "Player1")
            {
                collision.gameObject.transform.localScale = new Vector3(2, 2, 2);
                //collision.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            }
        }
    }
}
