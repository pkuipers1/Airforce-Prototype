using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    [SerializeField] private float shootSpeed;
    [SerializeField] private float shootTimer;
    
    [SerializeField] private List<Transform> bulletSpawns;
    [SerializeField] private GameObject bullet;
    
    [SerializeField] private bool isShooting;
    [SerializeField] private bool autoShooting;
    [SerializeField] public static bool autoFire;
    
    [SerializeField] public List<ParticleSystem> muzzleFlash;
    
    [SerializeField] public List<AudioClip> machineGunSounds;
    [SerializeField] public AudioSource spitfireAudio;
    [SerializeField] private List<AudioClip> sounds;
    
    [SerializeField] private float soundDelay;


    // Start is called before the first frame update
    void Start()
    {
        autoShooting = false;
        isShooting = false;

        spitfireAudio = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !autoShooting)
        {
            autoShooting = true;
            autoFire = true;
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            autoShooting = false;
            autoFire = false;
        }
        
        if (Input.GetKey(KeyCode.Space) && !isShooting && !autoShooting)
        {
            StartCoroutine(Shoot());
        }
        else if (autoShooting && !isShooting)
        {
            StartCoroutine(Shoot());
        }
        
        
    }

    IEnumerator Shoot()
    {
        isShooting = true;
        int flashIndex = 0;

        foreach (var spawn in bulletSpawns)
        {
            var newBullet = Instantiate(bullet, spawn.position, Quaternion.identity);
            newBullet.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, shootSpeed * Time.deltaTime);

            muzzleFlash[flashIndex].Play();
            flashIndex++;
            
            StartCoroutine(ShootSounds());
        }
        
        yield return new WaitForSeconds(shootTimer);
        isShooting = false;
    }

    IEnumerator ShootSounds()
    {
        spitfireAudio.PlayOneShot(machineGunSounds[0]);
        yield return new WaitForSeconds(0.5f);
        spitfireAudio.PlayOneShot(machineGunSounds[1]);
        yield return new WaitForSeconds(0.5f);
    }
    
    void PickShootSounds(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            var randomSound = Random.Range(0, machineGunSounds.Count);
            sounds.Add(machineGunSounds[randomSound]);
        }

        for (int i = 0; i < sounds.Count; i++)
        {
            var soundDelay = 0f;
            spitfireAudio.PlayDelayed(soundDelay);
        }
    } 
}
