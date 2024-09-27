using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGameOver : MonoBehaviour
{
    public bool collideInstance = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle") && !collideInstance)
        {
            collideInstance = true;
            UserRecordManager urManager = GameObject.Find("User Record Manager").GetComponent<UserRecordManager>();
            urManager.SetRecord();

            Debug.Log("Player collided");
        }
    }
}
