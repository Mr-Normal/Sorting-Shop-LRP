using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageWaiting : MonoBehaviour, RequestStage
{
    public RequestFlag GetStage()
    {
        return RequestFlag.Ready;
    }

}
