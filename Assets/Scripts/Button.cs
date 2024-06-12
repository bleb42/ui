using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Button : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void PlaySound()
    {
        if (_audioSource.clip != null)
            _audioSource.PlayOneShot(_audioSource.clip);
    }
}
