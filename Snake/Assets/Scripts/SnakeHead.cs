using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHead : MonoBehaviour
{
    public static SnakeHead Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }
}
