using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    [SerializeField] private GameObject[] asteroidPrefab;
    [SerializeField] private GameObject asteroidSpawn;
    private GameObject newAsteroid;
    private GameObject asteroid;
    private Rigidbody2D asteroidRigidbody;
    private Rigidbody2D asteroidRigidbody2;
    private bool isSpawn;
    void Start()
    {
        isSpawn = true;
    }
    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Bullet") {
            if (gameObject.name == "Asteroid_4(Clone)") {
                Destroy(gameObject);
                isSpawn = true;
                SpawnAsteroid(3);
                if (isSpawn) {
                    asteroidRigidbody.velocity = Random.insideUnitCircle * Random.Range(5, 10);
                    asteroidRigidbody.AddTorque(Random.Range(-180, 180));
                    asteroidRigidbody2.velocity = Random.insideUnitCircle * Random.Range(5, 10);
                    asteroidRigidbody2.AddTorque(Random.Range(-180, 180));
                    isSpawn = false;
                }
            } else if (gameObject.name == "Asteroid_3(Clone)") {
                Destroy(gameObject);
                isSpawn = true;
                SpawnAsteroid(2);
                if (isSpawn) {
                    asteroidRigidbody.velocity = Random.insideUnitCircle * Random.Range(5, 10);
                    asteroidRigidbody.AddTorque(Random.Range(-180, 180));
                    asteroidRigidbody2.velocity = Random.insideUnitCircle * Random.Range(5, 10);
                    asteroidRigidbody2.AddTorque(Random.Range(-180, 180));
                    isSpawn = false;
                }
            } else { 
                Destroy(gameObject);
            }
        }
    }

    void SpawnAsteroid(int i)
    {
        newAsteroid = Instantiate(asteroidPrefab[i - 2], asteroidSpawn.transform.position, Quaternion.Euler(0, 0, Random.Range(0, 360)));
        asteroid = Instantiate(asteroidPrefab[i - 2], asteroidSpawn.transform.position, Quaternion.Euler(0, 0, Random.Range(0, 360)));
        asteroidRigidbody = newAsteroid.GetComponent<Rigidbody2D>();
        asteroidRigidbody2 = asteroid.GetComponent<Rigidbody2D>();
    }
}
