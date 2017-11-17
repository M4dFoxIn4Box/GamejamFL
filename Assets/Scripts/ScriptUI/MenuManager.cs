using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

	public GameObject lobby;
	public GameObject startMenu;
    public Button Play;
    public Button Quit;


	void Start () {
        lobby.SetActive(false);
        startMenu.SetActive(true);
	}
	
	void Update () {
        float vAxis = Input.GetAxis("J1Vertical");
        
	}

    private void FixedUpdate()
    {
        float bKey = Input.GetAxis("J1B");
        if (bKey == 1)
        {
            if (lobby == true)
            {
                ReturnToMenu();
            }
           
        }
    }

    public void PlayOnClick()
    {
		startMenu.SetActive(false);
		lobby.SetActive(true);
	}

	public void QuitOnClick()
    {
		Application.Quit();
		Debug.Log("Quit");
	}

    public void ReturnToMenu()
    {
        lobby.SetActive(false);
        startMenu.SetActive(true);
    }
}
