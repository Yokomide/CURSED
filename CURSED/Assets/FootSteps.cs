using UnityEngine;

public class FootSteps : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] stoneClips;
    [SerializeField]
    private AudioClip[] mudClips;
    [SerializeField]
    private AudioClip[] grassClips;

    private AudioSource audioSource;
    private TerrainDetector terrainDetector;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
       // terrainDetector = new TerrainDetector();
    }

    private void Step()
    {
        AudioClip clip = GetRandomClip();
        audioSource.PlayOneShot(clip);
    }
    private void StepChar1()
    {
        AudioClip clip = grassClips[0];
        audioSource.PlayOneShot(clip);
    }
    private void StepChar2()
    {
        AudioClip clip =  grassClips[1];
        audioSource.PlayOneShot(clip);
    }

    private AudioClip GetRandomClip()
    {
        //int terrainTextureIndex = terrainDetector.GetActiveTerrainTextureIdx(transform.position);
        return grassClips[UnityEngine.Random.Range(0, grassClips.Length)];
        //switch(terrainTextureIndex)
        //{
        //    case 0:
        //        return stoneClips[UnityEngine.Random.Range(0, stoneClips.Length)];
        //    case 1:
        //        return mudClips[UnityEngine.Random.Range(0, mudClips.Length)];
        //    case 2:
        //    default:
        //        return grassClips[UnityEngine.Random.Range(0, grassClips.Length)];
        //}

    }
}