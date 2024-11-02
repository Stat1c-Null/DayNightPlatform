using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipBlock : MonoBehaviour
{
    public GameObject dayObj;
    public GameObject nightObj;
    // Start is called before the first frame update
    void Start()
    {
        PlayerMovement.swappedToDay.AddListener(SwapBlockDay);
        PlayerMovement.swappedToNight.AddListener(SwapBlockNight);

        dayObj.SetActive(PlayerMovement.isDay);
        nightObj.SetActive(!PlayerMovement.isDay);
    }
    void SwapBlockDay()
    {
        dayObj.SetActive(true);
        nightObj.SetActive(false);
    }
    void SwapBlockNight()
    {
        dayObj.SetActive(false);
        nightObj.SetActive(true);
    }
}
