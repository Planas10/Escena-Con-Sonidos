using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;
    AudioSource ambient;
    AudioSource effects;
    AudioMixer mixer;
    public static AudioManager instance 
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject("Audio Manager");
                go.AddComponent<AudioManager>();
                DontDestroyOnLoad(go);
            }
            return _instance;
        }
    }
    private void Awake()
    {
        _instance = this;
        ambient = gameObject.AddComponent<AudioSource>();
        effects = gameObject.AddComponent<AudioSource>();

        mixer = Resources.Load("AudioMixer") as AudioMixer;

        ambient.outputAudioMixerGroup = mixer.FindMatchingGroups("Ambient")[0];
        effects.outputAudioMixerGroup = mixer.FindMatchingGroups("Effects")[0];
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void PlaySound() 
    {
        print("Pisadas");
    }
    public void PlayEffect(AudioClip clip) 
    {
        effects.PlayOneShot(clip);
    }
    public void PlayEffect(List<AudioClip> clip)
    {
        effects.PlayOneShot(clip[Random.Range(0,clip.Count)]);
    }
    public void PlayAmbient(AudioClip clip) 
    {
        ambient.PlayOneShot(clip);
    }
    public void PlayPlayAmbientEffect(List<AudioClip> clip)
    {
        ambient.PlayOneShot(clip[Random.Range(0, clip.Count)]);
    }
}
