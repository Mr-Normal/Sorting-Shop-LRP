using UnityEngine;

public class ScreenToggle: ToggleGO
{
    [SerializeField] State state;
    public GameObject[] screens;

    public enum State
    {
        Game,
        End
    }

    void Update()
    {
        Set(state);
    }

    public void Set(State state)
    {
        this.state = state;
        switch (state)
        {
            case State.Game:
                Select(screens[0].name);
                break;
            case State.End:
                Select(screens[1].name);
                break;
            default:
                break;
        }

    }

    public State Get()
    {
        return state;
    }


}
