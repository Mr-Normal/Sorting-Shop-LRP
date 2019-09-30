using UnityEngine;

public class Actions : MonoBehaviour
{
    public Transform pickPosition;

    public bool Pick()
    {
        if(CanPick)
        {
            Chest chest = GetChest();
            if (chest != null)
            {
                chest.PickThis(pickPosition);
                return !CanPick;
            }
        }
        return false;
    }

    public bool Drop()
    {
        if (!CanPick)
        {
            Chest chest = GetChest();
            chest.DropThis();
            return CanPick;
        }
        return false;
    }

    // Возвращает true если в данный момент персонажу можно подобрать ящик
    bool CanPick
    {
        get
        {
            return pickPosition.childCount < 1;
        }
    }

    // Находит и возвращает ближайщий достижимый ящик 
    Chest GetChest()
    {
        GameObject chestGO;
        if(pickPosition.childCount > 0)
        {
            chestGO = pickPosition.GetChild(0).gameObject;
        }
        else
        {
            chestGO = FindChest(pickPosition.position);
        }
        return chestGO.GetComponent<Chest>();
    }

    //Находит внутри сферы все объекты с тэгом "Chest"
    GameObject FindChest(Vector3 center)
    {
        Collider[] colliders = Physics.OverlapSphere(center, 1, int.MaxValue, QueryTriggerInteraction.Collide);
        return FindChest(colliders);
    }

    //Находит в списке колайдеров все объекты с тэгом "Chest"
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
