using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetaryGravity : MonoBehaviour
{
    private Rigidbody rb;
    
    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    void Update() {
        
    }

    void FixedUpdate() {
        rb.AddForce(9.81f * Vector3.down, ForceMode.Acceleration);
    }
}
