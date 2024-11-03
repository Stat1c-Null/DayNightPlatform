using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRockMan : Enemy
{
   /* public Transform[] PartrollingPoints;
    public float TargetP;*/
   

    // Update is called once per frame
    void Update()
    {
        base.Update();

        /*if(transform.position == PartrollingPoints[TargetP].position)
        {
            IncreaseTargetPoint();


        }
          transform.position = Vector3.MoveTowards(transform.position, PartrollingPoints[0].position, speed * Time.deltaTime);
*/

        //aniamtions
        if (!IsHit)
        {
            if (speed > .01)
            {
                anim.SetFloat("Speed", 0.05f);


            }
            if (speed == 0)
            {
                anim.SetFloat("Speed", 0f);
            }
        }
       else if(IsHit)
                    { 
            anim.SetBool("IsHit", true); 

        }
    }

   /* void IncreaseTargetPoint()
    {
        TargetP++;
        if (TargetP >= PartrollingPoints.Length)
        { 
            TargetP = 0;
        
        
        }
    
    
    
    }*/
}
