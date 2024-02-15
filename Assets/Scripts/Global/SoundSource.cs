using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSource : MonoBehaviour
{
    private AudioSource _audioSource;

    public void Play(AudioClip clip, float seVolum)
    {
        if (_audioSource == null)
        {
            _audioSource = GetComponent<AudioSource>();
        }

        CancelInvoke();
        _audioSource.clip = clip;
        _audioSource.volume = seVolum;
        _audioSource.Play();

        Invoke("Disable", clip.length + 2);
    }

    public void Disable()
    {
        _audioSource.Stop();
        gameObject.SetActive(false);
    }
}
