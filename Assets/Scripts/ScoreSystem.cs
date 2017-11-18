using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : MonoBehaviour {

    public Aliments.AlimType type;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        Aliments aliment = other.gameObject.GetComponentInParent<Aliments>();
        if(aliment.type == type)
        {
            if (aliment.CompareTag("BlueTeam"))
            {
                LevelManager.Instance.BlueTeamScore(aliment.amountScored);
                Destroy(aliment);
            }
            else if(aliment.CompareTag("RedTeam"))
            {
                LevelManager.Instance.RedTeamScore(aliment.amountScored);
                Destroy(aliment);
            }
        }
        else
        {
            Destroy(aliment);
        }
     
    }
}
