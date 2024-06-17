using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(MusicToggler))]
public class SoundChanger : MonoBehaviour
{
    private const string BackgroundVolume = "BackgroundVolume";
    private const string ButtonsVolume = "ButtonsVolume";
    private const string MasterVolume = "MasterVolume";

    [SerializeField] private AudioMixerGroup _audioMixer;
    [SerializeField] private Slider _overallVolume;
    [SerializeField] private Slider _buttonsVolume;
    [SerializeField] private Slider _musicVolume;

    private MusicToggler _musicToggler;

    private void Awake()
    {
        _musicToggler = GetComponent<MusicToggler>();
    }

    private void Start()
    {
        SetButtonsVolume(_buttonsVolume.value);
        SetBackgroundVolume(_musicVolume.value);
        SetMasterVolume(_overallVolume.value);
    }

    private void OnEnable()
    {
        _overallVolume.onValueChanged.AddListener(SetMasterVolume);
        _buttonsVolume.onValueChanged.AddListener(SetButtonsVolume);
        _musicVolume.onValueChanged.AddListener(SetBackgroundVolume);
    }

    private void OnDisable()
    {
        _overallVolume.onValueChanged.RemoveListener(SetMasterVolume);
        _buttonsVolume.onValueChanged.RemoveListener(SetButtonsVolume);
        _musicVolume.onValueChanged.RemoveListener(SetBackgroundVolume);
    }


    private void SetButtonsVolume(float volume)
    {
        _audioMixer.audioMixer.SetFloat(ButtonsVolume, Mathf.Log10(volume) * 20);
    }

    private void SetMasterVolume(float volume)
    {
        if (_musicToggler.IsMasterVolumeOn)
            _audioMixer.audioMixer.SetFloat(MasterVolume, Mathf.Log10(volume) * 20);
    }

    private void SetBackgroundVolume(float volume)
    {
        _audioMixer.audioMixer.SetFloat(BackgroundVolume, Mathf.Log10(volume) * 20);
    }
}
