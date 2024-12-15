using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Audio;

public class PlayerShoot : MonoBehaviour
{
    public GameObject BulletTemplate;
    // public GameObject ShellTemplate;
    public float shootPower = 100f;
    public AudioClip gunShotSFX;
    public ParticleSystem muzzleFlash;

    public InputActionReference trigger;

    void Start()
    {
        trigger.action.performed += Shoot;
    }

    void Shoot(InputAction.CallbackContext __)
    {
        GameObject newBullet = Instantiate(BulletTemplate, transform.position, transform.rotation);
        newBullet.transform.rotation *= Quaternion.Euler(0, 90, 0);
        newBullet.transform.position += (newBullet.transform.forward * 0.2f) + (transform.up * 0.1f);
        newBullet.GetComponent<Rigidbody>().AddForce(newBullet.transform.forward * shootPower);

        // GameObject newShell = Instantiate(ShellTemplate, transform.position, transform.rotation);
        // newShell.transform.rotation *= Quaternion.Euler(0, 180, 0);
        // newShell.transform.position += transform.up * 0.1f;
        // newShell.GetComponent<Rigidbody>().AddForce(newShell.transform.forward * (shootPower / 50f));

        GetComponent<AudioSource>().PlayOneShot(gunShotSFX);
        if (muzzleFlash != null)
        {
            muzzleFlash.Play();
        }
    }
}
