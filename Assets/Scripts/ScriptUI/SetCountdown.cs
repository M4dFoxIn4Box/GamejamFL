using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCountdown : MonoBehaviour {
	private Countdown GMS;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetCountdownNow() {
		GMS = GameObject.Find ("UImanager").GetComponent<Countdown>();
		GMS.counterDownDone = true;
	}
}
