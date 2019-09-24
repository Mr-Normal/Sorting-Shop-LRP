using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Request : MonoBehaviour
{
    public Customer customer;
    public ChestSwitch chestSwitch;
    List<string> order;

    private void Start()
    {
        order = new List<string>();
        RefrashOrder();
    }

    void SendChest(GameObject go)
    {
        Destroy(go, 22);
        go.transform.SetParent(transform);
    }

    public void ProcessOrder(GameObject go)
    {
        if (IsValid(go))
        {
            Debug.Log("Принят " + go.name);
            NextChest();
        }
        else
        {
            Debug.Log(go.name + " не принят");
            RefrashOrder();
        }
        SendChest(go);
    }

    void NextChest()
    {
        order.RemoveAt(0);
        if(order.Count < 1)
        {
            RefrashOrder();
        }
        else
        {
            chestSwitch.SwitchTo(order[0]);
        }
    }


    void RefrashOrder()
    {
        Debug.Log("Обновляем заказ");
        order.Clear();
        order.AddRange(customer.GetRandomOrder(4));
        chestSwitch.SwitchTo(order[0]);
    }

    bool IsValid(GameObject go)
    {
        return order[0] == go.name; 
    }

    public void Restart()
    {
        RefrashOrder();
    }
}
