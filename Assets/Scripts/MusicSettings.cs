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
    private float _minVolume = -80f;
    private float _maxVolume = 0f;

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
            _audioMixer.audioMixer.SetFloat("MasterVolume", _minVolume);
        }
    }

    public void ChangeMasterVolume(float volume)
    {
        _masterVolume = Mathf.Lerp(_minVolume, _maxVolume, volume);
        _audioMixer.audioMixer.SetFloat("MasterVolume", _masterVolume);
    }

    public void ChangeBackgroundVolume(float volume)
    {
        _audioMixer.audioMixer.SetFloat("BackgroundVolume", Mathf.Log10(volume) * 20);
    }

    public void ChangeMusicVolume(float volume)
    {
        _audioMixer.audioMixer.SetFloat("MusicVolume", Mathf.Log10(volume) * 20);
    }
}