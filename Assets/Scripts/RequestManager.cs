using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestManager : MonoBehaviour
{
    public Request request;
    public AnimationApply animationApply;
    public LightSwitch lightSwitch;
    public Timer timer;
    public ShowProgressBar progressBar;
    [Range(0, 100)] public float alertSeconds;

    void Start()
    {
        
    }

    void Update()
    {
        LightSwitch.State state = GetRequestState();
        lightSwitch.state = state;
        TryShowAlertTime(state);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Chest")
        {
            request.ProcessOrder(other.gameObject);
            animationApply.AddAndPlayAnimation(other.gameObject);
        }
    }

    void TryShowAlertTime(LightSwitch.State state)
    {
        float progress = timer.Progress(alertSeconds);
        if (state == LightSwitch.State.Danger)
        {
            progressBar.gameObject.SetActive(true);
            progressBar.Set(progress);
            Debug.Log(progress);
        }
        else
        {
            progressBar.gameObject.SetActive(false);
        }
    }

    LightSwitch.State GetRequestState()
    {
        if (!request.gameObject.activeSelf)
        {
            return LightSwitch.State.Empty;
        }
        if (timer.Progress(alertSeconds) == 0)
        {
            return LightSwitch.State.Attention;
        }
        else
        {
            return LightSwitch.State.Danger;
        }
    }

    void ChangeState(LightSwitch.State newState)
    {

    }


}
