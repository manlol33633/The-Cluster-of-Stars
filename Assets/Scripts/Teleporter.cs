using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    private Transform teleportEndPoint;
    private GameObject player;
    private bool isTeleporting = false;

    void Start()
    {
        teleportEndPoint = GameObject.Find("Teleport2Point").transform;
        player = GameObject.Find("Player");
    }

    void Update()
    {
        if (isTeleporting) {
            player.transform.position = Vector3.Lerp(transform.position, teleportEndPoint.position, 0.5f);
        }
    }

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Player") {
            isTeleporting = true;
        }
    }
}
