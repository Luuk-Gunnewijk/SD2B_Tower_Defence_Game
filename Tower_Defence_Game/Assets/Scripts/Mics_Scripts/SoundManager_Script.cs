using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager_Script: MonoBehaviour
{
    [SerializeField] private static AudioSource audioSource;
    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public static void PlayOneShot(AudioClip clip)
    {
        audioSource.PlayOneShot(clip, 1.0f);
    }

    public static bool IsPlaying()
    {
        return audioSource.isPlaying;
    }
}
