using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int CurrentHealth;
    public int MaxHealth = 20;
    public int damageGiven = 5;
    Transform Enemy;
    bool canTakeDamage; //Used for invincibility
    public float InvincibilityDuration = 1f;

    


    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = MaxHealth;
  
        canTakeDamage = true;


    }

    // Update is called once per frame
    void Update()
    {
        
        HeartDelete(CurrentHealth);
      


    }
    void HeartDelete(int h)
    {
        switch (h)
        {
            case 15:
                Debug.Log("3 hearts");
                //first heart is deacitived
                break;
            case 10:
                Debug.Log("2 hearts");
                //second heart is deactivied
                break;
            case 5:
                Debug.Log("1 hearts");
                //third and final is deactivated
                break;
            case 0:
                Debug.Log("0 hearts");
                //last hit and they are out send them to game over scene/screen
                break;

        }


    }
    public void TakeDamage(int h)
    {
        if (canTakeDamage) //Checks if the player can take damage—otherwise, this method does nothing
        {
            Debug.Log("Test 2");
            CurrentHealth -= h;
            canTakeDamage = false; //Makes the player invincible
             //Deals the appropriate amount of damage to the player
          StartCoroutine(DamageCooldown()); //Begins the invincibility window
        }
    }
    IEnumerator DamageCooldown()
    {
        yield return new WaitForSeconds(InvincibilityDuration); //Controls how long the invincibility lasts
        canTakeDamage = true; //Makes the player no longer invincible
    }
   
}
