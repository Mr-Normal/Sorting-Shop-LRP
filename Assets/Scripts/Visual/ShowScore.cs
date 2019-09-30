using UnityEngine;
using UnityEngine.UI;

public class ShowScore : MonoBehaviour
{
    Text text;

    private void Start()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        text.text = WorkShift.Score.ToString();
    }
}
