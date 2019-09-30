using UnityEngine;

public class Chest : MonoBehaviour
{
    public void PickThis(Transform pickPosition)
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

    public void DropThis()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        Transform newParent = GetNewParent();
        
        SetActive(rb, true);
        transform.SetParent(newParent);
    }

    //Возвращает Transform, ребенком которого является Character
    Transform GetNewParent()
    {
        return transform.parent.parent.parent;
    }

    //Активирует/дезактивирует Rigidbody
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

    //Возвращает true если ящик разрешено поднимать
    bool CanPicked()
    {
        Animation animation = GetComponent<Animation>();

        return !animation.isPlaying;
    }
}
