using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    [SerializeField] private float shootSpeed;
    [SerializeField] private float shootTimer;
    
    [SerializeField] private List<Transform> bulletSpawns;
    
    [SerializeField] private GameObject bullet;
    
    private bool isShooting;
    
    [SerializeField] private bool autoShooting;

    [SerializeField] public static bool autoFire;
    
    // Start is called before the first frame update
    void Start()
    {
        autoShooting = false;
        isShooting = false;
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
        
        GameObject newBullet1 = Instantiate(bullet, bulletSpawns[0].position, Quaternion.identity);
        GameObject newBullet2 = Instantiate(bullet, bulletSpawns[1].position, Quaternion.identity);
        
        //newBullet1.GetComponent<GameObject>().transform.rotation = Quaternion.Euler(90, 0, 0); 
        //newBullet2.GetComponent<GameObject>().transform.rotation = Quaternion.Euler(90, 0, 0); 

        newBullet1.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, shootSpeed * Time.deltaTime);
        newBullet2.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, shootSpeed * Time.deltaTime);
        
        yield return new WaitForSeconds(shootTimer);
        isShooting = false;
    }
}
