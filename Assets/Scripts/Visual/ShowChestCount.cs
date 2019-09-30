using UnityEngine;

public class ShowChestCount : MonoBehaviour
{
    public Request request;
    public TextMesh text;

    void Start()
    {
        Refrash();
    }

    void Update()
    {
        Refrash();
    }

    void Refrash()
    {
        text.text = request.GetChestLeft().ToString();
    }
}
