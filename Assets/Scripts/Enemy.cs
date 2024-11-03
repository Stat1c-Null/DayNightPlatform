using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D mybody;
    public GameObject PointA;
    public GameObject PointB;
    //public GameObject PointC;
    public Animator anim;
    Transform currentPoint;

    public float speed = 4;

    public bool IsEnemyHit = false;
    bool isMoving = false;
    public float HowFar; // Distance the enemy can see

    public LayerMask playerLayer; // Layer mask for the player

    public bool IsHit = false;


    Transform player; // Reference to the player object


    void Start()
    {
        mybody = GetComponent<Rigidbody2D>();
        currentPoint = PointA.transform;
        isMoving = true;
        anim.Play("Walking", 0);
        
        player = GameObject.FindGameObjectWithTag("Player").transform;



    }

    protected void Update()
    {
        MoveToPoint();

       /* // Create a ray from the enemy's position towards the player

        Vector3 rayOrigin = transform.position;

        Vector3 direction = (player.position - rayOrigin).normalized;



        // Perform the raycast

        RaycastHit hit;

        if (Physics.Raycast(rayOrigin, direction, out hit, HowFar, playerLayer))

        {

            // If ray hits the player, do something (e.g., chase the player)
            IsEnemyHit = true;
            death();

        }
*/
        
    }

    void MoveToPoint()
    {
        if (!isMoving) return;

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
            StartCoroutine(IdleAtPoint());

        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == PointA.transform)
        {
            flip();
            currentPoint = PointB.transform;
            StartCoroutine(IdleAtPoint());
        }
    }

    private void flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;





    }

    float idleTimeAtPoint = 1;

    IEnumerator IdleAtPoint()
    {
        anim.Play("Idle", 0);
        isMoving = false;
        yield return new WaitForSeconds(idleTimeAtPoint);
        anim.Play("Walk", 0);
        isMoving = true;
    }

    /* private void death()
     {
         if (IsEnemyHit)
         {
             Destroy(this.gameObject);
         }



     }*/


}