using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class EnemyBulletDeath : MonoBehaviour
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
        if (collisionGameObject.tag == "Player")
        {
            collisionGameObject.GetComponent<Health>().currentHealth -= bulletDamage;
            Despawn();
        }
    }

    void Despawn()
    {
        Instantiate(impactEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}