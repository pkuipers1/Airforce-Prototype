using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySounds : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip[] audioClips;
    
    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }
}
