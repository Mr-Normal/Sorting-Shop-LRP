using UnityEngine;
using UnityEngine.UI;

public class Slider2D : MonoBehaviour, Slider
{
    public Image sliderImage;

    /// <summary> Указывает - на какую долю заполнен ползунок </summary>
    /// <param name="progress"> От 0 до 1 включительно </param>
    public void SetProgress(float progress)
    {
        sliderImage.fillAmount = progress;
    }

}
