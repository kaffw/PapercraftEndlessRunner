using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
public class UserRecordManager : MonoBehaviour
{
    public TextMeshProUGUI playerNameText, distanceTraveledText, CoinsCollectedText;
    public float startPoint, distanceTraveled, coinsCollected;
    public GameObject playerAircraft;

    private string filePath;
    public bool stopRecording = false;
    void Start()
    {
        playerAircraft = GameObject.Find("Papercraft");

        if (UsernameManager.username != null)
            playerNameText.text = UsernameManager.username;
        else
            playerNameText.text = "No_username";

        distanceTraveled = coinsCollected = 0f;
    }

    void Update()
    {
        if (!stopRecording)
        {
            distanceTraveled = startPoint + playerAircraft.transform.position.x;
            distanceTraveledText.text = distanceTraveled.ToString("F2") + "m";
            CoinsCollectedText.text = coinsCollected.ToString();
        }
    }
    public void CollectCoin()
    {
        coinsCollected++;
    }

    public void SetRecord()
    {
        //name - aircraftSelectedIndex - totalDistanceTraveled - totalCoinCollected - difficultyMultiplier

        stopRecording = true;
        //filePath = @"C:\Users\Aceae\Documents\GitHub\PapercraftEndlessRunner\Paper Endless Runner\Assets\LeaderboardsRecord.txt"; // sa harong
        filePath = @"D:\Users\Unit_21\Documents\GitHub\PapercraftEndlessRunner\Paper Endless Runner\Assets\LeaderboardsRecord.txt"; // sa lab

        if (File.Exists(filePath))
        {
            Debug.Log(filePath.ToString() + "file found");
            using (StreamWriter writer = new StreamWriter(filePath, true)) // true to append to the file
            {
                writer.Write(playerNameText.text + " ");
                writer.Write(CustomizeManager.aircraftIndex + " ");
                writer.Write(distanceTraveled.ToString("F2") + " ");
                writer.Write(coinsCollected.ToString() + " ");
                writer.WriteLine(1);
            }
        }
        else
        {
            Debug.LogError("File not found at: " + filePath);
        }
    }
}
