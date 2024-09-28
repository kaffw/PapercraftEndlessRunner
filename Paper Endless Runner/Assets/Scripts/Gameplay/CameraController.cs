using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject cameraObject;
    public float moveSpeed;
    void Start()
    {
        cameraObject = GameObject.Find("Main Camera");
    }

    void Update()
    {
        cameraObject.transform.position += new Vector3(Time.deltaTime * moveSpeed, 0, 0);
    }
}
