using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class MusicManager : MonoBehaviour
{

    private static MusicManager _instance;

    private void Awake()
    {
        if(_instance==null)
        {
            _instance = this;
        } else
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this);
    }

    public static MusicManager instance()
    {
        return _instance;
    }

    private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        if (!source.isPlaying)
        {
            source.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
