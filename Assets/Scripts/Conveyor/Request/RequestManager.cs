using UnityEngine;

public class RequestManager : MonoBehaviour
{
    public Request request;
    public AnimationApply animationApply;
    new public LightToggle light;
    public Timer timer;
    public ShowProgressBar progressBar;
    [Range(0, 100)] public float alertSeconds;
    public RequestStage requestStage;

    void Start()
    {
        ChangeState(requestStage);
    }

    void Update()
    {
        if (IsEmergencyRestart())
        {
            ChangeState(RequestStage.Ready);
        }
        else
        {
            if (IsStageEnd())
            {
                ChangeState(NextStage(requestStage));
            }
        }
    }

    void ChangeState(RequestStage newStage)
    {
        switch (newStage)
        {
            case RequestStage.Ready:
                SetReady();
                break;
            case RequestStage.Progress:
                SetProgress();
                break;
            case RequestStage.End:
                SetEnd();
                break;
            default:
                break;
        }
    }

    void SetReady()
    {
        request.Clear();
        SetState(RequestStage.Ready, false, LightToggle.State.Empty, false);
    }

    void SetProgress()
    {
        request.Restart();
        SetState(RequestStage.Progress, true, LightToggle.State.Attention, false);
    }

    void SetEnd()
    {
        SetState(RequestStage.End, true, LightToggle.State.Danger, true);
    }

    void SetState(RequestStage requestStage, bool requestEnable, LightToggle.State lightState, bool showTimer)
    {
        timer.Restart(GetSeconds(requestStage));
        this.requestStage = requestStage;
        request.SetEnable(requestEnable);
        light.Set(lightState);
        progressBar.gameObject.SetActive(showTimer);
    }

    float GetSeconds(RequestStage stage)
    {
        switch (stage)
        {
            case RequestStage.Ready:
                return UnityEngine.Random.Range(3, 10);
            case RequestStage.Progress:
                return 30 * request.GetChestLeft();
            case RequestStage.End:
                return 30;
            default:
                return 0;
        }
    }

    bool IsStageEnd()
    {
        return timer.Progress() >= 1;
    }

    static RequestStage NextStage(RequestStage thisStage)
    {
        switch (thisStage)
        {
            case RequestStage.Ready:
                return RequestStage.Progress;
            case RequestStage.Progress:
                return RequestStage.End;
            case RequestStage.End:
                return RequestStage.Ready;
            default:
                Debug.LogError("Ошибка");
                return RequestStage.Ready;
        }
    }

    //Возвращает true если необходимо срочно скинуть состояние requestStage на "Ready"
    bool IsEmergencyRestart()
    {
        switch (requestStage)
        {
            case RequestStage.Ready:
                return false;
            case RequestStage.Progress:
                return request.IsEmpty;     //Скидываем состояние если заказ пуст
            case RequestStage.End:
                return request.IsEmpty;     //Скидываем состояние если заказ пуст
            default:
                return false;
        }
    }
}
