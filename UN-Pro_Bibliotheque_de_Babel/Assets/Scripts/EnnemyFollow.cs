using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyFollow : MonoBehaviour
{

    public float speed;
    public Transform target;
    
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player1").GetComponent<Transform>();
        speed = 1f;    
    }

    
    void Update()
    {
        if(gameObject.GetComponent<Entities>().isStuned == false)
        {
            if (gameObject.GetComponent<Entities>().canMove)
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }
}
