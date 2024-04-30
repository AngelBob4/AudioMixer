using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicSettings : MonoBehaviour
{
    [SerializeField] private List<AudioClip> _audioClips = new List<AudioClip>();
    [SerializeField] private AudioMixerGroup _audioMixer;
    [SerializeField] private AudioSource _musicAudioSource;
    [SerializeField] private AudioSource _backGroundAudioSource;

    private float _masterVolume;

    public void SetSong(int index)
    {
        if (index < _audioClips.Capacity && index >= 0)
        {
            _musicAudioSource.clip = _audioClips[index];
            _musicAudioSource.Play();
        }
    }

    public void ToggleMusic(bool enabled)
    {
        if (enabled)
        {
            _audioMixer.audioMixer.SetFloat("MasterVolume", _masterVolume);
        }
        else
        {
            _audioMixer.audioMixer.SetFloat("MasterVolume", -80);
        }
    }

    public void ChangeMasterVolume(float volume)
    {
        _masterVolume = Mathf.Lerp(-80, 0, volume);
        _audioMixer.audioMixer.SetFloat("MasterVolume", _masterVolume);
    }

    public void ChangeBackgroundVolume(float volume)
    {
        _audioMixer.audioMixer.SetFloat("BackgroundVolume", Mathf.Lerp(-80, 0, volume));
    }

    public void ChangeMusicVolume(float volume)
    {
        _audioMixer.audioMixer.SetFloat("MusicVolume", Mathf.Lerp(-80, 0, volume));
    }
}