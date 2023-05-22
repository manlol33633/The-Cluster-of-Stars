using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    private Transform teleportEndPoint;
    private GameObject player;
    private GameObject playerBody;
    public static bool isTeleporting = false;
    [SerializeField] private float duration;
    private float time = 0;

    void Start()
    {
        teleportEndPoint = GameObject.Find("Teleport2Point").transform;
        player = GameObject.Find("Player");
        playerBody = GameObject.Find("PlayerBody");
    }

    void Update()
    {
        if (time < duration && isTeleporting) {
            player.transform.position = Vector3.Lerp(transform.position, teleportEndPoint.position, time / duration);
            time += Time.deltaTime;
            playerBody.GetComponent<MeshCollider>().enabled = false;
        }
        playerBody.GetComponent<MeshCollider>().enabled = true;
    }

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Player") {
            isTeleporting = true;
        }
    }
}
