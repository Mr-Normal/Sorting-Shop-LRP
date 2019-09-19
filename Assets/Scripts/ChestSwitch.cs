using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestSwitch : MonoBehaviour
{

    static void SwitchTo(string name, Transform container)
    {
        GameObject go;

        for (int i = 0; i < container.childCount; i++)
        {
            go = container.GetChild(i).gameObject;
            go.SetActive(go.name == name);
        }

    }

    public void SwitchTo(string name)
    {
        SwitchTo(name, transform);
    }
}
