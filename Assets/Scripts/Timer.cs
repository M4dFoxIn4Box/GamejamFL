using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
    public float timerSecondes;
    public float timerMinutes;
    public Text timerTxt;

	// Use this for initialization
	void Start ()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        TimerGeneral();
    }
    void Update ()
    {

        
	}

    void TimerGeneral()
    {
       
        timerSecondes -= Time.deltaTime;
    

        if (timerSecondes < 0)
        {
            timerSecondes = 0;
        }

        if (timerMinutes < 0)
        {
            timerMinutes = 0;
        }

        //if (timerminutes == 0 && timersecondes == 0)
        //{
            
        //}

        if (timerMinutes >= 1 && timerSecondes <= 0)
        {
            timerMinutes--;
            timerSecondes = 60.0f;
        }


        if (timerSecondes <= 59)
        {
            timerTxt.text = timerMinutes.ToString("") + ":" + timerSecondes.ToString("00");
        }
    }
}
