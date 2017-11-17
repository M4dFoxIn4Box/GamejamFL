using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateManager : MonoBehaviour {

	public int caisse;
	public int playerNumber;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public int GetCrateNb(){
		return caisse;
	}

	public int GetPlayerNb(){
		return playerNumber;
	}

	public void SetPlayerNb( int myPlayerNb){
		playerNumber = myPlayerNb;
	}
}
