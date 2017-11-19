using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TutoManager : MonoBehaviour
{

    private AudioSource ausioSS;
    public GameObject tuto;
    public GameObject tutoButton;
    


    // Use this for initialization
    void Start ()
    {
        ausioSS = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () 
        {
       
        }

	public void TutoLaunch ()
            {
        ausioSS.Play();
        GameObject myEventSystem = GameObject.Find("EventSystem");
        Time.timeScale = 0;
        tuto.SetActive(true);           
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(tutoButton);
    }

    public void TutoEnd ()
    {
        ausioSS.Play();
        Time.timeScale = 1;
        SceneManager.LoadScene("GameScene");
    }

    public void Quit()
    {
        ausioSS.Play();
        Application.Quit();
    }
}


