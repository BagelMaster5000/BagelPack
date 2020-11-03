using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// When activated, detaches from all parents, plays sound from attached AudioSource, and destroys itself when finished.
[RequireComponent(typeof(AudioSource))]
public class SoundDetachAndDestroy : MonoBehaviour
{
    AudioSource sound;

    public void Activate()
    {
        this.transform.parent = null;
        sound = GetComponent<AudioSource>();
        sound.Play();
        StartCoroutine(DestroyWhenSilent());
    }

    IEnumerator DestroyWhenSilent()
    {
        while (sound.isPlaying)
            yield return null;
        Destroy(this.gameObject);
    }
}
