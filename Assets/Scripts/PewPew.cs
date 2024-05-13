using UnityEngine;


public class PewPew : MonoBehaviour
{
    [SerializeField] ParticleSystem bang = null;
    public Transform bulletSpawn;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;
    public AudioClip shootingSound;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
