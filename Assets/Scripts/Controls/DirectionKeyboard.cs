using UnityEngine;

public static class DirectionKeyboard
{
    public static Vector3 GetDirection()
    {
        float vertical, horizontal;
        Vector3 direction;

        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");

        direction = new Vector3(vertical, 0, horizontal);

        return direction.normalized;
    }
    
}
