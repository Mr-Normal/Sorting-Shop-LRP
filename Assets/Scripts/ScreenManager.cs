using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    public Timer endTimer;
    public ScreenToggle toggle;

    void Update()
    {
        if(toggle.Get() == ScreenToggle.State.Game)
        {
            if (GameIsEnd())
            {
                toggle.Set(ScreenToggle.State.End);
            }
        }
    }

    bool GameIsEnd()
    {
        return endTimer.Progress() >= 1;
    }
}
