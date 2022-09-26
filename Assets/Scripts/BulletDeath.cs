using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class BulletDeath : MonoBehaviour
{
    [SerializeField] private GameObject impactEffect;
    [SerializeField] float lifespan;
    [SerializeField] float bulletDamage;
    
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
        if (collisionGameObject.tag == "Enemy")
        {
            collisionGameObject.GetComponent<Health>().currentHealth -= bulletDamage;
            Despawn();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Health>().currentHealth -= bulletDamage;
            Despawn();
        }
        if (other.CompareTag("Bullet"))
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
