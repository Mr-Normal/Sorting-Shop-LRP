using UnityEngine;

public class ShowTimer : MonoBehaviour
{
    public Timer timer;
    public ShowProgressBar progressBar;
    void Update()
    {
        progressBar.Set(timer.Progress());
    }
}
