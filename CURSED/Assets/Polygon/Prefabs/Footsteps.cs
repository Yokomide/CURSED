using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] clips;

    private AudioSource audioSource;


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Step()
    {
        AudioClip clip = GetRandomStepClip();
        audioSource.PlayOneShot(clip);
    }

    public void Fall()
    {
        AudioClip clip = clips[11];
        audioSource.PlayOneShot(clip);
    }


    private AudioClip GetRandomStepClip()
    {
        return clips[Random.Range(0, 4)];
    }
}
