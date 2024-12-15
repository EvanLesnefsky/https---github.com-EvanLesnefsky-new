using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class LevelOneWin : MonoBehaviour
{
    public AudioClip winSound;
    private bool isGameOver = false;
    private void OnTriggerEnter(Collider other)
    {
        if (!isGameOver && (other.gameObject.tag == "Finish"))
        {
            isGameOver = true;
            PlayWinSFX();
            StartCoroutine(DestroyAfterDelay());
        }
    }
    private void PlayWinSFX()
    {
        AudioSource.PlayClipAtPoint(winSound, transform.position);
    }
    private void ResetGame()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("Scenes/Level 1");
    }
    IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(2f);
        ResetGame();
    }
}

