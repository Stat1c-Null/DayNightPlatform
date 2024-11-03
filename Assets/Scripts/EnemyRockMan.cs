using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRockMan : MonoBehaviour
{
   /* public Transform[] PartrollingPoints;
    public float TargetP;*/


    Rigidbody2D mybody;
    public GameObject PointA;
    public GameObject PointB;
    //public GameObject PointC;
    Animator anim;
    Transform currentPoint;

    public float speed = 4;

    public bool IsHit = false;

    public RuntimeAnimatorController IdleAnimator;
    public RuntimeAnimatorController WalkAnimator;
    public RuntimeAnimatorController DeathAnimator;




    Transform player; // Reference to the player object
    // Start is called before the first frame update
    void Start()
    {
        mybody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
       currentPoint = PointA.transform;

          IsHit = false;
       

    player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {


        /*if(transform.position == PartrollingPoints[TargetP].position)
        {
            IncreaseTargetPoint();


        }
          transform.position = Vector3.MoveTowards(transform.position, PartrollingPoints[0].position, speed * Time.deltaTime);
*/


        Vector2 point = currentPoint.position - transform.position;

        if (currentPoint == PointB.transform)
        {
            mybody.velocity = new Vector2(speed, 0);


        }
        else
        {

            mybody.velocity = new Vector2(-speed, 0);


        }


        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == PointB.transform)
        {
            flip();

            currentPoint = PointA.transform;
            Debug.Log("Where");

        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == PointA.transform)
        {
            flip();
            currentPoint = PointB.transform;
            Debug.Log("WhereAgain");

        }






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
    private void flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;





    }
}