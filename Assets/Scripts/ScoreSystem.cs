﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : MonoBehaviour {

    public Aliments.AlimType type;
    public Aliments.TeamType teamRed;
    public Aliments.TeamType teamBlue;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        Aliments aliment = other.gameObject.GetComponentInParent<Aliments>();
        if(aliment.type == type && aliment.teamtype == teamRed)
        {
            GameManager.Instance.RedTeamScore(aliment.amountScored);
            Destroy(aliment.gameObject);
            GameManager.Instance.StartingIdx();
        }
        if (aliment.type == type && aliment.teamtype == teamBlue)
        {
            GameManager.Instance.BlueTeamScore(aliment.amountScored);
            Destroy(aliment.gameObject);
            GameManager.Instance.StartingIdx();

        }


    }
}
