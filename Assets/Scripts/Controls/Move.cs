using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [Range(0, 10)] public float speed = 1;
    Rigidbody rb;
    [Tooltip("Обозначает направление движения: если х > 0, то вверх, если z > 0, то вправо")]
    public Vector3 directionUntwisted;
    
    private void Awake()
    {
        rb = GetRigidbody(gameObject);
    }

    private void FixedUpdate()
    {
        SetVelocity(GetVelocity());
        SetRotation(GetRotation());
        FixRotation();
    }

    void SetVelocity(Vector3 velocity)
    {
        rb.velocity = velocity;
    }

    static Rigidbody GetRigidbody(GameObject go)
    {
        return go.GetComponent<Rigidbody>();
    }

    Vector3 GetMainDirection()
    {
        Camera camera;
        Quaternion rotation;
        Vector3 direction;

        camera      = Camera.main;
        rotation    = camera.transform.rotation;
        direction   = rotation * Vector3.up;
        direction.y = 0;

        return direction.normalized;
    }

    Vector3 GetDirectionLeft(Vector3 directionMain)
    {
        Vector3 directionLeft = Vector3.zero;

        directionLeft.x = -directionMain.z;
        directionLeft.z = directionMain.x;

        return directionLeft;
    }

    Vector3 GetMoveDirection(Vector3 directionUntwisted)
    {
        Vector3 directionTwisted;
        Vector3 dMain;
        Vector3 dLeft;

        dMain = GetMainDirection();
        dLeft = GetDirectionLeft(dMain);
        directionTwisted = dMain * directionUntwisted.x + dLeft * -directionUntwisted.z;

        return directionTwisted;
    }

    Vector3 GetVelocity()
    {
        return GetMoveDirection(directionUntwisted) * speed;
    }

    Quaternion GetRotation()
    {
        Quaternion rotation;
        Vector3 direction = GetMoveDirection(directionUntwisted);

        if(direction.magnitude > 0)
        {
            rotation = Quaternion.LookRotation(direction);
        }
        else
        {
            rotation = rb.rotation;
        }

        return rotation;
    }
    void SetRotation(Quaternion rotation)
    {
        rb.MoveRotation(rotation);
    }
    void FixRotation()
    {
        rb.rotation = XZFixedRotation(rb.rotation);
    }
    Quaternion XZFixedRotation(Quaternion quaternion)
    {
        Vector3 rotation = quaternion.eulerAngles;
        rotation.x = 0;
        rotation.z = 0;
        return Quaternion.Euler(rotation);
    }
}
