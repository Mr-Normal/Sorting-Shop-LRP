using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Order
{
    List<string> names;
    [Tooltip("Список ящиков, которые могут присутствовать заказе")]
    public GameObject[] productList;

    static string[] GetRandomOrder(GameObject[] productList, int productCount)
    {
        string[] names = new string[productCount];
        int indexRnd;

        for (int i = 0; i < productCount; i++)
        {
            indexRnd = UnityEngine.Random.Range(0, productList.Length);
            names[i] = productList[indexRnd].name;
        }

        return names;
    }

    static string[] GetRandomOrder(GameObject[] productList, int minProductCount, int maxProductCount)
    {
        int rndCount = UnityEngine.Random.Range(minProductCount, maxProductCount);
        return GetRandomOrder(productList, rndCount);
    }

    //Обрабатывает указанный ящик
    public void Process(GameObject go)
    {
        if (IsEmpty) { return; }            //Если заказ пуст, прервать функцию
        if (IsValid(go))                    //Если ящик прошел проверку на соответствие заказу
        {
            Debug.Log("Принят " + go.name); 
            NextChest();                    //Убираем из списка заказов этот ящик
            if (IsEmpty)                    //Если после этого заказ пуст
            {
                Completed();                //Успешно завершить заказ 
            }
        }
        else
        {
            Debug.Log(go.name + " не принят");
            Cancel();                       //Аварийное завершение заказа
        }
    }

    /// <summary> Возвращает true если заказ пуст </summary>
    public bool IsEmpty
    {
        get
        {
            return names == null || names.Count == 0;
        }
    }

    void NextChest()
    {
        if (names.Count > 0)
        {
            names.RemoveAt(0);
        }
    }

    //Аварийное завершение заказ
    public void Cancel()
    {
        names = null;
    }

    //Успешное завершение заказа
    void Completed()
    {
        WorkShift.AddScore(1);
    }

    //Пересоздать заказ
    public void Refrash()
    {
        Debug.Log("Обновляем заказ");
        if (names == null)
        {
            names = new List<string>();
        }
        else
        {
            names.Clear();
        }
        names.AddRange(GetRandomOrder(productList, 1, 5));
    }

    //Возвращает true если указанный ящик совпадает с ящиком, который нужно сдать в данный момент 
    bool IsValid(GameObject go)
    {
        return names[0] == go.name;
    }

    /// <summary> Имя ящика, который нужно сдать в данный момент </summary>
    public string CurrentChestName
    {
        get
        {
            if (IsEmpty)
            {
                return null;
            }
            else
            {
                return names[0];
            }
        }
    }

    /// <summary> Возвращает количество несданных ящиков </summary>
    public int GetChestLeft()
    {
        if (IsEmpty)
        {
            return 0;
        }
        else
        {
            return names.Count;
        }
    }
}
