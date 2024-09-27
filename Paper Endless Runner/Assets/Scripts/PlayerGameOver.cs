using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGameOver : MonoBehaviour
{
    public bool collideInstance = false;
    public UserRecordManager urManager;

    private void Start()
    {
        urManager = GameObject.Find("User Record Manager").GetComponent<UserRecordManager>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle") && !collideInstance)
        {
            collideInstance = true;
            
            urManager.SetRecord();

            Debug.Log("Player collided");
        }

        if (other.CompareTag("Coin"))
        {
            urManager.CollectCoin();
            Destroy(other.gameObject);
        }
    }
}
