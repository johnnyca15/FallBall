using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBehavior : MonoBehaviour
{
    public static AudioBehavior Instance;
    private AudioSource audioSource;

    private void Awake()
    {
        if (Instance !=null && Instance !=this)
        {
            Destroy(Instance);
        }
        else
        {
            Instance = this;
            audioSource = GetComponent<AudioSource>();
        }
    }

    public void PlaySound(AudioClip clip, float volume = 1.0f)
    {
        audioSource.PlayOneShot(clip, volume);
    }





}