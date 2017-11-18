using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuto : MonoBehaviour
{
    public GameObject tuto;

	// Use this for initialization
	void Start ()
    {
        Time.timeScale = 0;
        tuto.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () 
        {
            if(Input.GetButtonDown("grabButton"))
            {
            Time.timeScale = 1;
            tuto.SetActive(false);
            }
        }
		
}


