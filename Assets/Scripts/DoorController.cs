using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    float timeToClose;

    void Update()
    {
        if(timeToClose > 0)
        {
            timeToClose -= Time.deltaTime;
        }   
    }

    void OnTriggerStay(Collider other)
    {
        if(other.tag == "Chest")
        {
            timeToClose = 1;
        }
    }

    public bool DoorIsOpen
    {
        get
        {
            return timeToClose > 0;
        }
    }
}
