using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UserRecordManager : MonoBehaviour
{
    public TextMeshProUGUI playerNameText, distanceTraveledText, CoinsCollectedText;
    public float startPoint, distanceTraveled, coinsCollected;
    public GameObject playerAircraft;
    void Start()
    {
        playerAircraft = GameObject.Find("Papercraft");

        if (UsernameManager.username != null)
            playerNameText.text = UsernameManager.username;
        else
            playerNameText.text = "No username";

        distanceTraveled = coinsCollected = 0f;
    }

    void Update()
    {
        distanceTraveled = startPoint + playerAircraft.transform.position.x;
        distanceTraveledText.text = distanceTraveled.ToString("F2") + "m";
    }
    public void CollectCoin()
    {
        coinsCollected++;
    }

}
