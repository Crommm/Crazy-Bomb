using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoSingleton<SoundManager>
{
    private AudioSource audio;

    [SerializeField] AudioClip[] clips;
    private void Awake()
    {
        base.Awake();
        audio = GetComponent<AudioSource>();
    }

    public void PlayFXSound(int index,float volumeFx)
    {
        audio.PlayOneShot(clips[index], volumeFx);
    }
}
