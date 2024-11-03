using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillowPickup : MonoBehaviour
{
    private bool isCollected = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !isCollected)
        {
            isCollected = true;
            BarController.collectPillow();
            Destroy(this.gameObject);
        }
    }
}
