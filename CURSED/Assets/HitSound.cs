using UnityEngine;

public class HitSound : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] hitClips;
    [SerializeField]
    private AudioClip[] monsterClips;
    private AudioSource audioSource;
    private TerrainDetector terrainDetector;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

   public void PlayHit()
    {
        AudioClip clip = GetRandomClip();
        audioSource.PlayOneShot(clip);
    }
    void Start()
    {
        if (monsterClips != null)
        {
            CallAudio();
        }
    }


    void CallAudio()
    {
        Invoke("RandomSoundness", 15);
    }

    void RandomSoundness()
    {
        //AudioClip clip = monsterClips[UnityEngine.Random.Range(0, monsterClips.Length)];
        AudioClip clip = monsterClips[0];
        audioSource.PlayOneShot(clip);
        CallAudio();
    }
    private AudioClip GetRandomClip()
    {
        return hitClips[UnityEngine.Random.Range(0, hitClips.Length)];
    }
}