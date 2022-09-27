using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting4Guns : MonoBehaviour
{

    [SerializeField] private float shootSpeed;
    [SerializeField] private float shootTimer;
    
    [SerializeField] private List<Transform> bulletSpawns;
    
    [SerializeField] private GameObject bullet;
    
    private bool isShooting;

    [SerializeField] private List<ParticleSystem> flashEffects;
    
    // Start is called before the first frame update
    void Start()
    {
        isShooting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isShooting)
        {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        isShooting = true;
        foreach (var spawn in bulletSpawns)
        {
            var newBullet = Instantiate(bullet, spawn.position, Quaternion.identity);
            newBullet.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, -shootSpeed * Time.deltaTime);
        }
        foreach (var flashEffect in flashEffects)
        {
            flashEffect.Play();
        }
        yield return new WaitForSeconds(shootTimer);
        isShooting = false;
    }
}