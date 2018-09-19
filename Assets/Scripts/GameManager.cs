using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public AudioClip punch, canonSong, wrong, great, launch, grab, ahS;
    public Transform spawnParent;
    public static GameManager Instance { get; private set; }
    public List<GameObject> spawnItems = new List<GameObject>();
    public GameObject canon;
    private List<int> spawnIdx = new List<int>();
    private int idx;
    private int spawnObjectidx;
    public Text TeamBlue;
    public Text TeamRed;
    public int actualBlueScore;
    public int actualRedScore;
    public float timerInitial;
    private float timerActual;
    public Text timerText;
    public GameObject endMenu;
    public bool end = false;
    public GameObject igMenu;
    public Text endBlue;
    public Text endRed;
    public Text endText;
    public int buildIndex;
    public ParticleSystem msokeCanon;
    private AudioSource audioSource;
    public List<GameObject> WinFxBlue;
    public List<GameObject> WinFxRed;
    public List<GameObject> WinFxEnd;

    private bool b_IsEndGame = false;

    public List<Outline> LegumeOutline;
    public List<Outline> FruitOutline;

    // Use this for initialization
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        Time.timeScale = 1;
        audioSource = GetComponent<AudioSource>();
        buildIndex = SceneManager.GetActiveScene().buildIndex;
    }
    void Start() {

        timerActual = timerInitial;
        ListEntry();
        actualRedScore = 0;
        actualBlueScore = 0;
        TeamBlue.text = actualBlueScore.ToString("f0");
        TeamRed.text = actualRedScore.ToString("f0");
        StartingIdx();
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
        for (int i = 0; i < 10; i++)
        {
            spawnIdx.Add(i);
        }
    }

    public void StartingIdx()
    {
        PlayCanon();
        RndIdx();
        Instantiate(spawnItems[spawnObjectidx], spawnParent.GetChild(spawnIdx[idx]).position, Quaternion.identity, spawnParent.GetChild(spawnIdx[idx]));
        msokeCanon.Play();
    }

    public void BlueTeamScore(int blueScore)
    {
        actualBlueScore += blueScore;
        TeamBlue.text = actualBlueScore.ToString("f0");
        if(blueScore > 0)
        ScoreFxBlue();
    }

    public void RedTeamScore(int redScore)
    {
        actualRedScore += redScore;
        TeamRed.text = actualRedScore.ToString("f0");
        if (redScore > 0)
        ScoreFxRed();
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
            b_IsEndGame = true;
            endBlue.text = TeamBlue.text;
            endRed.text = TeamRed.text;
            end = true;
            timerActual = 0;
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
            SetEndgameWinFx();
        }
    }

    public void Restart()
    {
        audioSource.clip = ahS;
        audioSource.Play();
        end = false;
        SceneManager.LoadScene(buildIndex);
    }

    public void ReturnToMenu()
    {
        audioSource.clip = ahS;
        audioSource.Play();
        SceneManager.LoadScene("MainScene");
    }
    public void PlayGrab()
    {
        audioSource.clip = grab;
        audioSource.Play();
    }
    public void PlayPunch()
    {
        audioSource.clip = punch;
        audioSource.Play();
    }
    public void PlayLaunch()
    {
        audioSource.clip = launch;
        audioSource.Play();
    }
    public void PlayWrong()
    {
        audioSource.clip = wrong;
        audioSource.Play();
    }
    public void PlayGreat()
    {
        audioSource.clip = great;
        audioSource.Play();
    }
    public void PlayCanon()
    {
        audioSource.clip = canonSong;
        audioSource.Play();
    }


    public void ScoreFxRed()
    {
        foreach (GameObject Particle in WinFxRed)
        {
            Particle.SetActive(false);
            Particle.SetActive(true);
        }
    }

    public void ScoreFxBlue()
    {
        foreach (GameObject Particle in WinFxBlue)
        {
            Particle.SetActive(false);
            Particle.SetActive(true);
        }
    }

    public void SetEndgameWinFx()
    {
        foreach(GameObject Particle in WinFxEnd)
        {
            Particle.SetActive(true);
        }
    }

    public bool IsEndgame()
    {
        return b_IsEndGame;
    }
}
