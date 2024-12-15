using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Bullet : MonoBehaviour
{
    public GameObject impactEffect;
    public AudioClip impactSound;
    void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Enemy"))
        {
            Instantiate(impactEffect, collision.contacts[0].point, Quaternion.LookRotation(collision.contacts[0].normal));
            AudioSource.PlayClipAtPoint(impactSound, collision.contacts[0].point);
        }
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.enabled = false;
        }
        StartCoroutine(DestroyAfterDelay());
    }
    IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(0.01f);
        Destroy(gameObject);
    }
}
