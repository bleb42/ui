using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource), typeof(Button))]
public class ButtonMusicPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip _audioClip;

    private AudioSource _audioSource;
    private Button _button;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(PlayAudioClip);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(PlayAudioClip);
    }

    private void PlayAudioClip()
    {
        _audioSource.PlayOneShot(_audioClip);
    }
}
