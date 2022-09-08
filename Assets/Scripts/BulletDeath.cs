using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDeath : MonoBehaviour
{
    public GameObject impactEffect;
    public float lifespan; 
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lifespan -= Time.deltaTime;

        if (lifespan <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject collisionGameObject = collision.gameObject;
        if (collisionGameObject.tag != "Player")
        {
            Despawn();
        }
    }

    void Despawn()
    {
        Instantiate(impactEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}
