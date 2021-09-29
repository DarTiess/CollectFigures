using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [System.Serializable]
    public class SoundClip
    {
        public SoundManager.Sound sound;
        public AudioClip audioClip;
    }
    public enum Sound
    {
        GamePlayMusic,
     
      Landing,
      Jump,
       GetFigure,
        PushOnPlace,

        Win,
        Fail,

    }
    public static SoundManager Instance { get; private set; }
    public SoundClip[] soundsArray;
    public AudioSource audioSounds;
    public AudioSource audioMusicInternal;

   

    private void Awake()
    {
        Instance = this;
    }

    public void PlaySound(Sound sound)
    {
        audioSounds.PlayOneShot(SetAudioClip(sound));
    }

    public void PlayMusicInternal(Sound sound)
    {
        audioMusicInternal.loop = true;
        audioMusicInternal.priority = 0;
        audioMusicInternal.clip = SetAudioClip(sound);
        audioMusicInternal.Play();
    }

    private AudioClip SetAudioClip(Sound sound)
    {
        foreach (SoundClip soundAudioClip in soundsArray)
        {
            if (soundAudioClip.sound == sound)
            {
                return soundAudioClip.audioClip;
            }
        }
        Debug.LogError("Sound" + sound + " not found!");
        return null;
    }
}
