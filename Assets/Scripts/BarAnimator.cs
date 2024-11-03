using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarAnimator : MonoBehaviour
{
    public BarController meterScript;
    [Header("Bars")]
    public Image heatBar;
    public Image sleepBar;
    
    [Header("Sprites")]
    public Sprite[] heatSprites;
    public Sprite[] sleepSprites;

    private double tick=0;

    void Update()
    {
        tick += Time.deltaTime;

        int heatlvl = meterScript.getHeatCount();
        int sleeplvl = meterScript.getSleepCount();
        
        if(tick>=0)
            print("heat: "+heatlvl+", sleep: "+sleeplvl); tick -= 1;

        heatBar.sprite = heatSprites[heatlvl];
        sleepBar.sprite = sleepSprites[sleeplvl];
    }
}
