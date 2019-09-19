using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    Animator animator;
    public float speed;
    public MoveMode move        = MoveMode.Idle;
    public ActionMode action    = ActionMode.Idle;

    public enum MoveMode
    {
        Idle    = 0,
        Normal  = 1,
    }

    public enum ActionMode
    {
        Idle    = 0,
        Pick    = 1,
        Drop    = 2,
        Drag    = 3
    }

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        AnimRefresh(animator, move, action, speed);
        action = GetActionMode(action, action);
        move = GetMoveMode(speed, action);
    }

    public void Move(float speed)
    {
        this.speed = speed;
    }

    public void Pick()
    {
        action = GetActionMode(action, ActionMode.Pick);
    }

    public void Drop()
    {
        action = GetActionMode(action, ActionMode.Drop);
    }

    static void AnimRefresh(Animator animator, MoveMode move, ActionMode action, float speed)
    {
        animator.SetInteger("MoveMode", (int)move);
        animator.SetFloat("MoveSpeed", speed);

        switch (action)
        {
            case ActionMode.Pick:
                animator.SetInteger("ActionMode", 0);
                animator.SetBool("ActionPickObject", true);
                break;
            case ActionMode.Drop:
                animator.SetInteger("ActionMode", 1);
                animator.SetBool("ActionDropObject", true);
                animator.SetFloat("BootsSpeed", 1);
                break;
            case ActionMode.Drag:
                animator.SetInteger("MoveMode", 1);
                animator.SetFloat("BootsSpeed", speed);
                break;
            default:
                break;
        }

    }

    static MoveMode GetMoveMode(float moveMagnitude, ActionMode action)
    {
        if (moveMagnitude > 0)
        {
            if(action == ActionMode.Drag)
            {
                return MoveMode.Normal;
            }
        }
        return MoveMode.Idle;
    }

    static ActionMode GetActionMode(ActionMode lastAction, ActionMode newAction)
    {
        switch (lastAction)
        {
            case ActionMode.Idle:
                if (newAction == ActionMode.Pick)
                {
                    return ActionMode.Pick;
                }
                break;
            case ActionMode.Pick:
                return ActionMode.Drag;
            case ActionMode.Drop:
                return ActionMode.Idle;
            case ActionMode.Drag:
                if (newAction == ActionMode.Drop)
                {
                    return ActionMode.Drop;
                }
                break;
            default:
                break;
        }

        return lastAction;
    }
    
}
