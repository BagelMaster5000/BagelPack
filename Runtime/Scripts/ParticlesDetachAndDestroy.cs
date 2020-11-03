using System.Collections;
using UnityEngine;

// When activated, detaches from all parents, plays particle effect from attached ParticleSystem, and destroys itself when finished.
[RequireComponent(typeof(ParticleSystem))]
public class ParticlesDetachAndDestroy : MonoBehaviour
{
    ParticleSystem particles;

    public void Activate()
    {
        transform.localScale = Vector3.one;
        this.transform.parent = null;
        particles = GetComponent<ParticleSystem>();
        particles.Play();
        StartCoroutine(DestroyWhenDone());
    }

    IEnumerator DestroyWhenDone()
    {
        while (particles.isPlaying)
            yield return null;
        Destroy(this.gameObject);
    }
}
