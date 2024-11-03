using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillowScript : MonoBehaviour
{
    private GameObject[] pillows;
    
    void Start()
    {
        pillows = GameObject.FindGameObjectsWithTag("Pillow");
    }
    // Update is called once per frame
    void Update()
    {
        foreach (GameObject obj in pillows)
            if (obj != null)
                obj.SetActive(!PlayerMovement.isDay);
    }
}
