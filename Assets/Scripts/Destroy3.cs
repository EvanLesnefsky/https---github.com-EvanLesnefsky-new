using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Audio;

public class Destroy3 : MonoBehaviour
{
    public KillCounter3 killCounterScript;
    public ParticleSystem hitSFX;
    public AudioClip impactSFX;
    public AudioClip hitMarker;
    public GameObject destroySoundObject;
    public GameObject hitMarkerObject;
    private int health = 100;

    void Start()
    {
        killCounterScript = GameObject.Find("KCO").GetComponent<KillCounter3>();
    }

    void OnCollisionEnter(Collision collision)
    {
        health--;
        AudioSource hitMarkerAudioSource = hitMarkerObject.GetComponent<AudioSource>();
        hitMarkerAudioSource.PlayOneShot(hitMarker);

        if (health <= 0)
        {
            killCounterScript.AddKill();
            AudioSource destroySoundAudioSource = destroySoundObject.GetComponent<AudioSource>();
            destroySoundAudioSource.PlayOneShot(impactSFX);
            ParticleSystem instantiatedParticle = Instantiate(hitSFX, transform.position, Quaternion.identity);
            instantiatedParticle.Play();
            StartCoroutine(DestroyAfterDelay());
        }
    }

    IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(0.01f);
        Destroy(gameObject);
    }
}
