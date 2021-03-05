using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy1_Attack : MonoBehaviour
{
    public Transform Target;
    public int moveAngle;

    public float AttackDistance;
    public Animator animator;

    void Start()
    {
        AttackDistance = 50f;
    }

    // Update is called once per frame
    void Update()
    {
        Target = GetComponent<EnnemyFollow>().target;
        FindAngle();
        CheckDirection();
    }

    //Position Right

    public void CheckDirection()
    {
        if (moveAngle < 135 & moveAngle > -135 && Vector2.Distance(transform.position, Target.position) < AttackDistance)
        {
            animator.SetInteger("Index", 1);
            animator.SetBool("IsAttacking", true);
           
        }
        else 
        {
            animator.SetInteger("Index", 0);
            animator.SetBool("IsAttacking", false);
        }
       
    }
    


    private void FindAngle()
    {
        moveAngle = (int) Vector2.Angle(Target.position, Vector2.right);

        if(Target.position.y < 0)
        {
            moveAngle *= -1;
        }
    }
}
