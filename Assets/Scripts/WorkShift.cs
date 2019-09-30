using UnityEngine;

public static class WorkShift
{
    static float score;

    /// <summary> Конец рабочей смены </summary>
    public static void End()
    {
        Application.Quit();
    }

    public static float Score
    {
        get
        {
            return score;
        }
    }

    public static void AddScore(float score)
    {
        WorkShift.score += score;
    }

}
