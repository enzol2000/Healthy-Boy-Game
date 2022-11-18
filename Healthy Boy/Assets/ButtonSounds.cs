using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSounds : MonoBehaviour
{
    public AudioSource mAudioSource;
    public AudioClip mHouverSound;

    public void MouseHouver()
    {
        mAudioSource.PlayOneShot(mHouverSound, 0.3f);
    }
}
