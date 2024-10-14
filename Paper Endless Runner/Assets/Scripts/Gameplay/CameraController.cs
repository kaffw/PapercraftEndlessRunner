using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject cameraObject;
    public float moveSpeed = 1f; // to be affected by "Hard Difficulty"
    //public float speedThreshold = 100f;
    private UserRecordManager userRecord;
    void Start()
    {
        cameraObject = GameObject.Find("Main Camera");
        userRecord = GameObject.Find("User Record Manager").GetComponent<UserRecordManager>();
    }

    void Update()
    {
        if (!userRecord.stopRecording)
        {
            moveSpeed = Math.Max(1, (int)(userRecord.distanceTraveled / 100) + 1);
            cameraObject.transform.position += new Vector3(Time.deltaTime * moveSpeed, 0, 0);
        }
    }
}
