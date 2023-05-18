using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float speed;
    private bool isMaxSpeed;

    private float horizontalInput;
    private float verticalInput;

    private GameObject playerTransform;

    private bool isGrounded;

    void Start() {
        rb = GetComponent<Rigidbody>();
        playerTransform = GameObject.Find("Orientation");
    }

    void Update() {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if (rb.velocity.magnitude > 10) {
            isMaxSpeed = true;
        } else {
            isMaxSpeed = false;
        }

        playerTransform.transform.position = transform.position;
        playerTransform.transform.rotation = transform.rotation;

        if (horizontalInput == 0) {
            rb.angularVelocity = Vector3.zero;
        }
    }

    void FixedUpdate() {
        if (!isMaxSpeed) {
            rb.AddForce(transform.forward * verticalInput * speed, ForceMode.Acceleration);
        }

        if (Input.GetKey(KeyCode.Space) && isGrounded) {
            rb.AddForce(transform.up * 20, ForceMode.Impulse);
        }

        transform.Rotate(0, horizontalInput, 0);
    }

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Ground")) {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision other) {
        if (other.gameObject.CompareTag("Ground")) {
            isGrounded = false;
        }
    }
}
