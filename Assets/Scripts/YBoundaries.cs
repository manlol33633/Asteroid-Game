using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YBoundaries : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.transform.position.y > 0) {
            other.gameObject.transform.position = new Vector3(other.gameObject.transform.position.x, -4.5f, other.gameObject.transform.position.z);
        } else {
            other.gameObject.transform.position = new Vector3(other.gameObject.transform.position.x, 4.5f, other.gameObject.transform.position.z);
        }
    }
}
