using System;
using System.Collections;
using UnityEngine;


public class PewPew : MonoBehaviour
{
    [SerializeField] ParticleSystem bang = null;
    public Transform bulletSpawn;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;
    public AudioClip shootingSound;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    IEnumerator Start()
    {
        // I don't know why this works, fixes bullet spawning issue
        yield return new WaitForSeconds(.01f);
        enabled = !enabled;
        yield return new WaitForEndOfFrame();
        enabled = !enabled;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            // Play shooting sound
            if (shootingSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(shootingSound);
            }

            var bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawn.forward * bulletSpeed;
            
            Bang();
        }
    }

    public void Bang()
    {
        bang.Play();
    }
}
