using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public UnityEvent hurt;
    public UnityEvent death;
    public static UnityEvent deathStatic;

    public int CurrentHealth;
    public int MaxHealth = 20;
    public int damageGiven = 5;
    Transform Enemy;
    bool canTakeDamage; //Used for invincibility
    public float InvincibilityDuration = 1f;

    public LayerMask UI;
    public Canvas PlayerHeart;

    public GameObject DAYA;
    public GameObject DAH1;
    public GameObject DAH2;
    public GameObject DAH3;

    public GameObject DAYDA;
    public GameObject DDAH1;
    public GameObject DDAH2;
    public GameObject DDAH3;

    public GameObject NIGHTA;
    public GameObject NAH1;
    public GameObject NAH2;
    public GameObject NAH3;

    public GameObject NIGHTDA;
    public GameObject NDAH1;
    public GameObject NDAH2;
    public GameObject NDAH3;

    public GameObject deathTrigger;
    private bool swapped = false;



    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = MaxHealth;
  
        canTakeDamage = true;
         

  
        DAYA.SetActive(true);
        DAYDA.SetActive(true);
        NIGHTA.SetActive(false);
        NIGHTDA.SetActive(false);

        PlayerMovement.swappedToDay.AddListener(st);
        PlayerMovement.swappedToNight.AddListener(sf);
    }

    void HeartDelete(int h)
    {
        switch (h)
        {
            case 15:
                hurt.Invoke();
                NAH1.SetActive(false);
                    DAH1.SetActive(false);
              
                
                //first heart is deacitived
                break;
            case 10:
                hurt.Invoke();
                NAH2.SetActive(false);
                    DAH2.SetActive(false);
                //second heart is deactivied
                break;
            case 5:
                hurt.Invoke();
                NAH3.SetActive(false);
                    DAH3.SetActive(false);
                //third and final is deactivated
                break;
            case 0:
                death.Invoke();
                deathStatic.Invoke();
                Debug.Log("EQUI DEAD DEAD");
                deathTrigger.GetComponent<DeathTrigger>().die();
                //last hit and they are out send them to game over scene/screen
                break;

        }


    }


   

    void sf()
    {
        NIGHTA.SetActive(true);
        NIGHTDA.SetActive(true);
        DAYDA.SetActive(false);
        DAYA.SetActive(false);

    
    
    }
    void st()
    {
        NIGHTA.SetActive(false);
        NIGHTDA.SetActive(false);
        DAYDA.SetActive(true);
        DAYA.SetActive(true);
    }
    public void TakeDamage(int h)
    {
        if (canTakeDamage) //Checks if the player can take damage�otherwise, this method does nothing
        {
            Debug.Log("Test 2");
            CurrentHealth -= h;
            canTakeDamage = false; //Makes the player invincible
            HeartDelete(CurrentHealth);
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
