using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FlipBlock : MonoBehaviour
{
    public GameObject dayObj;
    public GameObject nightObj;


    public UnityEvent swappedToDay = new UnityEvent();
    public UnityEvent swappedToNight = new UnityEvent();


    // Start is called before the first frame update
    void Start()
    {
        PlayerMovement.swappedToDay.AddListener(SwapBlockDay);
        PlayerMovement.swappedToNight.AddListener(SwapBlockNight);

        if (dayObj) dayObj.SetActive(PlayerMovement.isDay);
        if (nightObj) nightObj.SetActive(!PlayerMovement.isDay);
    }
    void SwapBlockDay()
    {
        swappedToDay.Invoke();
        if (dayObj) dayObj.SetActive(true);
        if (nightObj) nightObj.SetActive(false);
    }
    void SwapBlockNight()
    {
        swappedToNight.Invoke();
        if (dayObj) dayObj.SetActive(false);
        if (nightObj) nightObj.SetActive(true);
    }
}
