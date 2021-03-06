using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy1_Attack : MonoBehaviour
{
    public Transform Target;
    public int moveAngle;

    public float AttackDistance;
    public Animator animator;
    public bool IsAttacking;
    public int Index;

    void Start()
    {
        AttackDistance = 1f;
        IsAttacking = false;
        Index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Target = GetComponent<EnnemyFollow>().target;
        FindAngle();
        CheckDirection();
    }

  

    public void CheckDirection()
    {
        animator.SetBool("IsAttacking", IsAttacking);
        animator.SetInteger("Index", Index);
        
        
        //CheckDirection Left
        if ((moveAngle >= 135 && moveAngle <=180) || (moveAngle <= -135 && moveAngle >=-180) && Vector2.Distance(transform.position, Target.position) < AttackDistance)
        {
            Index = 1;
            IsAttacking = true;
            print("attackGauche");
        }
        

        //CheckDirectionUP
        else if (moveAngle <= 135 & moveAngle >= 45 && Vector2.Distance(transform.position, Target.position) < AttackDistance)
        {
            Index = 2;
            IsAttacking = true;
            print("attackhaut");
        }
       

        //CheckDirectionRight
        else if ((moveAngle <= 45 && moveAngle >=0) || (moveAngle >= -45 && moveAngle <= 0) && Vector2.Distance(transform.position, Target.position) < AttackDistance)
        {
            Index = 3;
            IsAttacking = true;
            print("attackdroite");
        }
        

        //CheckDirectionDown
        else if (moveAngle < -45 & moveAngle > -135 && Vector2.Distance(transform.position, Target.position) < AttackDistance)
        {
            Index = 4;
            IsAttacking = true;
            print("attackbas");
        }

        else
        {
            Index = 0;
            IsAttacking = false;
        }
       
    }
    


    private void FindAngle()
    {
        moveAngle = (int)Vector2.Angle(Target.position - this.transform.position, Vector2.right);

        if (Target.position.y < 0)
        {
            moveAngle *= -1;
        }
    }
}
