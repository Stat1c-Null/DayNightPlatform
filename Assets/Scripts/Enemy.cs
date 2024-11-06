using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected Rigidbody2D mybody;
    public GameObject PointA;
    public GameObject PointB;
    //public GameObject PointC;
    public Animator anim;
    Transform currentPoint;

    public float speed = 4;

    public bool IsEnemyHit = false;
    protected bool isMoving = false;
    public float HowFar; // Distance the enemy can see

    public LayerMask playerLayer; // Layer mask for the player

    public bool IsHit = false;

    public Collider2D collider;

    protected PlayerMovement player; // Reference to the player object


    void Start()
    {
        mybody = GetComponent<Rigidbody2D>();
        currentPoint = PointA.transform;
        isMoving = true;
        anim.Play("Walk", 0);
        
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();



    }

    protected void Update()
    {
        MoveToPoint();

        
    }

    void MoveToPoint()
    {
        if (!isMoving) return;

        Vector2 point = currentPoint.position - transform.position;

        if (point.x > 0.02 && transform.localScale.x < 0) flip();
        else if (point.x < 0.02 && transform.localScale.x > 0) flip();

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
            currentPoint = PointA.transform;
            StartCoroutine(IdleAtPoint());

        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == PointA.transform)
        {
            currentPoint = PointB.transform;
            StartCoroutine(IdleAtPoint());
        }
    }

    void MoveToPlayer()
    {

        // Create a ray from the enemy's position towards the player

         Vector3 rayOrigin = transform.position;

         Vector3 direction = (player.transform.position - rayOrigin).normalized;



         // Perform the raycast

         RaycastHit hit;

         if (Physics.Raycast(rayOrigin, direction, out hit, HowFar, playerLayer))

         {

             // If ray hits the player, do something (e.g., chase the player)
             IsEnemyHit = true;
             //death();

         }
    }

    private void flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;





    }

    public float idleTimeAtPoint = 1;

    IEnumerator IdleAtPoint()
    {
        mybody.velocity = new Vector2(0, mybody.velocity.y);
        anim.Play("Idle");
        isMoving = false;
        yield return new WaitForSeconds(idleTimeAtPoint);
        anim.Play("Walk");
        isMoving = true;
    }



    public void Death()
    {
        Destroy(this.gameObject);
    }

    /* private void death()
     {
         if (IsEnemyHit)
         {
             Destroy(this.gameObject);
         }



     }*/


}