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
    Animator anim;
    Transform currentPoint;

    public float speed = 4;

    public bool IsEnemyHit = false;

    public float HowFar; // Distance the enemy can see

    public LayerMask playerLayer; // Layer mask for the player



    Transform player; // Reference to the player object


    void Start()
    {
        mybody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentPoint = PointA.transform;

        anim.SetBool("IsRunning", true);

        player = GameObject.FindGameObjectWithTag("Player").transform;



    }

    void Update()
    {
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

        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == PointA.transform)
        {
            flip();
            currentPoint = PointB.transform;

        }

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
    private void flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;





    }
   /* private void death()
    {
        if (IsEnemyHit)
        {
            Destroy(this.gameObject);
        }



    }*/

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("FeetOfPain"))
        {
            Destroy(this.gameObject);
        }
    }
}