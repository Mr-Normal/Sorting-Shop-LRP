using UnityEngine;

public class LightToggle : ToggleGO
{
    [SerializeField] State state;   //Используется для отображения состояния в редакторе
    public GameObject[] lights;

    public enum State
    {
        Empty,
        Attention,
        Danger
    }

    public void Set(State state)
    {
        this.state = state;
        LightRefrash(state, lights);
    }

    void LightRefrash(State state, GameObject[] lights)
    {
        switch (state)
        {
            case State.Empty:
                Select(null);
                break;
            case State.Attention:
                Select(lights[0].name);
                break;
            case State.Danger:
                Select(lights[1].name);
                break;
            default:
                break;
        }
    }

}
