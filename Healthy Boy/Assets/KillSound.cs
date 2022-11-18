using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillSound : MonoBehaviour
{
    AudioSource mAudioSource;
    // Start is called before the first frame update
    void Start()
    {
        mAudioSource = GetComponent<AudioSource>();
        mAudioSource.volume = 0.3f;
        StartCoroutine(KillSoundTimer());
    }

    IEnumerator KillSoundTimer()
    {
        yield return new WaitForSeconds(mAudioSource.clip.length);
        Destroy(gameObject);
    }
}
