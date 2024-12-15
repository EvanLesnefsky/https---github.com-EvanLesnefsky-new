using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class EnemyShoot : MonoBehaviour
{
    public GameObject BulletTemplate;
    public float shootPower = 100f;
    public float shootInterval = 5f;
    public AudioClip enemyShotSFX;
    private float shootTimer;
    public ParticleSystem muzzle2Flash;
    [SerializeField]
    private GameObject playerTarget;

    void Start()
    {
        shootTimer = shootInterval;
        playerTarget = GameObject.FindGameObjectWithTag("Player");
    }
    void Shoot()
    {
        GameObject newBullet = Instantiate(BulletTemplate, transform.position, transform.rotation);
        newBullet.GetComponent<Rigidbody>().AddForce(transform.forward * shootPower);
        // GetComponent<AudioSource>().PlayOneShot(enemyShotSFX);
        AudioSource.PlayClipAtPoint(enemyShotSFX, transform.position);
        if (muzzle2Flash != null)
        {
            muzzle2Flash.Play();
        }
        newBullet.tag = "BulletHitBox";
    }
     void Update()
    {
        shootTimer -= Time.deltaTime;
        if (shootTimer <= 0f)
        {
            Shoot();
            shootTimer = shootInterval;
        }
    }
}
