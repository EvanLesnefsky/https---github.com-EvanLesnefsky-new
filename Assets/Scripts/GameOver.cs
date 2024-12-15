using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GameOver : MonoBehaviour
{
    public AudioClip deathSFX;
    private bool isGameOver = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!isGameOver && (other.gameObject.tag == "Enemy" || other.gameObject.tag == "BulletHitBox"))
        {
            isGameOver = true;
            PlayDeathSFX();
            StartCoroutine(DestroyAfterDelay());
        }
    }

    private void PlayDeathSFX()
    {
        AudioSource.PlayClipAtPoint(deathSFX, transform.position);
    }

    private void ResetGame()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

    IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(0.5f);
        ResetGame();
    }
}
