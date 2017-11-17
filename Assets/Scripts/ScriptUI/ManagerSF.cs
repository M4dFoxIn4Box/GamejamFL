using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManagerSF : MonoBehaviour {

    public Button Play;
    public Button Quit;


	void Start () {

	}
	
	void Update () {
        float vAxis = Input.GetAxis("J1Vertical");
        
	}

    public void PlayOnClick()
    {
		SceneManager.LoadScene("SceneTristan");
	}

	public void QuitOnClick()
    {
		Application.Quit();
		Debug.Log("Quit");
	}
}