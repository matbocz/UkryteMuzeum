using System;
using UnityEngine;

public class AudioStateManager : MonoBehaviour
{
    [Header("Music")]
    [SerializeField] private AudioClip musicClip;
    [SerializeField] [Range(0f, 1f)] private float normalMusicVolume;
    [SerializeField] [Range(0f, 1f)] private float reducedMusicVolume;

    [Space(10)]
    public Sound[] voiceSounds;
    public Sound[] environmentSounds;

    private Sound[] sounds;

    AudioSource musicSource;

    public static AudioStateManager instance;

    private void Awake()
    {
        CreateInstance();

        CreateVoiceAudioSources();
        CreateEnvironmentAudioSources();
        ConcatenateAudioSources();
    }

    private void CreateInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
    }

    private void CreateVoiceAudioSources()
    {
        foreach (Sound sound in voiceSounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
        }
    }

    private void CreateEnvironmentAudioSources()
    {
        foreach (Sound sound in environmentSounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
        }
    }

    private void ConcatenateAudioSources()
    {
        sounds = new Sound[voiceSounds.Length + environmentSounds.Length];
        voiceSounds.CopyTo(sounds, 0);
        environmentSounds.CopyTo(sounds, voiceSounds.Length);
    }

    private void Start()
    {
        PlayMusic();
    }

    public void PlayMusic()
    {
        if (musicClip == null)
        {
            Debug.Log("Music not found!");
            return;
        }

        musicSource = gameObject.AddComponent<AudioSource>();
        musicSource.clip = musicClip;
        musicSource.volume = normalMusicVolume;
        musicSource.loop = true;

        musicSource.Play();
    }

    public void TurnDownMusic()
    {
        musicSource.volume = reducedMusicVolume;
    }

    public void TurnUpMusic()
    {
        musicSource.volume = normalMusicVolume;
    }

    public void PlaySound(string soundName)
    {
        Sound s = Array.Find(sounds, sound => sound.name == soundName);
        if (s == null)
        {
            Debug.Log("Sound " + soundName + " not found!");
            return;
        }

        s.source.Play();
    }

    public void StopSound(string soundName)
    {
        Sound s = Array.Find(sounds, sound => sound.name == soundName);
        if (s == null)
        {
            Debug.Log("Sound " + soundName + " not found!");
            return;
        }

        s.source.Stop();
    }
}
