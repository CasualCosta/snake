using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance { get; private set; }
    [SerializeField] AudioSource source;
    [SerializeField] List<AudioClip> clips;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            return;
        }
        Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!source.isPlaying)
        {
            clips.Add(clips[0]);
            clips.RemoveAt(0);
            source.clip = clips[0];
            source.Play();
        }
    }
}
