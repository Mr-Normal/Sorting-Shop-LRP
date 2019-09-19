using System;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    void PickThis(Transform pickPosition)
    {
        if (!CanPicked()) { return; }
        Transform newParent = pickPosition;
        Rigidbody rb;

        transform.SetParent(newParent);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;

        rb = GetComponent<Rigidbody>();
        SetActive(rb, false);
    }

    void DropThis()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        Transform newParent = GetNewParent();
        
        SetActive(rb, true);
        transform.SetParent(newParent);
    }

    Transform GetNewParent()
    {
        return transform.parent.parent.parent;
    }

    void SetActive(Rigidbody rb, bool isActive)
    {
        if (isActive)
        {
            rb.isKinematic = false;
            rb.detectCollisions = true;

        }
        else
        {
            rb.isKinematic = true;
            rb.detectCollisions = false;
        }
    }

    bool CanPicked()
    {
        Animation animation = GetComponent<Animation>();

        return !animation.isPlaying;
    }
}
