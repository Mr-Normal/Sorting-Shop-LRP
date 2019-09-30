using UnityEngine;

public class ControlsManager : MonoBehaviour
{
    public Actions actions;
    public AnimationController animationController;
    public Move move;

    void Update()
    {
        Controls();
    }

    //Управляет юнитом в соответствии с вводом (с клавиатуры и мыши)
    void Controls()
    {
        Vector3 direction = DirectionKeyboard.GetDirection();

        move.directionUntwisted = direction;
        animationController.Move(direction.magnitude * move.speed);

        if (Input.GetButton("Fire1"))
        {
            if (actions.Pick())
            {
                animationController.Pick();
            }
        }

        if (Input.GetButtonDown("Cancel"))
        {
            if (actions.Drop())
            {
                animationController.Drop();
            }
        }
    }
}
