using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public bool isLoop;
    [Range(0, 86400)] public float maxSecond = 1;
    float secondToEnd;
    public UnityEvent OnEnd;
    bool canCalling = true;

    void Start()
    {
        secondToEnd = maxSecond;
    }

    void Update()
    {
        if(secondToEnd <= 0)
        {
            if (canCalling)
            {
                OnEnd?.Invoke();
                canCalling = false;
            }
            if (isLoop) { Restart(); }
        }
        else
        {
            secondToEnd -= Time.deltaTime;
        }
    }

    public void Restart()
    {
        secondToEnd = maxSecond;
        canCalling = true;
    }

    public float Progress()
    {
        return Progress(maxSecond);
    }

    public float Progress(float maxSecond)
    {
        float progress = 1 - secondToEnd / maxSecond;
        return Mathf.Max(0, progress);
    }
}
