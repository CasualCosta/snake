using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [HideInInspector] public UnityEvent<int> onScoreChange;
    public static ScoreManager Instance { get; private set; }
    [SerializeField] int score;
    public int Score 
    { 
        get => score;
        set
        {
            score = value;
            onScoreChange?.Invoke(value);
        }
    }
    public void IncrementScore() => Score++;
    private void Awake()
    {
        Instance = this;
    }
}
