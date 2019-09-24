using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface RequestStage
{
    RequestFlag GetStage();

}

public enum RequestFlag
{
    Ready,
    Progress,
    End
}