using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

[RequireComponent(typeof(Rigidbody2D))]
public class SimplePlayerMove : MonoBehaviour
{
    private float moveHorizontal;
    private float moveVertical;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");


        this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveHorizontal*2, moveVertical*2);

    }
}
