using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarController : MonoBehaviour
{
    private int heatMax;
    private int sleepMax;
    public static int heatCount;
    public static int sleepCount;
    private double heatTick;
    private double sleepTick;
    public double heatRate;
    public double sleepRate;
    public double heatUpRate;
    private double heatUpTick;

    public int pillowAmt;
    private static int pillowVal;

    public PlayerHealth playerHealth;
    private GameObject player;

    void Start()
    {
        heatMax = 30;
        sleepMax = 30;
        heatCount = heatMax;
        sleepCount = sleepMax;
        heatTick = 0;
        sleepTick = 0;
        heatUpTick = 0;
        pillowVal = pillowAmt;

        PlayerHealth.deathStatic.AddListener(Respawn);
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerMovement.isDay)
        {
            sleepTick += Time.deltaTime;
            if(heatCount < heatMax)
                heatUpTick += Time.deltaTime;

            if (sleepTick >= (1 / heatRate))
                if (sleepCount > 0)
                {
                    sleepCount--;
                    sleepTick -= (1 / heatRate);
                    print("sleep = " + sleepCount);
                }
                else
                {
                    doDamage();
                }

            if (heatUpTick >= (1 / heatUpRate))
            {
                heatCount++;
                heatUpTick -= (1 / heatUpRate);
                print("heat = " + heatCount);
            }
        }
        else
        {
            heatTick += Time.deltaTime;

            if (heatTick >= (1 / heatRate))
                if (heatCount > 0)
                {
                    heatCount--;
                    heatTick -= (1 / heatRate);
                    print("heat = " + heatCount);
                }
                else
                {
                    doDamage();
                }
        }

        
    }

    //will be called in pillow obj
    public static void collectPillow()
    {
        print("pillow collected");
        if(sleepCount+pillowVal < 30)
            sleepCount += pillowVal;
        else
            sleepCount = 30;
    }

    public int getHeatCount()
    {
        return heatCount;
    }
    public int getSleepCount()
    {
        return sleepCount;
    }

    private void doDamage()
    {
        if (playerHealth == null)
        { 
            player = GameObject.FindWithTag("Player");
            playerHealth = player.GetComponent<PlayerHealth>();
        }

        Debug.Log("Dealing damage");
        playerHealth.TakeDamage(playerHealth.damageGiven);
    }





    public void Respawn()
    {

        heatMax = 30;
        sleepMax = 30;
        heatCount = heatMax;
        sleepCount = sleepMax;
        heatTick = 0;
        sleepTick = 0;
        heatUpTick = 0;
        pillowVal = pillowAmt;
    }
}
