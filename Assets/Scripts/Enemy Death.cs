using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public Enemy enemy;
    Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
       
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("FeetOfPain"))
        {
            enemy.IsHit = true;
            StartCoroutine(WaitForAnimationUpdate());
            enemy.Death();
        }
    }

    IEnumerator WaitForAnimationUpdate()

    {

        // Trigger an animation
        
        anim.SetBool("IsHit", true);



        // Wait for the current frame to finish rendering

        yield return new WaitForEndOfFrame();



       /* // Access the updated animation state after the frame is complete

        Debug.Log("Animation is now in state: " + animator.GetCurrentAnimatorStateInfo(0).fullPathHash);*/

    }

}
