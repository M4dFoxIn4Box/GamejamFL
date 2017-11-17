using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement ;
using UnityEngine.UI;

public class MenuLobby : MonoBehaviour {

	private int nbJoueur = 1;
	public static bool player1InGame = true;
	public static bool player2InGame = false;
	public static bool player3InGame = false;
	public static bool player4InGame = false;
	public Button Play;
    public Button Quit;
    public GameObject canvasGeneral;
	public GameObject lobby;
	public GameObject startMenu;
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
	//private bool activeLby = false;

	private static MenuLobby instance;
    public static MenuLobby Instance()
    {
        return instance;
    }

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
	

	void Start () {
		Time.timeScale = 1;
		startMenu.SetActive(true);
		lobby.SetActive(false);
		Play.Select();
		DontDestroyOnLoad(gameObject);
	}
	
	void Update () 
	{
		Controllers();
	}

	void TogglePlayerOneEnd ()
	{
        if (!startMenu.activeSelf);
		    startMenu.SetActive(true);
		    lobby.SetActive(false);
		    Play.Select();
	}

    void TogglePlayerStart ()
    {
    	if (j1StartUI.activeSelf && nbJoueur > 1)
    	{
    		// canvasGeneral.SetActive(false);
    		SceneManager.LoadScene("SceneAmine");
    		Destroy(gameObject);
    	}
    }

	void TogglePlayerTwoUI ()
	{
		if (j2PushAUI.activeSelf)
		{
			nbJoueur ++;
			player2InGame = true;
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
			player2InGame = false;
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
			player3InGame = true;
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
			player3InGame = false;
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
			player4InGame = true;
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
			player4InGame = false;
			j4PushAUI.SetActive(true);
			j4PushBUI.SetActive(false);
		}

		if (!j4ImageNoir.activeSelf)
		{
			j4ImageNoir.SetActive(true);
			j4ImageBlanc.SetActive(false);
		}
	}


	public void PlayOnClick()
    {
		startMenu.SetActive(false);
		lobby.SetActive(true);
		//activeLby = true;
	}

	public void QuitOnClick()
    {
		Application.Quit();
		Debug.Log("Quit");
	}

    private void FixedUpdate()
    {
        bool bKey = Input.GetButtonDown("J1B");
        if (bKey)
        {
            if (lobby == true)
            {
                TogglePlayerOneEnd();
            }
           
        }
    }

    void Controllers() {

    	// float vAxis = Input.GetAxis("J1Vertical");

		//if (activeLby == true)
		//{        
		if (Input.GetButtonDown("J1B")){
			TogglePlayerOneEnd();
		}
		//}

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

    public int GetPlayersNumber ()
    {
    	return nbJoueur;
    }
}