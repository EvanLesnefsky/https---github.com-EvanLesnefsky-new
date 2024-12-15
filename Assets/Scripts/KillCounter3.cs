using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class KillCounter3 : MonoBehaviour
{
    // public AudioClip winSFX;
    // public GameObject winSoundObject;
    // public AudioClip yaySFX;
    // public GameObject yaySoundObject;
    private int kills = 0;

    public void AddKill()
    {
        kills++;
    }

    void Update()
    {
        if (kills >= 1)
        {
            StartCoroutine(DestroyAfterDelay());
        }
    }

    // private void PlayWinSound()
    // {
    //     AudioSource winAudioSource = winSoundObject.GetComponent<AudioSource>();
    //     winAudioSource.PlayOneShot(winSFX);
    //     AudioSource yayAudioSource = yaySoundObject.GetComponent<AudioSource>();
    //     yayAudioSource.PlayOneShot(yaySFX);
    // }
    // private void PlayYaySound()
    // {
    //     AudioSource yayAudioSource = yaySoundObject.GetComponent<AudioSource>();
    //     yayAudioSource.PlayOneShot(yaySFX);
    // }

    private void LoadSceneFunction()
    {
        SceneManager.LoadScene("Scenes/MainScene");
    }

    IEnumerator DestroyAfterDelay()
    {
        // PlayWinSound();
        // PlayYaySound();
        yield return new WaitForSeconds(2f);
        LoadSceneFunction();
    }
}
