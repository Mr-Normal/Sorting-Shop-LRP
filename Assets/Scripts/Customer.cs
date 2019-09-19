using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    [Tooltip("Список ящиков, которые могут присутствовать заказе")]
    public GameObject[] productList;

    public string[] GetRandomOrder(int productCount)
    {
        string[] names = new string[productCount];
        int indexRnd;

        for (int i = 0; i < productCount; i++)
        {
            indexRnd = Random.Range(0, productList.Length);
            names[i] = productList[indexRnd].name;
        }

        return names;
    }
}
