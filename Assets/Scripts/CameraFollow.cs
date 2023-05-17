using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private GameObject playerTransform;

    void Start()
    {
        playerTransform = GameObject.Find("Orientation");
    }

    void Update()
    {
        transform.position = playerTransform.transform.forward * -10 + playerTransform.transform.position;
        transform.rotation = playerTransform.transform.rotation;
    }
}
