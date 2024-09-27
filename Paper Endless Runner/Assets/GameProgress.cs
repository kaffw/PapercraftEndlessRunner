using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameProgress : MonoBehaviour
{
    /*
    Main Menu =========================================================================================================================
    - PLAY
    - LEADERBOARDS
    - SETTINGS
    - QUIT

    PLAY =========================================================================================================================
    - Input name
    - Skin Customization
    - Set Difficulty (Flashlight Mode || Hard Mode) //Last Priority
    - START GAME

        SET DIFFICULTY (OSU! inspired)
        Flashlight Mode         :   vignette centered to player (reduced vision)
        Hard Mode               :   obstacle travel speed / spawn intensity increased per x distance

    LEADERBOARDS =========================================================================================================================
    - Most Distance Traveled
    - Most Coin Collected
    - TOTAL SCORE ACHIEVED

    SETTINGS =========================================================================================================================
    - BGM
    - SFX

    START GAME =========================================================================================================================
    - GAME LOOP

    LEADERBOARDS =========================================================================================================================
    > string        :   playerName
    > int           :   aircraftSkinSelected
    > float         :   totalDistanceTraveled
    > float         :   totalCoinsCollected
    > float         :   totalScoreRaw
    > float         :   totalScoreAchieved
    > bool          :   flashLightMode, hardMode
    > float         :   difficultyMultiplier = 1f/ 0.6f / 0.12f -- 0/1/2 difficulty enabled

    totalScoreRaw = totalDistanceTraveled * (totalCoinsCollected * (totalDistanceTraveled / 100))
    totalScoreAchieved = totalScoreRaw * (difficultyMultiplier)

    ** create a text file where records will be stored to locally store records without using database
    * use filestreams of C# ---> haven't tried yet.

    XXXXXX =========================================================================================================================
    */
}
