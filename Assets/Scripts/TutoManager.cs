using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoManager : MonoBehaviour
{
    public GameObject tuto;

	// Use this for initialization
	void Start ()
    {
       
	}
	
	// Update is called once per frame
	void Update () 
        {
          if(Input.GetButtonDown("graButton"))
            {
                Time.timeScale = 1;
            }
        }
	public void TutoLaunch ()
    {
       Time.timeScale = 0;
       tuto.SetActive(true);
    }
}


