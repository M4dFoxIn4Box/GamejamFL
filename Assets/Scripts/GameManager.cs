﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public Transform spawnParent;
    public static GameManager Instance { get; private set; }
    public List<GameObject> spawnItems = new List<GameObject>();
    public GameObject canon;
    private List<int> spawnIdx = new List<int>();
    public GameObject orange;
    private int idx;
    private int spawnObjectidx;
    public Text TeamBlue;
    public Text TeamRed;
    private int actualBlueScore;
    private int actualRedScore;
    public float timerInitial;
    private float timerActual;
    public Text timerText;
    public GameObject endMenu;
    public bool end = false;
    public GameObject igMenu;
    public Text endBlue;
    public Text endRed;
    public Text endText;

    // Use this for initialization
    private void Awake()
    {
        Instance = this;
    }
    void Start() {
        timerActual = timerInitial;
        ListEntry();
        actualRedScore = 0;
        actualBlueScore = 0;
        TeamBlue.text = actualBlueScore.ToString("f0");
        TeamRed.text = actualRedScore.ToString("f0");
    }

    // Update is called once per frame
    void Update() {
        TimerCooldown();
        //if (Input.GetButtonDown("Grab/Throw_P1"))
        //{
        //    StartingIdx();
        //}
    }

    public void RndIdx()
    {
        idx = Random.Range(0, spawnIdx.Count);
        spawnObjectidx = Random.Range(0, spawnItems.Count);
    }

    public void ListEntry()
    {
        spawnIdx.Clear();
        for (int i = 0; i < 12; i++)
        {
            spawnIdx.Add(i);
        }
    }

    public void StartingIdx()
    {
        RndIdx();
        Instantiate(spawnItems[spawnObjectidx], spawnParent.GetChild(spawnIdx[idx]).position, Quaternion.identity, spawnParent.GetChild(spawnIdx[idx]));
    }

    public void BlueTeamScore(int blueScore)
    {
        actualBlueScore += blueScore;
        TeamBlue.text = actualBlueScore.ToString("f0");
    }

    public void RedTeamScore(int redScore)
    {
        actualRedScore += redScore;
        TeamRed.text = actualRedScore.ToString("f0");
    }

    public void TimerCooldown()
    {
        timerActual -= Time.deltaTime;
        int minutes = Mathf.FloorToInt(timerActual / 60F);
        int seconds = Mathf.FloorToInt(timerActual - minutes * 60);
        string niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);
        timerText.text = niceTime;
        
        if (timerActual <= 0)
        {
            endBlue.text = TeamBlue.text;
            endRed.text = TeamRed.text;
            end = true;
            timerActual = 0;
            Time.timeScale = 0;
            endMenu.SetActive(true);
            igMenu.SetActive(false);
            if (actualBlueScore > actualRedScore)
            {
                endText.text = "L'equipe <color=blue>Bleu</color> a gagnee !!";
            }
            if (actualBlueScore < actualRedScore)
            {
                endText.text = "L'equipe <color=red>Rouge</color> a gagnee !!";
            }
            if (actualBlueScore == actualRedScore)
            {
                endText.text = "Egalite !!";
            }
        }
    }
}
