using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class KillCounter : MonoBehaviour
{
    // public AudioClip winSFX;
    // public GameObject winSoundObject;
    private int kills = 0;

    public void AddKill()
    {
        kills++;
    }

    void Update()
    {
        if (kills >= 18)
        {
            StartCoroutine(DestroyAfterDelay());
        }
    }

    // private void PlayWinSound()
    // {
    //     AudioSource winAudioSource = winSoundObject.GetComponent<AudioSource>();
    //     winAudioSource.PlayOneShot(winSFX);
    // }

    private void LoadSceneFunction()
    {
        SceneManager.LoadScene("Scenes/Level 2");
    }

    IEnumerator DestroyAfterDelay()
    {
        // PlayWinSound();
        yield return new WaitForSeconds(2f);
        LoadSceneFunction();
    }
}
