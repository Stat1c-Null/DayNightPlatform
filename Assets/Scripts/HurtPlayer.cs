using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    public int damageGiven = 5;
    public PlayerHealth PlayerHealth;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == ("Player"))
        {
            if (PlayerHealth == null)
            { 
            
            PlayerHealth = other.gameObject.GetComponent<PlayerHealth>();
            
            }

            PlayerHealth.TakeDamage(damageGiven);
          }
    }


  
}
