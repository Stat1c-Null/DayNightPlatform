using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("FeetOfPain"))
        {
            Destroy(this.gameObject);
        }
    }
    /* private void OnCollisionEnter2D(Collision2D col)
     {
         if (col.gameObject.tag == "Weak Point")
         { 
             Destroy(col.gameObject);
         }
     }*/
}
