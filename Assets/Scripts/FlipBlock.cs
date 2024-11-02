using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipBlock : MonoBehaviour
{
    public GameObject obj1;
    public GameObject obj2;
    // Start is called before the first frame update
    void Start()
    {
        obj1.SetActive(true);
        obj2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            obj1.SetActive(!obj1.activeSelf);
            obj2.SetActive(!obj2.activeSelf);
        }

    }
}
