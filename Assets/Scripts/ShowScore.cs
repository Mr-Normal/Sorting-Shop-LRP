using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowScore : MonoBehaviour
{
    public WorkShift workShift;
    Text text;

    private void Start()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        text.text = workShift.score.ToString();
    }
}
