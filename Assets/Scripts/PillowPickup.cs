using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillowPickup : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            BarController.collectPillow();
            Destroy(this.gameObject);
        }
    }
}
