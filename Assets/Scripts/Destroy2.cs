using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Audio;

public class Destroy2 : MonoBehaviour
{
    public KillCounter2 killCounterScript;
    public ParticleSystem hitSFX;
    public AudioClip impactSFX;
    public GameObject destroySoundObject; // Reference to the DestroySound GameObject

    void Start()
    {
        killCounterScript = GameObject.Find("KCO").GetComponent<KillCounter2>();

        if (destroySoundObject == null)
        {
            Debug.LogError("DestroySound object is not assigned in the Inspector!");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Increment kill counter
        killCounterScript.AddKill();
        Debug.Log("Target eliminated!");

        if (destroySoundObject != null)
        {
            AudioSource destroySoundAudioSource = destroySoundObject.GetComponent<AudioSource>();
            if (destroySoundAudioSource != null)
            {
                destroySoundAudioSource.PlayOneShot(impactSFX);
            }
            else
            {
                Debug.LogError("DestroySound GameObject does not have an AudioSource component!");
            }
        }
        ParticleSystem instantiatedParticle = Instantiate(hitSFX, transform.position, Quaternion.identity);
        instantiatedParticle.Play();
        StartCoroutine(DestroyAfterDelay());
    }
    IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(0.01f);
        Destroy(gameObject);
    }
}