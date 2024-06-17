using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MusicToggler : MonoBehaviour
{
    private const string MasterVolume = "MasterVolume";

    [SerializeField] private AudioMixerGroup _audioMixer;
    [SerializeField] private Toggle _musicToggle;

    public bool IsMasterVolumeOn;

    private void Awake()
    {
        IsMasterVolumeOn = _musicToggle.isOn;
    }

    private void Start()
    {
        ToggleMusik(IsMasterVolumeOn);
    }

    private void OnEnable()
    {
        _musicToggle.onValueChanged.AddListener(ToggleMusik);
    }

    private void OnDisable()
    {
        _musicToggle.onValueChanged.RemoveListener(ToggleMusik);
    }

    private void ToggleMusik(bool enabled)
    {
        if (enabled)
        {
            _audioMixer.audioMixer.SetFloat(MasterVolume, 0);
            IsMasterVolumeOn = true;
        }
        else
        {
            _audioMixer.audioMixer.SetFloat(MasterVolume, -80);
            IsMasterVolumeOn = false;
        }
    }
}
