using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerManager : MonoBehaviour {

	public int containerNumber;
	private int playerNb;
	private int caisse;
	public GameObject caisseInContainer;
	public GameObject uiManager;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider other){
		if (other.gameObject.CompareTag("Item")){
			caisseInContainer = other.gameObject;
			caisse = other.GetComponent<CrateManager>().GetCrateNb();
			// Debug.Log(caisse);
			playerNb = other.GetComponent<CrateManager>().GetPlayerNb();
			if (playerNb != 0){
				if (caisse == containerNumber){
					uiManager.GetComponent<UIManagerIG>().AddScore(playerNb, 50);
				} else if (caisse != containerNumber){
					uiManager.GetComponent<UIManagerIG>().AddScore(playerNb, 10);
				}
				DestroyObject();
			}
		}
	}

	void DestroyObject(){
		Destroy(caisseInContainer);
	}
}
