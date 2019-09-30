using UnityEngine;

public class Slider3D : MonoBehaviour, Slider
{
    public Animator sliderAnimator;

    /// <summary> Указывает - на какую долю заполнен ползунок </summary>
    /// <param name="progress"> От 0 до 1 включительно </param>
    public void SetProgress(float progress)
    {
        sliderAnimator.PlayInFixedTime(0, 0, progress);
    }

}