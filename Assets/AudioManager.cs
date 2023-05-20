using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;
    AudioSource ambient;
    AudioSource effects;
    AudioSource fly;
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
        fly = gameObject.AddComponent<AudioSource>();

        mixer = Resources.Load("AudioMixer") as AudioMixer;

        ambient.outputAudioMixerGroup = mixer.FindMatchingGroups("Ambient")[0];
        effects.outputAudioMixerGroup = mixer.FindMatchingGroups("Effects")[0];
        fly.outputAudioMixerGroup = mixer.FindMatchingGroups("Fly")[0];
    }
    public void ActivateIndoor()
    {
        effects.outputAudioMixerGroup.audioMixer.FindSnapshot("indoor").TransitionTo(0.2f);
    }
    public void ActivateOutdoor()
    {
        effects.outputAudioMixerGroup.audioMixer.FindSnapshot("outdoor").TransitionTo(0.2f);
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
        effects.PlayOneShot(clip[Random.Range(0, clip.Count)]);
    }
    public void PlayEffectFly(AudioClip clip)
    {
        fly.Play();
        fly.PlayOneShot(clip);
        fly.loop = true;
    }
    public void StopEffectFly() 
    {
        fly.loop = false;
        fly.Stop();
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
