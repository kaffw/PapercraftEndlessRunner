using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
public class UserRecordManager : MonoBehaviour
{
    public TextMeshProUGUI playerNameText, distanceTraveledText, CoinsCollectedText;
    public TextMeshProUGUI distanceTraveledTextPause, coinsCollectedTextPause;

    public float startPoint, distanceTraveled, coinsCollected;
    public GameObject playerAircraft;

    private string filePath;
    public bool stopRecording = false;

    public GameObject gameOverCanvasOb;
    public GameLoopAudioManager glAudioManager;

    bool isGameOverTriggered = false;

    public static bool gameOver = false;
    void Start()
    {
        gameOver = false;

        playerAircraft = GameObject.Find("Papercraft");
        glAudioManager = GameObject.Find("Audio Manager").GetComponent<GameLoopAudioManager>();

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
            distanceTraveledTextPause.text = distanceTraveled.ToString("F2") + "m";

            CoinsCollectedText.text = coinsCollected.ToString() + " coins";
            coinsCollectedTextPause.text = coinsCollected.ToString() + " coins";

        }
        else
        {
            if (!isGameOverTriggered)
            {
                GameOver();
                gameOver = true;
                isGameOverTriggered = true;
            }
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
        filePath = @"C:\Users\Aceae\Documents\GitHub\PapercraftEndlessRunner\Paper Endless Runner\Assets\LeaderboardsRecord.txt"; // sa harong
        //filePath = @"D:\Users\Unit_21\Documents\GitHub\PapercraftEndlessRunner\Paper Endless Runner\Assets\LeaderboardsRecord.txt"; // sa lab

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
    public void GameOver()
    {
        //Game Over Text
        gameOverCanvasOb.SetActive(true);
        Time.timeScale = 0;
        glAudioManager.PlayGameOverSFX();
    }
}
