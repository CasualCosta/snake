using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMesh;

    private void Start()
    {
        Timer.Instance.onDurationChange.AddListener(DisplayTime);
    }

    void DisplayTime(float time) => textMesh.text = $"Time: {(int)time:D2}";
}
