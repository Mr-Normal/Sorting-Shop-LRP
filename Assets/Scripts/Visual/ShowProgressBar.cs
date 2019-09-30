using UnityEngine;

public class ShowProgressBar : MonoBehaviour
{
    public GameObject sliderGO;

    public void Set(float progress)
    {
        Slider slider = sliderGO.GetComponent<Slider>();
        slider.SetProgress(progress);
    }
}
