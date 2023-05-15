using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetaryGravity : MonoBehaviour
{
    private Rigidbody rb;
    private GameObject player;
    
    void Start() {
    }

    void Update() {
        if (player != null) {
            Vector3 direction = player.transform.position - transform.position;
            rb.AddForce(-direction.normalized * 9.81f, ForceMode.Acceleration);
            player.transform.rotation = Quaternion.FromToRotation(player.transform.up, direction) * player.transform.rotation;
        }
    }

    void FixedUpdate() {
        
    }

    void OnTriggerEnter(Collider other) {
        Vector3 direction = other.gameObject.transform.position - transform.position;
        Rigidbody otherRb = other.gameObject.GetComponent<Rigidbody>();
        Debug.Log(-other.gameObject.transform.up);
        if (otherRb != null) {
            player = other.gameObject;
            rb = otherRb;
        }
        
    }
}
