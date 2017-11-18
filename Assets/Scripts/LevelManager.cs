using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

    public Text TeamBlue;
    public Text TeamRed;

    public static LevelManager Instance { get; private set; }

    public void BlueTeamScore (int BlueScore)
    {
       TeamBlue.text = BlueScore.ToString("f0");
    }

    public void RedTeamScore(int RedScore)
    {
       TeamRed.text = RedScore.ToString("f0");
    }
}
