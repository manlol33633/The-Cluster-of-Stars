using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private GameObject playerTransform;
    private GameObject player;
    private RaycastHit hit;

    void Start()
    {
        playerTransform = GameObject.Find("Orientation");
        player = GameObject.Find("Player");
    }

    void Update()
    {
        RaycastHit hit;
        Ray ray = new Ray(player.transform.position, -player.transform.forward);
        Physics.Raycast(ray , out hit, 10f);
        Vector3 hitPoint = hit.point;
        
        if (Physics.Raycast(player.transform.position, -player.transform.forward, 10f)) {
            transform.position = hitPoint;
        } else {
            transform.position = playerTransform.transform.forward * -10 + playerTransform.transform.position;
        }
        transform.rotation = playerTransform.transform.rotation;
        
    }
}
