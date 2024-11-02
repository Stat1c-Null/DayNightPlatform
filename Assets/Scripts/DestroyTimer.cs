using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTimer : MonoBehaviour
{
    public float time = 2;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Destroy());
    }
    public IEnumerator Destroy()
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }


    public DestroyTimer(float time)
    {
        this.time = time;
    }
}
