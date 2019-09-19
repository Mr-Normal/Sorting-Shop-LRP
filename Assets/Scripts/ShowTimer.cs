using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowTimer : MonoBehaviour
{
    public Slider slider;
    public Timer timer;

    void Update()
    {
        slider.Progress = timer.Progress();
    }
}
