using UnityEngine;

public class OrderInfoShow : MonoBehaviour
{
    public Request request;
    public ToggleGO chestToggle;

    void Update()
    {
        chestToggle.Select(request.CurrentChestName);
    }

}
