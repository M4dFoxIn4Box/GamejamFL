using System.Collections;
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
    // Use this for initialization
    private void Awake()
    {
        Instance = this;
    }
    void Start() {
        ListEntry();
    }

    // Update is called once per frame
    void Update() {
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
}
