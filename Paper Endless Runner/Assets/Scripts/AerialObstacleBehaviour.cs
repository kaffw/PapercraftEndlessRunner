using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AerialObstacleBehaviour : MonoBehaviour
{
    //Behaviour for bird, cloud, etc... -- varying speed

    public float speed = 1f; // To be affected by "Hard Difficulty"

    private void Start()
    {
        //At instantiate
        //set speed here
        UpdateSpeed();
    }
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
    void UpdateSpeed()
    {
        UserRecordManager userRecord = GameObject.Find("User Record Manager").GetComponent<UserRecordManager>();
        speed = (int)((userRecord.distanceTraveled / 100) + 1 ) ;
    }
}
