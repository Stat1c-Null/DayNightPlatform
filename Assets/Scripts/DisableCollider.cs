using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableCollider : MonoBehaviour
{
    public BoxCollider2D platformCollider;
    public bool dayCollider;

    // Update is called once per frame
    void Update()
    {
        switch(dayCollider) {
            case true:
                if(PlayerMovement.isDay) {
                    platformCollider.enabled = true;
                } else {
                    platformCollider.enabled = false;
                }
                break;
            case false:
                if(PlayerMovement.isDay) {
                    platformCollider.enabled = false;
                } else {
                    platformCollider.enabled = true;
                }
                break;
        }
        
    }
}
