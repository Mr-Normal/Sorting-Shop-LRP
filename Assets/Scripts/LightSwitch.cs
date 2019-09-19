using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    public State state;
    public GameObject[] lights;

    public enum State
    {
        Empty,
        Attention,
        Danger
    }

    void Update()
    {
        LightRefrash(state, lights);
    }

    public void SetAttention()
    {
        state = State.Attention;
    }

    static void LightRefrash(State state, GameObject[] lights)
    {
        switch (state)
        {
            case State.Empty:
                TurnOn(-1, lights);
                break;
            case State.Attention:
                TurnOn(0, lights);
                break;
            case State.Danger:
                TurnOn(1, lights);
                break;
            default:
                break;
        }
    }

    static void TurnOn(int index, GameObject[] lights)
    {
        for (int i = 0; i < lights.Length; i++)
        {
            lights[i].SetActive(index == i);
        }
    }
}
