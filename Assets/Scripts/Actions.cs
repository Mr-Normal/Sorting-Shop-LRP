using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actions : MonoBehaviour
{
    public Transform pickPosition;
    public bool Pick()
    {
        if(CanPick)
        {
            GameObject chest = GetChest();
            if (chest != null)
            {
                chest.SendMessage("PickThis", pickPosition);
                return !CanPick;
            }
        }
        return false;
    }

    public bool Drop()
    {
        if (!CanPick)
        {
            GameObject chest = GetChest();
            chest.SendMessage("DropThis");
            return CanPick;
        }
        return false;
    }

    /// <summary> Возвращает true если в данный момент персонажу можно подобрать ящик </summary>
    bool CanPick
    {
        get
        {
            return pickPosition.childCount < 1;
        }
    }

    /// <summary> Находит и возвращает ближайщий достижимый ящик </summary>
    GameObject GetChest()
    {
        if(pickPosition.childCount > 0)
        {
            return pickPosition.GetChild(0).gameObject;
        }
        else
        {
           return FindChest(pickPosition.position);
        }
    }

    GameObject FindChest(Vector3 center)
    {
        Collider[] colliders    = Physics.OverlapSphere(center, 1, int.MaxValue, QueryTriggerInteraction.Collide);

        return FindChest(colliders);
    }

    GameObject FindChest(Collider[] colliders)
    {
        Collider find;

        for (int i = 0; i < colliders.Length; i++)
        {
            find = colliders[i];
            if(find.tag == "Chest")
            {
                return find.gameObject;
            }
        }

        return null;
    }

}
