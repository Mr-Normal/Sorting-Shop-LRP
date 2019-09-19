using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStateManager : MonoBehaviour
{
    public State[] states;
    public Transform pickPosition;

    void Update()
    {
        Manager();
    }

    void Manager()
    {
        Transform chest;
        State state;
        
        if (pickPosition.childCount > 0)
        {
            chest = pickPosition.GetChild(0);
            state = GetState(chest.name);
            if (state != null)
            {
                state.ApplyTo(gameObject);
            }
            else
            {
                State.Run.ApplyTo(gameObject);
            }
        }
        else
        {
            State.Run.ApplyTo(gameObject);
        }

    }

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

    public void OnPickedBy(GameObject character)
    {
        State state;
        state = states[0];
        state.ApplyTo(character);
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
