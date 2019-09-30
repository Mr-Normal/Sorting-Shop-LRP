using System;
using UnityEngine;

public class CharacterStateManager : MonoBehaviour
{
    public State[] states;          //Состояния, модифицирующие поведение персонажа
    public Transform pickPosition;  //Контейнер, внутри которого находятся переносимые ящики

    void Update()
    {
        Manager();
    }

    void Manager()
    {
        Transform chest;
        State state;
        
        if (pickPosition.childCount > 0)        //Если в контейнере есть объекты
        {
            chest = pickPosition.GetChild(0);   //Получаем первый объект внутри контейнера
            state = GetState(chest.name);       //Находим (по имени ящика) состояние, применяемое на персонажа
            if (state != null)                  //Если состояние найдено
            {
                state.ApplyTo(gameObject);      //Применяем на персонажа соответствующее состояние
            }
            else
            {
                State.Run.ApplyTo(gameObject);  //Иначе - пусть к персонажу применяется состояние "бег"
            }
        }
        else
        {
            State.Run.ApplyTo(gameObject);      //Иначе - пусть к персонажу применяется состояние "бег"
        }

    }

    //Находим состояние по имени ящика
    State GetState(string chestName)
    {
        State state;
        for (int i = 0; i < states.Length; i++)
        {
            state = states[i];
            if (state.chestName == chestName)
            {
                return state;
            }
        }
        Debug.LogAssertion("Нет имени '" + chestName + "' в списке состояний");
        return null;
    }

    [Serializable]
    public class State
    {
        public string chestName;
        public float speed = 1;

        public State(string chestName, float speed)
        {
            this.chestName = chestName;
            this.speed = speed;
        }

        public void ApplyTo(GameObject character)
        {
            Move move = character.GetComponent<Move>();

            move.speed = speed;
        }

        public static State Run
        {
            get
            {
                return new State("Run", 3);
            }
        }
    }
}
