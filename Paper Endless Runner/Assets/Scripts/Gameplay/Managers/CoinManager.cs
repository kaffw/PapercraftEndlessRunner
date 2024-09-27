using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public GameObject coin;
    public GameObject playerAircraft;

    public int coinSpawnCount;
    public float nextSpawnTime;
    public float timer;
    private void Start()
    {
        playerAircraft = GameObject.Find("Papercraft");
        timer = 0f;
        nextSpawnTime = 10f;
    }
    void Update()
    {
        if (timer >= nextSpawnTime)
        {
            coinSpawnCount = Random.Range(1, ((int)(playerAircraft.transform.position.x / 100) + 1));
            Vector2 spawnPos = playerAircraft.transform.position;
            spawnPos.x += 10f;
            for (int i = 0; i < coinSpawnCount; i++)
            {
                Vector3 spawnPosition = new Vector3(spawnPos.x + Random.Range(2, 4), spawnPos.y + Random.Range(-1, 3), 0);
                Instantiate(coin, spawnPosition, Quaternion.identity);
            }

            timer = 0f;
            nextSpawnTime = (float)(Random.Range(10, 15));
        }

        timer += Time.deltaTime;
    }
}
