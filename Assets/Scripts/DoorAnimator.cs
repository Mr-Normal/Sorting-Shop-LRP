using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimator : MonoBehaviour
{
    public DoorController doorController;
    public Animator animator;

    void Update()
    {
        animator.SetBool("Open", doorController.DoorIsOpen);
        animator.SetBool("Close", !doorController.DoorIsOpen);
    }
}
