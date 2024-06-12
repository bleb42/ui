using UnityEngine;
using UnityEngine.Audio;

public class SoundControleer : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _audioMixer;

    public void ToggleMusik(bool enabled)
    {
        if (enabled)
            _audioMixer.audioMixer.SetFloat("MasterVolume", 0);
        else
            _audioMixer.audioMixer.SetFloat("MasterVolume", -80);
    }

    public void SetButtonsVolume(float volume)
    {
        _audioMixer.audioMixer.SetFloat("ButtonsVolume", Mathf.Log10(volume) * 20);
    }

    public void SetMasterVolume(float volume)
    {
        _audioMixer.audioMixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);
    }

    public void SetBackgroundVolume(float volume)
    {
        _audioMixer.audioMixer.SetFloat("BackgroundVolume", Mathf.Log10(volume) * 20);
    }
}
