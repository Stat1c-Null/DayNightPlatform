using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    public Transform respawnPoint;
    public PlayerHealth playerHealth;
    public GameObject bars;

    public void Start() {
        bars = GameObject.Find("Meters 1");
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            die();
        }
    }

    public void die()
    {
        GameObject Player = GameObject.FindWithTag("Player");
        Player.transform.position = new Vector3(respawnPoint.position.x, respawnPoint.position.y, respawnPoint.position.z);
        playerHealth.TakeDamage(playerHealth.damageGiven);
        bars.GetComponent<BarController>().Respawn();
    }
}
