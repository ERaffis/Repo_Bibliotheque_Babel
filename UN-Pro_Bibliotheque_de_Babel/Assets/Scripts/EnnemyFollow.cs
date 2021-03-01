using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyFollow : MonoBehaviour
{

    public float speed;
    private Transform target;
    
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        speed = 2f;    
    }

    
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
}
