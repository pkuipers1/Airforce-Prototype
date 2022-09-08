using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> planes;

    [SerializeField] public bool planeSpawned;

    [SerializeField] private float spawnCooldown;

    public GameObject currentPlane;
    
    // Start is called before the first frame update
    void Start()
    {
        SetSpawnCooldown();
    }

    // Update is called once per frame
    void Update()
    {
        spawnCooldown -= Time.deltaTime;

        if (spawnCooldown <= 0 && !planeSpawned)
        {
            var randomPlane = Random.Range(0, planes.Count);
            Instantiate(planes[randomPlane], transform.position, Quaternion.identity);
            planeSpawned = true;
        }

        currentPlane = GameObject.FindWithTag("Enemy");

        if (currentPlane == null && spawnCooldown <= 0)
        {
            SetSpawnCooldown();
            planeSpawned = false;
        }
    }

    void SetSpawnCooldown()
    {
        spawnCooldown = (Random.Range(5.0f, 15.0f));
    }
}
