using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    [HideInInspector] public UnityEvent onPickUp;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject != SnakeHead.Instance.gameObject)
            return;
        ScoreManager.Instance.IncrementScore();
        onPickUp?.Invoke();
        onPickUp.RemoveAllListeners();
        Destroy(gameObject);
    }
}
