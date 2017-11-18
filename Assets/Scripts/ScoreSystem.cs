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
            if (other.gameObject.CompareTag("Blueteam"))
            {
                LevelManager.Instance.BlueTeamScore(aliment.amountScored);
            }
            else if(other.gameObject.CompareTag("Redteam"))
            {
                LevelManager.Instance.BlueTeamScore(aliment.amountScored);
            }
        }
     
    }
}
