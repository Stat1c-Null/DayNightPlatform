using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MoveBlock : MonoBehaviour
{
    //https://www.youtube.com/watch?v=vua2a_Z3zlY

    public Transform platform;
    public Transform start;
    public Transform end;
    public float speed = 1.5f;
    public bool dayObj;

    int direction = 1;

    Vector3 oldPosition;

    // this is in fixed because if we dont interpolation will get absolutely rekt
    void FixedUpdate()
    {

        Vector2 target = currentTarget();

        platform.position = Vector2.Lerp(platform.position, target, speed * Time.deltaTime);

        float distance = (target - (Vector2)platform.position).magnitude;

        if (distance < .1f)
        {
            direction *= -1;
        }

        //Shitty fix to deparent player from platform when platform dissappears during the day
        switch(dayObj){
            case true:
                if(Input.GetKeyDown(KeyCode.E) && PlayerMovement.isDay == false) {
                    DeparentAllRiders();
                }
                break;
            case false:
                if(Input.GetKeyDown(KeyCode.E) && PlayerMovement.isDay == true) {
                    DeparentAllRiders();
                }
                break;
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

    public string[] riderTags = {"Player"};

    public List<Transform> riders;

    //this is what I added since last time
    private void OnTriggerEnter2D(Collider2D c)
    {
        if(dayObj){
            if (riderTags.Contains<string>(c.tag) && PlayerMovement.isDay == true)
            {
                c.transform.SetParent(platform.transform);
                riders.Add(c.transform);
            }
        } else {
            if (riderTags.Contains<string>(c.tag) && PlayerMovement.isDay == false)
            {
                c.transform.SetParent(platform.transform);
                riders.Add(c.transform);
            }
        }
        
    }

    private void OnTriggerExit2D(Collider2D c)
    {
        if (riderTags.Contains<string>(c.tag))
        {
            c.transform.SetParent(null);
            riders.Remove(c.transform);
        }
    }

    public void DeparentAllRiders()
    {
        foreach (Transform t in riders)
        {
            t.transform.SetParent(null);
        }
        riders.Clear();
    }
}
