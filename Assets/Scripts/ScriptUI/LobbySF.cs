using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement ;
using UnityEngine.UI;

public class LobbySF : MonoBehaviour {

	private int nbJoueur = 1;
	public GameObject j1PushBUI;
	public GameObject j1StartUI;
	public GameObject j2PushAUI;
	public GameObject j2PushBUI;
	public GameObject j2ImageNoir;
	public GameObject j2ImageBlanc;
	public GameObject j3PushAUI;
	public GameObject j3PushBUI;
	public GameObject j3ImageNoir;
	public GameObject j3ImageBlanc;
	public GameObject j4PushAUI;
	public GameObject j4PushBUI;
	public GameObject j4ImageNoir;
	public GameObject j4ImageBlanc;
	public GameObject tutoBlanc;
	public Button Oui;
	public Button Non;

	void Start () 
	{
		DontDestroyOnLoad(gameObject);
	}
	
	
	void Update () 
	{
		Controllers();
	}
 	
 	void Controllers() 
 	{


		if (Input.GetButtonDown("J1B")){
			TogglePlayerOneEnd();
		}	
		if (Input.GetButtonDown("J1Start")){
			TogglePlayerStart();
		}
		if(Input.GetButtonDown("J2A")){
			TogglePlayerTwoUI();
		}
		if(Input.GetButtonDown("J3A")){
			TogglePlayerThreeUI();
		}
		if(Input.GetButtonDown("J4A")){
			TogglePlayerFourUI();
		}
		if(Input.GetButtonDown("J2B")){
			TogglePlayerTwoUI2();
		}
		if(Input.GetButtonDown("J3B")){
			TogglePlayerThreeUI2();
		}
		if(Input.GetButtonDown("J4B")){
			TogglePlayerFourUI2();
		}
    }

    void TogglePlayerOneEnd ()
	{
		if (j1PushBUI.activeSelf)
		{
			SceneManager.LoadScene("SceneStart");
		}
	}

    void TogglePlayerStart ()
    {
    	if (j1StartUI.activeSelf && nbJoueur > 1)
    	{
    		tutoBlanc.SetActive(true);
    	}
    }

	void TogglePlayerTwoUI ()
	{
		if (j2PushAUI.activeSelf)
		{
			nbJoueur ++;
			j2PushAUI.SetActive(false);
			j2PushBUI.SetActive(true);
		}

		if (j2ImageNoir.activeSelf)
		{
			j2ImageNoir.SetActive(false);
			j2ImageBlanc.SetActive(true);
		}
	}

	void TogglePlayerTwoUI2 ()
	{
		if (!j2PushAUI.activeSelf)
		{
			nbJoueur --;
			j2PushAUI.SetActive(true);
			j2PushBUI.SetActive(false);
		}

		if (!j2ImageNoir.activeSelf)
		{
			j2ImageNoir.SetActive(true);
			j2ImageBlanc.SetActive(false);
		}
	}

	void TogglePlayerThreeUI ()
	{
		if (j3PushAUI.activeSelf)
		{
			nbJoueur ++;
			j3PushAUI.SetActive(false);
			j3PushBUI.SetActive(true);
		}

		if (j3ImageNoir.activeSelf)
		{
			j3ImageNoir.SetActive(false);
			j3ImageBlanc.SetActive(true);
		}
	}

	void TogglePlayerThreeUI2 ()
	{
		if (!j3PushAUI.activeSelf)
		{
			nbJoueur --;
			j3PushAUI.SetActive(true);
			j3PushBUI.SetActive(false);
		}

		if (!j3ImageNoir.activeSelf)
		{
			j3ImageNoir.SetActive(true);
			j3ImageBlanc.SetActive(false);
		}
	}

	void TogglePlayerFourUI ()
	{
		if (j4PushAUI.activeSelf)
		{
			nbJoueur ++;
			j4PushAUI.SetActive(false);
			j4PushBUI.SetActive(true);
		}

		if (j4ImageNoir.activeSelf)
		{
			j4ImageNoir.SetActive(false);
			j4ImageBlanc.SetActive(true);
		}
	}

	void TogglePlayerFourUI2 ()
	{
		if (!j4PushAUI.activeSelf)
		{
			nbJoueur --;
			j4PushAUI.SetActive(true);
			j4PushBUI.SetActive(false);
		}

		if (!j4ImageNoir.activeSelf)
		{
			j4ImageNoir.SetActive(true);
			j4ImageBlanc.SetActive(false);
		}
	}

	float vAxis = Input.GetAxis("J1Vertical");

	public void OuiOnClick()
	{
		SceneManager.LoadScene("SceneTuto");
	}

	public void NonOnClick()
	{
		SceneManager.LoadScene("SceneJeremy");
	}
}
