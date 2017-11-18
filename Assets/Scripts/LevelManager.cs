using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

    public Text TeamBlue;
    public Text TeamRed;
    private int actualBlueScore;
    private int actualRedScore;

    public static LevelManager Instance { get; private set; }

    public void BlueTeamScore (int blueScore)
    {
       actualBlueScore += blueScore;
       TeamBlue.text = actualBlueScore.ToString("f0");
    }

    public void RedTeamScore(int redScore)
    {
        actualBlueScore += redScore;
        TeamRed.text = actualRedScore.ToString("f0");
    }
}
