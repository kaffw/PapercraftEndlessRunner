using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public GameObject[] groundObstacles;
    public GameObject[] aerialObstacles;
    public GameObject cameraPos;

    public float groundObstacleSpeed;
    public float aerialObstacleSpeed;

    public float groundTimer = 0f, aerialTimer = 0f;
    public float groundSpawn = 4f, aerialSpawn = 2f;

    private void Start()
    {
        cameraPos = GameObject.Find("Main Camera");
    }
    void Update()
    {
        if (groundTimer >= groundSpawn)
        {
            Instantiate(groundObstacles[0], new Vector2(cameraPos.transform.position.x + 10f, -3f), Quaternion.identity);
            groundTimer = 0f;
            groundSpawn = Random.Range(10, 14);
        }

        if (aerialTimer >= aerialSpawn)
        {
            Instantiate(aerialObstacles[0], new Vector2(cameraPos.transform.position.x + 10f, Random.Range(-1, 4)), Quaternion.identity);
            aerialTimer = 0f;
            aerialSpawn = Random.Range(5, 10);
        }

        aerialTimer += Time.deltaTime;
        groundTimer += Time.deltaTime;
    }
}
