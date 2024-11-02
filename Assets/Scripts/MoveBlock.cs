using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlock : MonoBehaviour
{
    //https://www.youtube.com/watch?v=vua2a_Z3zlY

    public Transform platform;
    public Transform start;
    public Transform end;
    public float speed = 1.5f;

    int direction = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 target = currentTarget();

        platform.position = Vector2.Lerp(platform.position, target, speed * Time.deltaTime);

        float distance = (target - (Vector2)platform.position).magnitude;

        if (distance < .1f)
        {
            direction *= -1;
        }
    }

    Vector2 currentTarget()
    {
        if(direction == 1)
        {
            return start.position;
        }
        else
        {
            return end.position;
        }
    }
}
