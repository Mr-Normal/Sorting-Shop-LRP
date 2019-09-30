using UnityEngine;

public class TrashBin : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        GameObject chest = collision.gameObject;
        if (chest.tag == "Chest")
        {
            Destroy(chest);
        }
    }
}
