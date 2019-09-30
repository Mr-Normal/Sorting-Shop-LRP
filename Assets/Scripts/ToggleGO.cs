using UnityEngine;

public class ToggleGO : MonoBehaviour
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

    /// <summary> 
    /// Активирует всех детей с указанным именем. 
    /// В качестве родителя выступает игровой объект, к которому прикреплен данный скрипт. 
    /// </summary>
    /// <param name="name"> Имя детей, которых нужно активировать </param>
    public void Select(string name)
    {
        SwitchTo(name, transform);
    }
}