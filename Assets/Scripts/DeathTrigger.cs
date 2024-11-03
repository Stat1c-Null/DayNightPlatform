using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            die();
        }
    }

    public static void die()
    {
        print("hit deathzone");

        GameObject Player = GameObject.FindWithTag("Player");
        Player.transform.position = new Vector3(-5, -3, 0);
    }
}
