using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class LeaderboardsManager : MonoBehaviour
{
    public struct Rankings
    {
        public string name;
        public int aircraftSelectedIndex;
        public float totalDistanceTraveled;
        public float totalCoinsCollected;
        public float totalScoreRaw;
        public float totalScoreAchieved;
        public float difficultyMultiplier;
        public void SetTotalScore()
        {
            totalScoreRaw = this.totalDistanceTraveled + (this.totalCoinsCollected * (this.totalDistanceTraveled / 100));
            totalScoreAchieved = totalScoreRaw * this.difficultyMultiplier;
        }
    }

    public static List<Rankings> ranks = new();

    public Sprite[] AircraftSkinCollection;
    public static bool startInstance = false;

    private string filePath;
    void Start()
    {
        if (!startInstance)
        {
            //public static Rankings ranks
            //read values from txt file using filestream
            filePath = @"C:\Users\Aceae\Documents\GitHub\PapercraftEndlessRunner\Paper Endless Runner\Assets\LeaderboardsRecord.txt";

            if (File.Exists(filePath))
            {
                Debug.Log(filePath.ToString() + "file found");
                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader reader = new StreamReader(fs))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            string[] values = line.Split(' ');

                            if (values.Length >= 5)
                            {
                                Rankings ranking = new Rankings
                                {
                                    name = values[0],
                                    aircraftSelectedIndex = int.Parse(values[1]),
                                    totalDistanceTraveled = float.Parse(values[2]),
                                    totalCoinsCollected = float.Parse(values[3]),
                                    difficultyMultiplier = float.Parse(values[4])
                                };

                                ranking.SetTotalScore();
                                ranks.Add(ranking);
                                Debug.Log($"Added ranking: {ranking.name}, Index: {ranking.aircraftSelectedIndex}, Distance: {ranking.totalDistanceTraveled}, Coins: {ranking.totalCoinsCollected}, Raw Total: {ranking.totalScoreRaw}, Total: {ranking.totalScoreAchieved}, Difficulty: {ranking.difficultyMultiplier}");
                            }
                        }
                    }
                }
            }
            else
            {
                Debug.LogError("File not found at: " + filePath);
            }

            startInstance = true;
        }

        //DisplayRanks();
    }

    /*public void DisplayRanks()
    {
        foreach (var x in ranks)
        {
            Debug.Log("name = " + x.name);
            Debug.Log("aircraftSelectedIndex = " + x.aircraftSelectedIndex);
            Debug.Log("totalDistanceTraveled = " + x.totalDistanceTraveled);
            Debug.Log("totalCoinsCollected = " + x.totalCoinsCollected);
            Debug.Log("totalScoreRaw = " + x.totalScoreRaw);
            Debug.Log("totalScoreAchieved = " + x.totalScoreAchieved);
            Debug.Log("difficultyMultiplier = " + x.difficultyMultiplier);
        }
    }*/
}
//public bool flashlightModeOn, hardModeOn; //temporarily disabled (not yet implemented)