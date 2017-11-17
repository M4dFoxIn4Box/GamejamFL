using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PopItems : MonoBehaviour {

    public List<GameObject> popRandom = new List<GameObject>();
    private float nbmaxprefab =0f;
    public float spawnInterval = 3.0f;

    private float xRandom;
    private float zRandom;

    private Countdown GMS;

	// Use this for initialization
	void Start () {
        GMS = GameObject.Find ("UImanager").GetComponent<Countdown>();
		InvokeRepeating("RandoPop", 0.001f, spawnInterval);
	}

	void RandoPop () {
    if(GMS.counterDownDone == true)
    {

  		if (nbmaxprefab < 1000) 
      {
    		int tempory = UnityEngine.Random.Range(0,popRandom.Count);
    		GameObject iGo;
    		iGo = Instantiate(popRandom[tempory], transform.position, transform.rotation);
    		xRandom = UnityEngine.Random.Range(-7,7);
  			zRandom = UnityEngine.Random.Range(-7,7);
    		iGo.GetComponent<Rigidbody>().AddForce(xRandom, 0, zRandom, ForceMode.Impulse);
        nbmaxprefab += 1f;
  		}
    }

	}

}
