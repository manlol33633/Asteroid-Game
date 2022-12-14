using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloningScript : MonoBehaviour
{
    [SerializeField] private GameObject[] asteroidPrefab;
    [SerializeField] private GameObject asteroidSpawn;
    private GameObject newAsteroid;
    private Rigidbody2D asteroidRigidbody;
    private float spawnTimer;
    private bool isSpawn;

    void Start()
    {
        if (gameObject.name == "CloningObject") {
            spawnTimer = 1;
        } else if (gameObject.name == "CloningObject(1)") {
            spawnTimer = 2;
        } else if (gameObject.name == "CloningObject(2)") {
            spawnTimer = 3;
        } else if (gameObject.name == "CloningObject(3)") {
            spawnTimer = 4;
        }
        isSpawn = true;
    }

    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= 5)
        {
            isSpawn = true;
            SpawnAsteroid();
            if (isSpawn) {
                asteroidRigidbody.velocity = Random.insideUnitCircle * Random.Range(5, 7.5f);
                asteroidRigidbody.AddTorque(Random.Range(-180, 180));
                isSpawn = false;
            }
            spawnTimer = 0;
        }
    }

    void SpawnAsteroid()
    {
        newAsteroid = Instantiate(asteroidPrefab[Random.Range(0, 2)], asteroidSpawn.transform.position, Quaternion.Euler(0, 0, Random.Range(0, 360)));
        asteroidRigidbody = newAsteroid.GetComponent<Rigidbody2D>();
        Debug.Log(newAsteroid.transform.rotation.z);
    }
}
