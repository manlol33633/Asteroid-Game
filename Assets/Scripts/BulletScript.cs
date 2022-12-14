using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    private Rigidbody2D bulletRigidbody;
    private float lifeTime;
    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody2D>();
        lifeTime = 0;
    }

    void Update()
    {
        bulletRigidbody.velocity = transform.up * bulletSpeed; 
        lifeTime += Time.deltaTime;
        if (lifeTime >= 5) {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Asteroid") {
            Destroy(gameObject);
        }
    }
}
