using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPSwitch : MonoBehaviour
{

    void Update()
    {
        int count = transform.childCount;
        Collider collider = GetComponent<Collider>();
        if(count > 0)
        {
            collider.enabled = true;

        }
        else
        {
            collider.enabled = false;
        }
    }
}
