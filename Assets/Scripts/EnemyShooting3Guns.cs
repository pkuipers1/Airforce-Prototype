using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting3Guns : MonoBehaviour
{

    [SerializeField] private float shootSpeed;
    [SerializeField] private float shootTimer;
    
    [SerializeField] private List<Transform> bulletSpawns;
    
    [SerializeField] private GameObject bullet;
    
    private bool isShooting;
    
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
        GameObject newBullet1 = Instantiate(bullet, bulletSpawns[0].position, Quaternion.identity);
        GameObject newBullet2 = Instantiate(bullet, bulletSpawns[1].position, Quaternion.identity);
        GameObject newBullet3 = Instantiate(bullet, bulletSpawns[2].position, Quaternion.identity);
        newBullet1.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, -shootSpeed * Time.deltaTime);
        newBullet2.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, -shootSpeed * Time.deltaTime);
        newBullet3.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, -shootSpeed * Time.deltaTime);
        yield return new WaitForSeconds(shootTimer);
        isShooting = false;
    }
}