using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class TransitionManager : MonoBehaviour
{
    public static TransitionManager Instance { get; private set; }
    enum TransitionType { Opening, Closing }
    [SerializeField] TextMeshProUGUI textMesh;
    [SerializeField] Button button;
    [SerializeField] RectTransform panel;
    [SerializeField] float transitionTime, waitTime;
    [SerializeField] LeanTweenType tweenType;

    
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        Open();
        Ender.Instance.onEnd.AddListener(Close);
    }

    void Open() => StartCoroutine(TransitionCoroutine(TransitionType.Opening));
    void Close() => StartCoroutine(TransitionCoroutine(TransitionType.Closing));
    IEnumerator TransitionCoroutine(TransitionType type)
    {
        Time.timeScale = type == TransitionType.Opening ? 0 : 1;
        float targetAlpha = type == TransitionType.Opening ? 0 : 1;
        panel.LeanAlpha(targetAlpha, transitionTime)
            .setEase(tweenType)
            .setIgnoreTimeScale(true);
        yield return new WaitForSecondsRealtime(transitionTime + waitTime);
        if(type == TransitionType.Closing)
        {
            button.gameObject.SetActive(true);
            textMesh.gameObject.SetActive(true);
        }
        if (type == TransitionType.Closing)
            textMesh.text = $"Score: {ScoreManager.Instance.Score:D2}";
        Time.timeScale = type == TransitionType.Opening ? 1 : 0;
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(gameObject.scene.name);
    }
}
