using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarController : MonoBehaviour
{
    private int heatMax;
    private int sleepMax;
    private static int heatCount;
    private static int sleepCount;
    private double heatTick;
    private double sleepTick;
    public double heatRate;
    public double sleepRate;
    public double heatUpRate;
    private double heatUpTick;

    public int pillowAmt;
    private static int pillowVal;

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
        sleepCount += pillowVal;
    }

    private void doDamage()
    {
        //to be implemented
    }
}