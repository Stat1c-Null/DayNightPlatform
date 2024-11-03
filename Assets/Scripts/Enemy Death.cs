using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{

    public GameObject Enemy;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Weak Point"))
        {
            Destroy(other.gameObject);
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
