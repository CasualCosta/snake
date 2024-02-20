using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMesh;
    // Start is called before the first frame update
    void Start()
    {
        ScoreManager.Instance.onScoreChange.AddListener(DisplayScore);
    }

    void DisplayScore(int value)
    {
        textMesh.text = $"Score: {value:D3}";
    }
}
