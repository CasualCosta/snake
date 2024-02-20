using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public static Timer Instance { get; private set; }
    [SerializeField] float sessionDuration = 20;
    float timeLeft;
    public float TimeLeft
    {
        get => timeLeft;
        set
        {
            timeLeft = value;
            onDurationChange?.Invoke(value);
        }
    }
    public UnityEvent<float> onDurationChange;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        timeLeft = sessionDuration;
        StartCoroutine(EndingCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        if(TimeLeft > 0)
        TimeLeft -= Time.deltaTime;
    }
    IEnumerator EndingCoroutine()
    {
        yield return new WaitForSeconds(sessionDuration);
        EndSession();

    }
    void EndSession()
    {
        Ender.Instance.End();
    }
}
