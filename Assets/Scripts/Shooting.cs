using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public float shootSpeed;
    public float shootTimer;
    
    public Transform bulletSpawn1;
    public Transform bulletSpawn2;
    public Transform bulletSpawn3;
    public Transform bulletSpawn4;
    
    public GameObject bullet;

    private bool isShooting;

    public bool autoShooting;
    
    // Start is called before the first frame update
    void Start()
    {
        isShooting = false;
    }

    // Update is called once per frame
    void Update()
    {
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
        GameObject newBullet1 = Instantiate(bullet, bulletSpawn1.position, Quaternion.identity);
        GameObject newBullet2 = Instantiate(bullet, bulletSpawn2.position, Quaternion.identity);
        newBullet1.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, shootSpeed * Time.deltaTime);
        newBullet2.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, shootSpeed * Time.deltaTime);
        yield return new WaitForSeconds(shootTimer);
        isShooting = false;
    }
}
