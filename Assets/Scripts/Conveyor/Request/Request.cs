using UnityEngine;

public class Request : MonoBehaviour
{
    [SerializeField] Order order;   //Заказ

    void OnTriggerEnter(Collider other)
    {
        GameObject go = other.gameObject;
        if (go.tag == "Chest")
        {
            if (!IsSended(go))
            {
                order.Process(go);
                SendChest(go);
            }
        }
    }

    void SendChest(GameObject go)
    {
        go.transform.SetParent(transform);
    }

    public void Restart()
    {
        if(order == null)
        {
            order = new Order();
        }
        order.Refrash();
    }

    public void SetEnable(bool isEnable)
    {
        SetTriggerEnable(isEnable);
    }
    void SetTriggerEnable(bool isEnable)
    {
        Collider trigger = GetComponent<Collider>();
        trigger.enabled = isEnable;
    }

    bool IsSended(GameObject chest)
    {
        return chest.transform.parent.tag == "Request";
    }

    /// <summary> Возвращает true если заказ пуст </summary>
    public bool IsEmpty
    {
        get
        {
            return order.IsEmpty;
        }
    }
    public string CurrentChestName
    {
        get
        {
            return order.CurrentChestName;
        }
    }

    public void Clear()
    {
        order.Cancel();
    }

    public int GetChestLeft()
    {
        return order.GetChestLeft();
    }
}
