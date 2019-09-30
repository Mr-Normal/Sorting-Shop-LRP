using UnityEngine;

public class Timer : MonoBehaviour
{
    [Tooltip("Если true - таймер после завершения перезапускается")]public bool isLoop;
    [Range(0, 86400)] public float maxSecond = 1;
    [SerializeField] float secondToEnd;

    void Start()
    {
        secondToEnd = maxSecond;
    }

    void Update()
    {
        if(secondToEnd <= 0)
        {
            secondToEnd = 0;
            if (isLoop) { Restart(); }
        }
        else
        {
            secondToEnd -= Time.deltaTime;
        }
    }

    public void Restart()
    {
        Restart(maxSecond);
    }

    public void Restart(float maxSecond)
    {
        this.maxSecond = maxSecond;
        secondToEnd = maxSecond;
    }

    /// <summary> Сколько осталось времени до конца (возвращает в долях - от 0 до 1) </summary>
    public float Progress()
    {
        return Progress(maxSecond);
    }

    /// <summary> Сколько осталось времени до конца (возвращает в долях - от 0 до 1) </summary>
    /// <param name="maxSecond"></param>
    public float Progress(float maxSecond)
    {
        float progress = 1 - secondToEnd / maxSecond;
        return Mathf.Max(0, progress);
    }
}
