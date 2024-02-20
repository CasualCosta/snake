using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class Ender : MonoBehaviour
{
    public static Ender Instance { get; private set; }
    public UnityEvent onEnd;
    bool ending;
    private void Awake()
    {
        Instance = this;
    }
    
    public void End()
    {
        if (ending)
            return;
        ending = true;
        onEnd?.Invoke();
    }
}
